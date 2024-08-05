using Godot;
using Godot.Collections;

namespace GodotExtensionatorStarter {
    public partial class CursorManager : Node {
        public Timer CursorDisplayTimer { get; set; } = null!;
        public float TemporaryDisplayTime { get; set; } = 3.5f;
        public Texture2D LastCursorTexture { get; set; } = default!;

        public Dictionary<Input.CursorShape, Texture2D> DefaultGameCursorsByShape = new() {
            { Input.CursorShape.Arrow, Preloader.Instance.CursorPointerC },
            { Input.CursorShape.PointingHand, Preloader.Instance.CursorHandThinOpen },
            { Input.CursorShape.Help, Preloader.Instance.CursorHelp },
            { Input.CursorShape.Forbidden, Preloader.Instance.CursorLock },
        };

        public override void _EnterTree() {
            CursorDisplayTimer ??= new Timer() {
                Name = "CursorDisplayTimer",
                WaitTime = TemporaryDisplayTime,
                Autostart = false,
                OneShot = true,
            };

            AddChild(CursorDisplayTimer);

            CursorDisplayTimer.Timeout += OnCursorDisplayTimeout;
        }

        public override void _Ready() {
            ChangeCursorTo(DefaultGameCursorsByShape[Input.CursorShape.Arrow]);
        }

        public void ReturnCursorToDefault(Input.CursorShape shape = Input.CursorShape.Arrow) {
            ChangeCursorTo(DefaultGameCursorsByShape[shape]);
        }
        public void ChangeCursorTo(Texture2D texture, Input.CursorShape shape = Input.CursorShape.Arrow) {
            Input.SetCustomMouseCursor(texture, shape, texture.GetSize() / 2);
            LastCursorTexture = texture;
        }

        public void ChangeCursorTemporaryTo(Texture2D texture, Input.CursorShape shape = Input.CursorShape.Arrow, float? duration = null) {
            duration ??= TemporaryDisplayTime;

            ChangeCursorTo(texture, shape);
            CursorDisplayTimer.Start((float)duration);
        }

        private void OnCursorDisplayTimeout() {
            ChangeCursorTo(LastCursorTexture);
        }

    }
}
