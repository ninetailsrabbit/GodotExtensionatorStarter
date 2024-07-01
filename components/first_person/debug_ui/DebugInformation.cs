using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {
    public partial class DebugInformation : Control {

        [Export] public FirstPersonController Actor { get; set; } = null!;
        [Export] public string PauseAction = "pause";

        public Label FPSInfo { get; set; } = default!;
        public Label VsyncInfo { get; set; } = default!;
        public Label MemoryInfo { get; set; } = default!;
        public Label Velocity { get; set; } = default!;
        public Label State { get; set; } = default!;
        public FiniteStateMachine ActorFSM { get; set; } = default!;

        public Control ParametersPanel { get; set; } = default!;

        public HSlider MouseSensitivitySlider { get; set; } = default!;
        public HSlider CameraSensitivitySlider { get; set; } = default!;
        public HSlider CameraVerticalRotationLimitSlider { get; set; } = default!;

        public SpinBox IdleFrictionSpinBox { get; set; } = default!;

        public override void _UnhandledInput(InputEvent @event) {
            if (Input.IsActionJustPressed(PauseAction)) {
                if (ParametersPanel.Visible)
                    GetTree().ResumeGame();
                else
                    GetTree().PauseGame();

                ParametersPanel.Visible = GetTree().IsPaused();

                if (ParametersPanel.Visible)
                    InputExtension.ShowMouseCursor();
                else
                    InputExtension.CaptureMouse();
            }

        }

        public override void _ExitTree() {
            Actor.FSM.StateChanged -= OnStateChanged;
            Actor.FSM.StatesInitialized -= PrepareStates;
        }

        public override void _EnterTree() {
            Actor ??= GetTree().GetFirstNodeInGroup(FirstPersonController.GROUP_NAME) as FirstPersonController;

            ArgumentNullException.ThrowIfNull(nameof(Actor));

            FPSInfo = GetNode<Label>("%FPSLabel");
            VsyncInfo = GetNode<Label>("%VsyncLabel");
            MemoryInfo = GetNode<Label>("%MemoryLabel");
            Velocity = GetNode<Label>("%VelocityLabel");
            State = GetNode<Label>("%StateLabel");

            ParametersPanel = GetNode<Control>("Parameters");
            ParametersPanel.Hide();

            MouseSensitivitySlider = GetNode<HSlider>("%MouseSensitivitySlider");
            CameraSensitivitySlider = GetNode<HSlider>("%CameraSensitivitySlider");
            CameraVerticalRotationLimitSlider = GetNode<HSlider>("%CameraVerticalRotationLimitSlider");

            IdleFrictionSpinBox = GetNode<SpinBox>("%IdleFrictionSpinBox");

            MouseSensitivitySlider.ValueChanged += OnMouseSensitivityValueChanged;
            CameraSensitivitySlider.ValueChanged += OnCameraSensitivityValueChanged;
            CameraVerticalRotationLimitSlider.ValueChanged += OnCameraVerticalRotationLimitValueChanged;
            IdleFrictionSpinBox.ValueChanged += OnIdleFrictionValueChanged;

            Actor.FSM.StateChanged += OnStateChanged;
            Actor.FSM.StatesInitialized += PrepareStates;

        }

        public override void _Ready() {
            MouseFilter = MouseFilterEnum.Pass;

            State.Text = $"[{Actor.FSM.CurrentState.Name}]";

            DisplayFPS();
            DisplayVsync();
            DisplayMemory();
            DisplayVelocity();
            PrepareCameraMovementPanel();
        }

        public override void _Process(double delta) {
            DisplayFPS();
            DisplayVsync();
            DisplayMemory();
            DisplayVelocity();
        }


        private void DisplayFPS() {
            FPSInfo.Text = $"FPS: {Engine.GetFramesPerSecond()}";
        }

        private void DisplayVsync() {
            VsyncInfo.Text = $"Vsync: {DisplayServer.WindowGetVsyncMode().ToString()}";
        }

        private void DisplayMemory() {
            MemoryInfo.Text = $"Memory: {OS.GetStaticMemoryUsage() / 1048576.0f} MiB";
        }

        private void DisplayVelocity() {
            Velocity.Text = $"Velocity: {Actor.Velocity}";
        }

        private void PrepareCameraMovementPanel() {
            MouseSensitivitySlider.Value = Actor.CameraMovement.MouseSensitivity;
            MouseSensitivitySlider.MinValue = 0.1f;
            MouseSensitivitySlider.MaxValue = 20f;
            MouseSensitivitySlider.Step = 0.1f;

            CameraSensitivitySlider.Value = Actor.CameraMovement.CameraSensitivity;
            CameraSensitivitySlider.MinValue = 0.01f;
            CameraSensitivitySlider.MaxValue = 1f;
            CameraSensitivitySlider.Step = 0.01f;

            CameraVerticalRotationLimitSlider.Value = Actor.CameraMovement.CameraVerticalRotationLimit;
            CameraVerticalRotationLimitSlider.MinValue = 0f;
            CameraVerticalRotationLimitSlider.MaxValue = Mathf.RadToDeg(Mathf.Tau);
            CameraVerticalRotationLimitSlider.Step = 1f;
        }

        private void PrepareStates() {
            IdleFrictionSpinBox.Value = Actor.FSM.GetState<Idle>().Friction;
        }

        #region Signal callbacks
        private void OnStateChanged(MachineState from, MachineState to) {
            State.Text = $"{from.Name} -> [{to.Name}]";
        }

        private void OnMouseSensitivityValueChanged(double value) {
            Actor.CameraMovement.MouseSensitivity = (float)value;
        }

        private void OnCameraSensitivityValueChanged(double value) {
            Actor.CameraMovement.CameraSensitivity = (float)value;
        }

        private void OnCameraVerticalRotationLimitValueChanged(double value) {
            Actor.CameraMovement.CameraVerticalRotationLimit = (float)value;
        }

        private void OnIdleFrictionValueChanged(double value) {
            Actor.FSM.GetState<Walk>().Friction = (float)value;
        }
        #endregion
    }
}
