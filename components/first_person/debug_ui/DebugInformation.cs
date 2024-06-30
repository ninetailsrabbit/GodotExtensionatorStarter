using Godot;
using System;

namespace GodotExtensionatorStarter {
    public partial class DebugInformation : Control {

        [Export] public FirstPersonController Actor { get; set; } = null!;

        public Label FPSInfo { get; set; } = default!;
        public Label VsyncInfo { get; set; } = default!;
        public Label MemoryInfo { get; set; } = default!;
        public Label Velocity { get; set; } = default!;
        public Label State { get; set; } = default!;
        public FiniteStateMachine ActorFSM { get; set; } = default!;


        public override void _ExitTree() {
            Actor.FSM.StateChanged -= OnStateChanged;
        }

        public override void _EnterTree() {
            Actor ??= GetTree().GetFirstNodeInGroup(FirstPersonController.GROUP_NAME) as FirstPersonController;

            ArgumentNullException.ThrowIfNull(nameof(Actor));

            FPSInfo = GetNode<Label>("%FPSLabel");
            VsyncInfo = GetNode<Label>("%VsyncLabel");
            MemoryInfo = GetNode<Label>("%MemoryLabel");
            Velocity = GetNode<Label>("%VelocityLabel");
            State = GetNode<Label>("%StateLabel");

  
            Actor.FSM.StateChanged += OnStateChanged;
        }

        public override void _Ready() {
            MouseFilter = MouseFilterEnum.Pass;

            State.Text = $"[{Actor.FSM.CurrentState.Name}]";

            DisplayFPS();
            DisplayVsync();
            DisplayMemory();
            DisplayVelocity();
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

        private void OnStateChanged(MachineState from, MachineState to) {
            State.Text = $"{from.Name} -> [{to.Name}]";
        }
    }
}
