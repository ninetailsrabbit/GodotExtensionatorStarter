using Godot;
using GodotExtensionator;
using System.Diagnostics;

namespace GodotExtensionatorStarter {

    [GlobalClass, Icon("res://components/interaction/interactor_3d.svg")]
    public partial class MouseRayCastInteractor : Node3D, IInteractor {

        #region Exported parameters
        [Export] public Camera3D OriginCamera { get; set; } = default!;
        [Export] public float RayLength = 1000f;
        [Export] public MouseButton InteractButton = MouseButton.Left;
        [Export] public string[] InputActionsToInteract = ["interact"];

        [Export] public string[] InputActionsToCancelInteraction = ["cancel_interaction"];
        [Export] public CompressedTexture2D DefaultCursor { get; set; } = Preloader.Instance.CursorPointerC;

        #endregion

        public Camera3D CurrentCamera { get; set; } = default!;
        public Interactable3D? CurrentInteractable;
        public bool Focused = false;
        public bool Interacting = false;
        public Vector2 MousePosition;

        public GameGlobals GameGlobals { get; set; } = default!;

        public override void _Input(InputEvent @event) {
            if (CurrentCamera is not null && @event is InputEventMouse mouse) {
                MousePosition = mouse.Position;

                if (IsProcessing() && (InteractButton.Equals(MouseButton.Left) && @event.IsMouseLeftClick()) ||
                    (InteractButton.Equals(MouseButton.Right) && @event.IsMouseRightClick()) ||
                    InputExtension.IsAnyActionJustPressed(InputActionsToInteract)) {
                    Interact(CurrentInteractable);
                }
            }

            if (InputExtension.IsAnyActionJustPressed(InputActionsToCancelInteraction) && CurrentInteractable is not null)
                CancelInteract(CurrentInteractable);


        }
        public override void _Ready() {
            DisplayCustomCursor();

            Debug.Assert(OriginCamera is not null, "MouseRayCastInteractor: This node needs a Camera3D to create the mouse raycast");
            SetProcessInput(OriginCamera is not null);
            SetProcess(OriginCamera is not null);

            GameGlobals = this.GetAutoloadNode<GameGlobals>();
            CurrentCamera = OriginCamera;
        }

        public void DisplayCustomCursor() {
            if (DefaultCursor is not null)
                Input.SetCustomMouseCursor(DefaultCursor, Input.CursorShape.Arrow, DefaultCursor.GetSize() / 2);
        }

        public override void _Process(double delta) {
            Interactable3D? detectedInteractable = GetDetectedInteractable();

            if (detectedInteractable is not null) {
                if (CurrentInteractable is null && !Focused) {
                    Focus(detectedInteractable);
                }
            }
            else {
                if (Focused && !Interacting)
                    UnFocus(CurrentInteractable);
            }
        }

        public Interactable3D? GetDetectedInteractable() {
            if (InputExtension.IsMouseVisible()) {

                PhysicsDirectSpaceState3D worldSpace = GetWorld3D().DirectSpaceState;
                Vector3 from = CurrentCamera.ProjectRayOrigin(MousePosition);
                Vector3 to = from + CurrentCamera.ProjectRayNormal(MousePosition) * RayLength;

                PhysicsRayQueryParameters3D rayQuery = PhysicsRayQueryParameters3D.Create(from, to, GameGlobals.InteractablesCollisionLayer);
                rayQuery.CollideWithAreas = true;
                rayQuery.CollideWithBodies = false;

                var result = worldSpace.IntersectRay(rayQuery);

                if (result.TryGetValue("collider", out var interactable))
                    return (Interactable3D)interactable;
            }

            return null;
        }

        public void ChangeCameraTo(Camera3D camera) {
            CurrentCamera = camera;
        }

        public void ReturnToOriginalCamera() {
            ChangeCameraTo(OriginCamera);
        }

        public void Enable() {
            SetProcess(true);
        }

        public void Disable() {
            SetProcess(false);
        }

        public void Interact(GodotObject interactable) {
            if (interactable is Interactable3D _interactable) {
                if (_interactable.IsScannable())
                    Interacting = true;

                _interactable.EmitSignalSafe(Interactable3D.SignalName.Interacted, this);
            }
        }
        public void CancelInteract(GodotObject interactable) {
            if (interactable is Interactable3D _interactable) {
                DisplayCustomCursor();

                Interacting = false;
                Focused = false;

                _interactable.EmitSignalSafe(Interactable3D.SignalName.CanceledInteraction, this);

                CurrentInteractable = null;
            }

        }

        public void Focus(GodotObject interactable) {
            if (interactable is Interactable3D _interactable && !_interactable.Equals(CurrentInteractable)) {
                CurrentInteractable = _interactable;
                Focused = true;

                _interactable.EmitSignalSafe(Interactable3D.SignalName.Focused, this);
            }
        }

        public void UnFocus(GodotObject interactable) {
            if (interactable is Interactable3D _interactable && CurrentInteractable is not null) {
                DisplayCustomCursor();

                if(!CurrentInteractable.KeepInteractableWhenUnFocus)
                    CurrentInteractable = null;

                Focused = false;

                _interactable.EmitSignalSafe(Interactable3D.SignalName.UnFocused, this);
            }
        }
    }
}