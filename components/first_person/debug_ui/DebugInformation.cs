using Godot;
using GodotExtensionator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        #region Camera nodes
        public HSlider MouseSensitivitySlider { get; set; } = default!;
        public HSlider CameraSensitivitySlider { get; set; } = default!;
        public HSlider CameraVerticalRotationLimitSlider { get; set; } = default!;
        #endregion

        #region State parameters nodes
        public SpinBox IdleFrictionSpinBox { get; set; } = default!;
        public SpinBox CrouchSpeedSpinBox { get; set; } = default!;
        public SpinBox CrouchAccelerationSpinBox { get; set; } = default!;
        public SpinBox CrawlSpeedSpinBox { get; set; } = default!;
        public SpinBox WalkSpeedSpinBox { get; set; } = default!;
        public SpinBox WalkSideSpeedSpinBox { get; set; } = default!;
        public SpinBox WalkAccelerationSpinBox { get; set; } = default!;
        public SpinBox WalkFrictionSpinBox { get; set; } = default!;
        public SpinBox WalkCatchingBreathSpinBox { get; set; } = default!;
        public SpinBox RunSpeedSpinBox { get; set; } = default!;
        public SpinBox RunSideSpeedSpinBox { get; set; } = default!;
        public SpinBox RunAccelerationSpinBox { get; set; } = default!;
        public SpinBox RunFrictionSpinBox { get; set; } = default!;
        public SpinBox RunSprintTimeSpinBox { get; set; } = default!;

        public SpinBox SlideTimeSpinBox { get; set; } = default!;
        public SpinBox SlideLerpSpeedSpinBox { get; set; } = default!;
        public SpinBox SlideTiltSpinBox { get; set; } = default!;
        public SpinBox SlideTiltComebackTimeSpinBox { get; set; } = default!;
        public SpinBox SlideFrictionMomentumSpinBox { get; set; } = default!;
        public OptionButton SlideSideOptionButton { get; set; } = default!;
        public CheckBox SlideReduceSpeedGraduallyCheckbox { get; set; } = default!;
        public CheckBox SlideSwingHeadCheckbox { get; set; } = default!;

        public SpinBox FallEdgeGapJumpSpinBox { get; set; } = default!;
        public SpinBox FallGravityForceSpinBox { get; set; } = default!;
        public SpinBox FallMaximumFallVelocitySpinBox { get; set; } = default!;
        public SpinBox FallAirSpeedSpinBox { get; set; } = default!;
        public SpinBox FallAirAccelerationSpinBox { get; set; } = default!;
        public SpinBox FallAirFrictionSpinBox { get; set; } = default!;
        public SpinBox FallCoyoteTimeFramesSpinBox { get; set; } = default!;
        public SpinBox FallJumpInputBufferFramesSpinBox { get; set; } = default!;
        public OptionButton FallAirControlModeOptionButton { get; set; } = default!;
        public CheckBox FallCoyoteTimeCheckBox { get; set; } = default!;
        public CheckBox FallJumpInputBufferCheckBox { get; set; } = default!;

        #endregion

        private Dictionary<string, List<PropertyInfo>> StatesProperties = [];
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

            MouseSensitivitySlider = GetNode<HSlider>($"%{nameof(MouseSensitivitySlider)}");
            CameraSensitivitySlider = GetNode<HSlider>($"%{nameof(CameraSensitivitySlider)}");
            CameraVerticalRotationLimitSlider = GetNode<HSlider>($"%{nameof(CameraVerticalRotationLimitSlider)}");

            IdleFrictionSpinBox = GetNode<SpinBox>($"%{nameof(IdleFrictionSpinBox)}");
            WalkSpeedSpinBox = GetNode<SpinBox>($"%{nameof(WalkSpeedSpinBox)}");
            WalkSideSpeedSpinBox = GetNode<SpinBox>($"%{nameof(WalkSideSpeedSpinBox)}");
            WalkAccelerationSpinBox = GetNode<SpinBox>($"%{nameof(WalkAccelerationSpinBox)}");
            WalkFrictionSpinBox = GetNode<SpinBox>($"%{nameof(WalkFrictionSpinBox)}");
            WalkCatchingBreathSpinBox = GetNode<SpinBox>($"%{nameof(WalkCatchingBreathSpinBox)}");

            CrouchSpeedSpinBox = GetNode<SpinBox>($"%{nameof(CrouchSpeedSpinBox)}");
            CrouchAccelerationSpinBox = GetNode<SpinBox>($"%{nameof(CrouchAccelerationSpinBox)}");
            CrawlSpeedSpinBox = GetNode<SpinBox>($"%{nameof(CrawlSpeedSpinBox)}");

            RunSpeedSpinBox = GetNode<SpinBox>($"%{nameof(RunSpeedSpinBox)}");
            RunSideSpeedSpinBox = GetNode<SpinBox>($"%{nameof(RunSideSpeedSpinBox)}");
            RunAccelerationSpinBox = GetNode<SpinBox>($"%{nameof(RunAccelerationSpinBox)}");
            RunFrictionSpinBox = GetNode<SpinBox>($"%{nameof(RunFrictionSpinBox)}");
            RunSprintTimeSpinBox = GetNode<SpinBox>($"%{nameof(RunSprintTimeSpinBox)}");

            SlideTimeSpinBox = GetNode<SpinBox>($"%{nameof(SlideTimeSpinBox)}");
            SlideLerpSpeedSpinBox = GetNode<SpinBox>($"%{nameof(SlideLerpSpeedSpinBox)}");
            SlideTiltSpinBox = GetNode<SpinBox>($"%{nameof(SlideTiltSpinBox)}");
            SlideTiltComebackTimeSpinBox = GetNode<SpinBox>($"%{nameof(SlideTiltComebackTimeSpinBox)}");
            SlideFrictionMomentumSpinBox = GetNode<SpinBox>($"%{nameof(SlideFrictionMomentumSpinBox)}");
            SlideReduceSpeedGraduallyCheckbox = GetNode<CheckBox>($"%{nameof(SlideReduceSpeedGraduallyCheckbox)}");
            SlideSwingHeadCheckbox = GetNode<CheckBox>($"%{nameof(SlideSwingHeadCheckbox)}");
            SlideSideOptionButton = GetNode<OptionButton>($"%{nameof(SlideSideOptionButton)}");

            FallEdgeGapJumpSpinBox = GetNode<SpinBox>($"%{nameof(FallEdgeGapJumpSpinBox)}");
            FallGravityForceSpinBox = GetNode<SpinBox>($"%{nameof(FallGravityForceSpinBox)}");
            FallMaximumFallVelocitySpinBox = GetNode<SpinBox>($"%{nameof(FallMaximumFallVelocitySpinBox)}");
            FallAirSpeedSpinBox = GetNode<SpinBox>($"%{nameof(FallAirSpeedSpinBox)}");
            FallAirAccelerationSpinBox = GetNode<SpinBox>($"%{nameof(FallAirAccelerationSpinBox)}");
            FallAirFrictionSpinBox = GetNode<SpinBox>($"%{nameof(FallAirFrictionSpinBox)}");
            FallCoyoteTimeFramesSpinBox = GetNode<SpinBox>($"%{nameof(FallCoyoteTimeFramesSpinBox)}");
            FallJumpInputBufferFramesSpinBox = GetNode<SpinBox>($"%{nameof(FallJumpInputBufferFramesSpinBox)}");
            FallAirControlModeOptionButton = GetNode<OptionButton>($"%{nameof(FallAirControlModeOptionButton)}");
            FallCoyoteTimeCheckBox = GetNode<CheckBox>($"%{nameof(FallCoyoteTimeCheckBox)}");
            FallJumpInputBufferCheckBox = GetNode<CheckBox>($"%{nameof(FallJumpInputBufferCheckBox)}");

            MouseSensitivitySlider.ValueChanged += OnMouseSensitivityValueChanged;
            CameraSensitivitySlider.ValueChanged += OnCameraSensitivityValueChanged;
            CameraVerticalRotationLimitSlider.ValueChanged += OnCameraVerticalRotationLimitValueChanged;

            IdleFrictionSpinBox.ValueChanged += OnIdleFrictionValueChanged;
            CrouchSpeedSpinBox.ValueChanged += (double value) => OnCrouchStateValueChanged(CrouchSpeedSpinBox, value);
            CrouchAccelerationSpinBox.ValueChanged += (double value) => OnCrouchStateValueChanged(CrouchAccelerationSpinBox, value);
            CrawlSpeedSpinBox.ValueChanged += OnCrawlSpeedValueChanged;

            WalkSpeedSpinBox.ValueChanged += (double value) => OnWalkStateValueChanged(WalkSpeedSpinBox, value);
            WalkSideSpeedSpinBox.ValueChanged += (double value) => OnWalkStateValueChanged(WalkSideSpeedSpinBox, value);
            WalkAccelerationSpinBox.ValueChanged += (double value) => OnWalkStateValueChanged(WalkAccelerationSpinBox, value);
            WalkFrictionSpinBox.ValueChanged += (double value) => OnWalkStateValueChanged(WalkFrictionSpinBox, value);
            WalkCatchingBreathSpinBox.ValueChanged += (double value) => OnWalkStateValueChanged(WalkCatchingBreathSpinBox, value);

            RunSpeedSpinBox.ValueChanged += (double value) => OnRunStateValueChanged(RunSpeedSpinBox, value);
            RunSideSpeedSpinBox.ValueChanged += (double value) => OnRunStateValueChanged(RunSideSpeedSpinBox, value);
            RunAccelerationSpinBox.ValueChanged += (double value) => OnRunStateValueChanged(RunAccelerationSpinBox, value);
            RunFrictionSpinBox.ValueChanged += (double value) => OnRunStateValueChanged(RunFrictionSpinBox, value);
            RunSprintTimeSpinBox.ValueChanged += (double value) => OnRunStateValueChanged(RunSprintTimeSpinBox, value);

            SlideTimeSpinBox.ValueChanged += (double value) => OnSlideStateSpinBoxValueChanged(SlideTimeSpinBox, value);
            SlideLerpSpeedSpinBox.ValueChanged += (double value) => OnSlideStateSpinBoxValueChanged(SlideLerpSpeedSpinBox, value);
            SlideTiltSpinBox.ValueChanged += (double value) => OnSlideStateSpinBoxValueChanged(SlideTiltSpinBox, value);
            SlideTiltComebackTimeSpinBox.ValueChanged += (double value) => OnSlideStateSpinBoxValueChanged(SlideTiltComebackTimeSpinBox, value);
            SlideFrictionMomentumSpinBox.ValueChanged += (double value) => OnSlideStateSpinBoxValueChanged(SlideFrictionMomentumSpinBox, value);
            SlideReduceSpeedGraduallyCheckbox.Toggled += (bool toggled) => OnSlideStateCheckboxToggled(SlideReduceSpeedGraduallyCheckbox, toggled);
            SlideSwingHeadCheckbox.Toggled += (bool toggled) => OnSlideStateCheckboxToggled(SlideSwingHeadCheckbox, toggled);
            SlideSideOptionButton.ItemSelected += OnSlideSideOptionSelected;

            FallEdgeGapJumpSpinBox.ValueChanged += (double value) => OnFallStateSpinBoxValueChanged(FallEdgeGapJumpSpinBox, value);
            FallMaximumFallVelocitySpinBox.ValueChanged += (double value) => OnFallStateSpinBoxValueChanged(FallMaximumFallVelocitySpinBox, value);
            FallGravityForceSpinBox.ValueChanged += (double value) => OnFallStateSpinBoxValueChanged(FallGravityForceSpinBox, value);
            FallAirSpeedSpinBox.ValueChanged += (double value) => OnFallStateSpinBoxValueChanged(FallAirSpeedSpinBox, value);
            FallAirAccelerationSpinBox.ValueChanged += (double value) => OnFallStateSpinBoxValueChanged(FallAirAccelerationSpinBox, value);
            FallAirFrictionSpinBox.ValueChanged += (double value) => OnFallStateSpinBoxValueChanged(FallAirFrictionSpinBox, value);
            FallCoyoteTimeFramesSpinBox.ValueChanged += (double value) => OnFallStateSpinBoxValueChanged(FallCoyoteTimeFramesSpinBox, value);
            FallJumpInputBufferFramesSpinBox.ValueChanged += (double value) => OnFallStateSpinBoxValueChanged(FallJumpInputBufferFramesSpinBox, value);
            FallCoyoteTimeCheckBox.Toggled += (bool toggled) => OnFallStateCheckboxToggled(FallCoyoteTimeCheckBox, toggled);
            FallJumpInputBufferCheckBox.Toggled += (bool toggled) => OnFallStateCheckboxToggled(FallJumpInputBufferCheckBox, toggled);
            FallAirControlModeOptionButton.ItemSelected += OnFallSideOptionSelected;

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
            if (Actor.FSM.GetState<Idle>() is Idle idleState)
                IdleFrictionSpinBox.Value = idleState.Friction;

            if (Actor.FSM.GetState<Crouch>() is Crouch crouchState) {
                StatesProperties.Add(crouchState.GetType().Name, [.. crouchState.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)]);

                CrouchSpeedSpinBox.Value = crouchState.Speed;
                CrouchAccelerationSpinBox.Value = crouchState.Acceleration;
            }

            if (Actor.FSM.GetState<Crawl>() is Crawl crawlState) {
                CrawlSpeedSpinBox.Value = crawlState.Speed;
            }

            if (Actor.FSM.GetState<Walk>() is Walk walkState) {
                StatesProperties.Add(walkState.GetType().Name, [.. walkState.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)]);

                WalkSpeedSpinBox.Value = walkState.Speed;
                WalkSideSpeedSpinBox.Value = walkState.SideSpeed;
                WalkAccelerationSpinBox.Value = walkState.Acceleration;
                WalkFrictionSpinBox.Value = walkState.Friction;
                WalkCatchingBreathSpinBox.Value = walkState.CatchingBreathRecoveryTime;
            }

            if (Actor.FSM.GetState<Run>() is Run runState) {
                StatesProperties.Add(runState.GetType().Name, [.. runState.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)]);

                RunSpeedSpinBox.Value = runState.Speed;
                RunSideSpeedSpinBox.Value = runState.SideSpeed;
                RunAccelerationSpinBox.Value = runState.Acceleration;
                RunFrictionSpinBox.Value = runState.Friction;
                RunSprintTimeSpinBox.Value = runState.SprintTime;
            }

            if (Actor.FSM.GetState<Slide>() is Slide slideState) {
                StatesProperties.Add(slideState.GetType().Name, [.. slideState.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)]);

                SlideTimeSpinBox.Value = slideState.SlideTime;
                SlideLerpSpeedSpinBox.Value = slideState.SlideLerpSpeed;
                SlideTiltSpinBox.Value = slideState.SlideTilt;
                SlideTiltComebackTimeSpinBox.Value = slideState.SlideTiltComebackTime;
                SlideFrictionMomentumSpinBox.Value = slideState.FrictionMomentum;

                SlideReduceSpeedGraduallyCheckbox.ButtonPressed = slideState.ReduceSpeedGradually;
                SlideSwingHeadCheckbox.ButtonPressed = slideState.SwingHead;

                SlideSideOptionButton.Selected = (int)slideState.SlideTiltSide;
            }

            if (Actor.FSM.GetState<Fall>() is Fall fallState) {
                StatesProperties.Add(fallState.GetType().Name, [.. fallState.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)]);

                FallEdgeGapJumpSpinBox.Value = fallState.EdgeGampJump;
                FallGravityForceSpinBox.Value = fallState.GravityForce;
                FallMaximumFallVelocitySpinBox.Value = fallState.MaximumFallVelocity;
                FallAirSpeedSpinBox.Value = fallState.AirSpeed;
                FallAirAccelerationSpinBox.Value = fallState.AirAcceleration;
                FallAirFrictionSpinBox.Value = fallState.AirFriction;

                FallAirControlModeOptionButton.Selected = (int)fallState.AirControlMode;
                FallCoyoteTimeFramesSpinBox.Value = fallState.CoyoteTimeFrames;
                FallJumpInputBufferFramesSpinBox.Value = fallState.JumpInputBufferTimeFrames;
                FallCoyoteTimeCheckBox.ButtonPressed = fallState.CoyoteTime;
                FallJumpInputBufferCheckBox.ButtonPressed = fallState.JumpInputBuffer;

            }


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
            if (Actor.FSM.GetState<Idle>() is Idle idleState) {
                idleState.Friction = (float)value;
            }
        }

        private void OnCrawlSpeedValueChanged(double value) {
            if (Actor.FSM.GetState<Crawl>() is Crawl crawlState) {
                crawlState.Speed = (float)value;
            }
        }
        private void OnCrouchStateValueChanged(SpinBox spinBox, double value) {
            if (Actor.FSM.GetState<Crouch>() is Crouch crouchState) {
                var meta = spinBox.GetMeta("property");

                if (StatesProperties[crouchState.GetType().Name]
                    .FirstOrDefault(info => info.Name.EqualsIgnoreCase(meta.ToString())) is PropertyInfo property) {
                    property.SetValue(crouchState, (float)value);
                }
            }
        }

        private void OnWalkStateValueChanged(SpinBox spinBox, double value) {
            if (Actor.FSM.GetState<Walk>() is Walk walkState) {
                var meta = spinBox.GetMeta("property");

                if (StatesProperties[walkState.GetType().Name]
                    .FirstOrDefault(info => info.Name.EqualsIgnoreCase(meta.ToString())) is PropertyInfo property) {
                    property.SetValue(walkState, (float)value);
                }
            }
        }
        private void OnRunStateValueChanged(SpinBox spinBox, double value) {
            if (Actor.FSM.GetState<Run>() is Run runState) {
                var meta = spinBox.GetMeta("property").ToString();

                if (StatesProperties[runState.GetType().Name]
                    .FirstOrDefault(info => info.Name.EqualsIgnoreCase(meta)) is PropertyInfo property) {
                    property.SetValue(runState, (float)value);
                }
            }
        }

        private void OnSlideStateSpinBoxValueChanged(SpinBox spinBox, double value) {
            if (Actor.FSM.GetState<Slide>() is Slide slideState) {
                var meta = spinBox.GetMeta("property").ToString();

                if (StatesProperties[slideState.GetType().Name]
                    .FirstOrDefault(info => info.Name.EqualsIgnoreCase(meta)) is PropertyInfo property) {
                    property.SetValue(slideState, (float)value);
                }
            }
        }

        private void OnSlideStateCheckboxToggled(CheckBox checkbox, bool toggled) {
            if (Actor.FSM.GetState<Slide>() is Slide slideState) {
                var meta = checkbox.GetMeta("property").ToString();

                if (StatesProperties[slideState.GetType().Name]
                    .FirstOrDefault(info => info.Name.EqualsIgnoreCase(meta)) is PropertyInfo property) {
                    property.SetValue(slideState, toggled);
                }
            }
        }

        private void OnSlideSideOptionSelected(long value) {
            if (Actor.FSM.GetState<Slide>() is Slide slideState) {
                slideState.SlideTiltSide = (Slide.SLIDE_SIDE)value;
            }
        }

        private void OnFallStateSpinBoxValueChanged(SpinBox spinBox, double value) {
            if (Actor.FSM.GetState<Fall>() is Fall fallState) {
                var meta = spinBox.GetMeta("property").ToString();

                if (StatesProperties[fallState.GetType().Name]
                    .FirstOrDefault(info => info.Name.EqualsIgnoreCase(meta)) is PropertyInfo property) {

                    if (property.PropertyType == typeof(int))
                        property.SetValue(fallState, Convert.ToInt32(value));
                    else
                        property.SetValue(fallState, (float)value);

                }
            }
        }

        private void OnFallStateCheckboxToggled(CheckBox checkbox, bool toggled) {
            if (Actor.FSM.GetState<Fall>() is Fall fallState) {
                var meta = checkbox.GetMeta("property").ToString();

                if (StatesProperties[fallState.GetType().Name]
                    .FirstOrDefault(info => info.Name.EqualsIgnoreCase(meta)) is PropertyInfo property) {
                    property.SetValue(fallState, toggled);
                }
            }
        }

        private void OnFallSideOptionSelected(long value) {
            if (Actor.FSM.GetState<Fall>() is Fall fallState) {
                fallState.AirControlMode = (Fall.AIR_CONTROL_MODE)value;
            }
        }
        #endregion
    }
}
