using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    [GlobalClass, Icon("res://components/interaction/interactor_3d.svg")]
    public partial class ThrowableRayCastInteractor : RayCast3D {

        public GameGlobals GameGlobals { get; set; } = null!;
        public Throwable? CurrentThrowable { get; set; } = default!;
        public bool Focused = false;
        public bool Unfocused = false;

        public override void _EnterTree() {
            GameGlobals = this.GetAutoloadNode<GameGlobals>();
            CollideWithBodies = true;
            CollideWithAreas = false;
            CollisionMask = GameGlobals.ThrowablesCollisionLayer;
        }

        public override void _PhysicsProcess(double delta) {
            Throwable? detectedThrowable = GetCollider() as Throwable;

            if (detectedThrowable is not null) {
                if (CurrentThrowable != detectedThrowable && !Focused)
                    Focus(detectedThrowable);
            }
            else {
                if (Focused && CurrentThrowable is not null)
                    Unfocus(CurrentThrowable);
            }
        }

        public void Focus(Throwable throwable) {
            CurrentThrowable = throwable;

            if (!Focused) {
                throwable.EmitSignal(Throwable.SignalName.Focused);
            }

            Focused = true;
        }

        public void Unfocus(Throwable? throwable = null) {
            throwable ??= CurrentThrowable;

            if (Focused) {
                throwable?.EmitSignal(Throwable.SignalName.Unfocused);
            }

            CurrentThrowable = null;
            Focused = false;
        }
    }

}