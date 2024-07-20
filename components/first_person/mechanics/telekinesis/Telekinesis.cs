using Extensionator;
using Godot;
using Godot.Collections;
using GodotExtensionator;
using System.Collections.Generic;
using System.Linq;

namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/first_person/telekinesis/telekinesis.svg")]
    public partial class Telekinesis : Node3D {
        #region Signals
        [Signal]
        public delegate void PulledThrowableEventHandler(Throwable throwable);

        [Signal]
        public delegate void ThrowedThrowableEventHandler(Throwable throwable);
        #endregion

        #region Exported variables
        [Export] public ThrowableRayCastInteractor ThrowableRayCastInteractor { get; set; } = default!;
        [Export] public ThrowableAreaDetector? ThrowableAreaDetector { get; set; } = default!;
        [Export(PropertyHint.Range, "0.1, 1000, 0.01")] public float ThrowableInteractorDistance = 5f;

        [ExportGroup("Actions")]
        [Export] public string PullInputAction = "pull";
        [Export] public string ThrowInputAction = "throw";
        [Export] public string PullAreaInputAction = "pull_area";
        [Export] public string PushWaveInputAction = "push_wave";
        [Export] public bool PullAreaAbility = true;
        [Export] public bool PushWaveAbility = true;

        [ExportGroup("Forces")]
        [Export] public float PullPower = 15f;
        [Export] public float ThrowPower = 10f;
        [Export] public float MaximumMassThatCanLift = 1.5f;
        [Export] public float AngularPower = 1.5f;
        #endregion

        public Array<ActiveThrowable> ActiveThrowables = [];
        public Array<Marker3D> Slots = [];

        public override void _UnhandledInput(InputEvent @event) {
            if (InputMap.HasAction(ThrowInputAction) && Input.IsActionJustPressed(ThrowInputAction)) {
                foreach (var activeThrowable in ActiveThrowables)
                    Throw(activeThrowable);
            }

            if (InputMap.HasAction(PullInputAction) && Input.IsActionJustPressed(PullInputAction)) {
                if (ThrowableRayCastInteractor.CurrentThrowable is not null) {
                    Pull(ThrowableRayCastInteractor.CurrentThrowable);
                    ThrowableRayCastInteractor.Unfocus();
                }
            }

            if (PullAreaAbility && InputMap.HasAction(PullAreaInputAction) && Input.IsActionJustPressed(PullAreaInputAction)) {
                foreach (var body in GetNearThrowables())
                    Pull(body);
            }

            if (PushWaveAbility && InputMap.HasAction(PushWaveInputAction) && Input.IsActionJustPressed(PushWaveInputAction)) {

            }

        }
        public override void _EnterTree() {
            ThrowableRayCastInteractor ??= this.FirstNodeOfClass<ThrowableRayCastInteractor>();
            ThrowableRayCastInteractor ??= GetParent<ThrowableRayCastInteractor>();
            ThrowableRayCastInteractor.TargetPosition = Vector3.Forward * ThrowableInteractorDistance;

            ThrowableAreaDetector ??= this.FirstNodeOfClass<ThrowableAreaDetector>();
            ThrowableAreaDetector ??= GetParent<ThrowableAreaDetector>();

            UpdateSlots();
        }

        public override void _PhysicsProcess(double delta) {
            // TODO - MAYBE RETHINK THIS PART TO MOVE FREELY THE OBJECT WHEN PULLED INSTEAD OF BEING CONSTANTLY PULLED TO THE SLOT
            foreach (var activeThrowable in ActiveThrowables)
                ApplyPullForce(activeThrowable.Body, delta);

        }

        public void Throw(ActiveThrowable activeThrowable) {
            Throw(activeThrowable.Body);
        }
        public void Throw(Throwable body) {
            ActiveThrowables.Remove(ActiveThrowables.FirstOrDefault(activeThrowable => activeThrowable.Body.Equals(body)));

            Vector3 impulse = GetViewport().GetCamera3D().ForwardDirection() * ThrowPower;

            body.Throw(impulse);
            body.AngularVelocity = Vector3.One * AngularPower;

            EnableInteractors(false);

            if (ThrowableAreaDetector is not null)
                ThrowableAreaDetector.Monitoring = true;

            EmitSignal(SignalName.ThrowedThrowable, body);
        }

        public void Pull(ActiveThrowable activeThrowable) {
            Pull(activeThrowable.Body);
        }
        public void Pull(Throwable body) {
            bool slotsAvailable = ThereAreAvailableSlots();

            EnableInteractors(slotsAvailable);

            if (slotsAvailable && BodyCanBeLifted(body) && body.StateIsNeutral()) {
                if (!body.BodyLocked) {
                    if (GetRandomFreeSlot() is Marker3D freeSlot) {
                        body.Pull(freeSlot);
                        ActiveThrowables.Add(new(body, freeSlot));
                        EmitSignal(SignalName.PulledThrowable, body);
                    }
                }
            }
        }

        public void ApplyPullForce(Throwable body, double? delta = null) {
            delta ??= GetPhysicsProcessDeltaTime();

            if (body.Grabber is not null) {
                if (body.GrabModeIsDynamic())
                    body.UpdateLinearVelocity((body.Grabber.GlobalPosition - body.GlobalPosition) * PullPower);
                else
                    body.GlobalPosition = body.GlobalPosition.MoveToward(body.Grabber.GlobalPosition, (float)delta * PullPower);
            }
        }

        public List<Throwable> GetNearThrowables(bool sortedByDistance = true) {
            if (ThrowableAreaDetector is not null) {
                var bodies = ThrowableAreaDetector.GetOverlappingBodies().Where(body => body is Throwable).Cast<Throwable>().ToList();

                if (sortedByDistance)
                    bodies.Sort(delegate (Throwable throwableOne, Throwable throwableTwo) { return throwableOne.GlobalDistanceTo(this).CompareTo(throwableTwo.GlobalDistanceTo(this)); });

                return bodies;
            }

            return [];
        }

        public bool BodyCanBeLifted(Throwable body) => body.Mass <= MaximumMassThatCanLift;

        #region Slot related
        private Array<Marker3D> AvailableSlots() {
            var busySlots = BusySlots();

            return (Array<Marker3D>)Slots.Where(slot => !busySlots.Contains(slot));
        }

        private Array<Marker3D> BusySlots() => (Array<Marker3D>)ActiveThrowables.Select(activeThrowable => activeThrowable.Slot);
        private Marker3D? GetRandomFreeSlot() {
            if (ThereAreAvailableSlots())
                return AvailableSlots().RandomElement();

            return null;
        }

        private bool ThereAreAvailableSlots() => ActiveThrowables.Count < Slots.Count;

        private void UpdateSlots() {
            Slots = this.GetAllChildren<Marker3D>();
        }
        #endregion


        private void EnableInteractors(bool enable = false) {
            ThrowableRayCastInteractor.Enabled = enable;
            SetPhysicsProcess(enable);

            if (ThrowableAreaDetector is not null)
                ThrowableAreaDetector.Monitoring = enable;
        }
    }

    public partial class ActiveThrowable(Throwable body, Marker3D slot) : RefCounted {
        public Throwable Body { get; set; } = body;
        public Marker3D Slot { get; set; } = slot;

    }
}
