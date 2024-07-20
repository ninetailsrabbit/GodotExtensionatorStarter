using Extensionator;
using Godot;
using GodotExtensionator;
using System.ComponentModel;
using System.Runtime.CompilerServices;

///1. Force vs.Impulse:
///
/// Force: Represents a continuous application of force over time (measured in newtons). When applied to a rigid body, it produces acceleration in the direction of the force.
/// Impulse: Represents a sudden change in momentum delivered instantly(measured in newton-seconds). Applying an impulse directly changes the linear or angular velocity of the rigid body based on the impulse magnitude and direction.
///
///2. Application Point:
///
/// Central vs.Non-Central:
/// Central: Applied at the center of mass of the rigid body. This results in pure translation (linear movement) without rotation.
/// Non-Central: Applied at a specific point relative to the body's center of mass. This can produce both translation and rotation (torque) depending on the force/impulse direction and its distance from the center of mass. 
///
/// Continuous vs. Instantaneous: Use force methods (apply_force or apply_central_force) for situations where you want to continuously influence the body's movement over time. Use impulse methods (apply_impulse or apply_central_impulse) when you want to cause an immediate change in velocity without applying a prolonged force.
/// Central vs. Non-Central: Use central methods (apply_central_force or apply_central_impulse) if you only want to translate the body without introducing rotation. Use non-central methods (apply_force or apply_impulse) if you want to introduce both translation and rotation based on the application point relative to the center of mass.
/// Torque: Use apply_torque when you want to directly rotate the body around a specific axis without applying a force.


namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/throwables/icons/throwable_3d.svg")]
    public partial class Throwable : RigidBody3D, INotifyPropertyChanged {

        const int MAXIMUM_TRANSPARENCY_ON_PULL = 255;

        #region Signals
        [Signal]
        public delegate void FocusedEventHandler();

        [Signal]
        public delegate void UnfocusedEventHandler();

        [Signal]
        public delegate void PulledEventHandler();

        [Signal]
        public delegate void ThrowedEventHandler();

        [Signal]
        public delegate void DroppedEventHandler();

        [Signal]
        public delegate void LockedEventHandler();

        [Signal]
        public delegate void UnlockedEventHandler();

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Exported variables
        [Export] public string Title = "Throwable";
        [Export] public string Description = "Can be throwed";
        [Export] public GRAB_MODE GrabMode = GRAB_MODE.DYNAMIC;
        [Export] public STATE State = STATE.NEUTRAL;
        [Export] public int TransparencyOnPull = MAXIMUM_TRANSPARENCY_ON_PULL;
        [Export] public Texture2D FocusPointer { get; set; } = default!;
        [Export] public Texture2D LockedPointer { get; set; } = default!;
        #endregion

        public enum GRAB_MODE {
            DYNAMIC,
            FREEZE
        }

        public enum STATE {
            NEUTRAL,
            PULL,
            THROW
        }

        public GameGlobals GameGlobals { get; set; } = null!;
        public Node OriginalParent { get; set; } = null!;
        public uint OriginalCollisionLayer;
        public uint OriginalCollisionMask;
        public int OriginalTransparency = 255;

        public Node3D? Grabber { get; set; } = default!;
        public Vector3 CurrentLinearVelocity = Vector3.Zero;
        public STATE CurrentState = STATE.NEUTRAL;
        public StandardMaterial3D ActiveMaterial { get; set; } = default!;

        public bool BodyLocked {
            get => _locked;
            set {
                if (_locked != value) {
                    _locked = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private bool _locked = false;

        public override void _EnterTree() {
            GameGlobals = this.GetAutoloadNode<GameGlobals>();

            OriginalParent = GetParent();
            OriginalCollisionLayer = GameGlobals.ThrowablesCollisionLayer;
            OriginalCollisionMask = GameGlobals.WorldCollisionLayer | GameGlobals.InteractablesCollisionLayer | GameGlobals.PlayerCollisionLayer | GameGlobals.EnemiesCollisionLayer;

            PrepareActiveMaterial();
        }


        public override void _IntegrateForces(PhysicsDirectBodyState3D state) {
            if (StateIsPull())
                state.LinearVelocity = CurrentLinearVelocity;

            if (StateIsThrow() && state.LinearVelocity.IsZeroApprox())
                CurrentState = STATE.NEUTRAL;
        }

        public void UpdateLinearVelocity(Vector3 linearVelocity) {
            CurrentLinearVelocity = linearVelocity;
        }

        public void Pull(Node3D grabber) {
            if (Grabber is not null && Grabber.Equals(grabber))
                return;

            Grabber = grabber;
            CollisionLayer = 0;

            if (GrabModeIsFreeze()) {
                FreezeMode = FreezeModeEnum.Kinematic;
                Freeze = true;
            }

            Reparent(grabber);
            ApplyTransparency();
            CurrentState = STATE.PULL;

            EmitSignal(SignalName.Pulled);
        }

        public void Throw(Vector3 impulse) {
            if (GrabModeIsFreeze())
                Freeze = false;

            CollisionLayer = OriginalCollisionLayer;
            Reparent(OriginalParent);

            LinearVelocity = Vector3.Zero;
            ApplyImpulse(impulse);

            Grabber = null;
            CurrentState = STATE.THROW;
            RecoverTransparency();

            EmitSignal(SignalName.Throwed);
        }


        public void Drop() {
            if (GrabModeIsFreeze())
                Freeze = false;

            CollisionLayer = OriginalCollisionLayer;
            Reparent(OriginalParent);

            LinearVelocity = Vector3.Zero;
            ApplyImpulse(Vector3.Zero);

            Grabber = null;
            CurrentState = STATE.NEUTRAL;
            RecoverTransparency();

            EmitSignal(SignalName.Dropped);
        }

        private void PrepareActiveMaterial() {
            var mesh = this.FirstNodeOfType<MeshInstance3D>();

            if (mesh is not null && mesh.GetActiveMaterial(0) is StandardMaterial3D activeMaterial) {
                ActiveMaterial = activeMaterial;
                OriginalTransparency = ActiveMaterial.AlbedoColor.A8;
            }
        }

        private void ApplyTransparency() {
            if (TransparencyOnPull.Equals(MAXIMUM_TRANSPARENCY_ON_PULL))
                return;

            if (ActiveMaterial is not null) {
                ActiveMaterial.Transparency = BaseMaterial3D.TransparencyEnum.Alpha;
                ActiveMaterial.AlbedoColor = ActiveMaterial.AlbedoColor with { A8 = TransparencyOnPull };
            }
        }

        private void RecoverTransparency() {
            if (TransparencyOnPull.Equals(MAXIMUM_TRANSPARENCY_ON_PULL))
                return;

            if (ActiveMaterial is not null)
                ActiveMaterial.AlbedoColor = ActiveMaterial.AlbedoColor with { A8 = OriginalTransparency };
        }


        #region Helpers
        public bool StateIsNeutral() => State.Equals(STATE.NEUTRAL);
        public bool StateIsPull() => State.Equals(STATE.PULL);
        public bool StateIsThrow() => State.Equals(STATE.THROW);
        public bool GrabModeIsFreeze() => GrabMode.Equals(GRAB_MODE.FREEZE);
        public bool GrabModeIsDynamic() => GrabMode.Equals(GRAB_MODE.DYNAMIC);
        #endregion

        #region Event callbacks
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs eventArgs) {
            if (eventArgs.PropertyName is string propertyChanged) {

                if (propertyChanged.EqualsIgnoreCase(nameof(BodyLocked))) {
                    if (BodyLocked)
                        EmitSignal(SignalName.Locked);
                    else
                        EmitSignal(SignalName.Unlocked);
                }
            }
        }
        #endregion
    }

}
