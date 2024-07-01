using Extensionator;
using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class Slide : GroundState {
        private readonly Random _rng = new();
        public enum SLIDE_SIDE {
            RIGHT,
            LEFT,
            RANDOM
        }

        [Export] public Node3D Head { get; set; } = null!;
        [Export] public float SlideTime = 0.9f;
        [Export] public float SlideLerpSpeed = 8f;
        [Export] public float SlideTiltComebackTime = 0.35f;
        [Export(PropertyHint.Range, "0, 360f, 0.01")] public float SlideTilt = 7f;
        [Export] public SLIDE_SIDE SlideTiltSide = SLIDE_SIDE.RANDOM;
        [Export] public float FrictionMomentum = 0.1f;
        [Export] public bool ReduceSpeedGradually = true;
        [Export] public bool SwingHead = true;

        private Timer _slideTimer { get; set; } = default!;
        private Vector3 _entryVelocity = Vector3.Zero;
        private float _decreaseRate = 0;
        private int _slideSide = 0;

        public override void _EnterTree() {
            CreateSlideTimer();
        }

        public override void Enter() {
            if (IsInstanceValid(_slideTimer))
                _slideTimer.Start();

            _entryVelocity = Actor.Velocity;
            _decreaseRate = SlideTime;

            switch (SlideTiltSide) {
                case SLIDE_SIDE.RANDOM:
                    _slideSide = _rng.Chance(0.5f).ToSign();
                    break;
                case SLIDE_SIDE.RIGHT:
                    _slideSide = 1;
                    break;
                case SLIDE_SIDE.LEFT:
                    _slideSide = -1;
                    break;
            }

            Actor.AnimationPlayer?.Play("crouch");
        }

        public override async void Exit(MachineState nextState) {
            if (IsInstanceValid(_slideTimer))
                _slideTimer.Stop();

            _decreaseRate = SlideTime;

            if (Head.Rotation.Z != 0) {
                var tween = CreateTween();
                tween.TweenProperty(Head, "rotation:z", 0, SlideTiltComebackTime).SetEase(Tween.EaseType.Out);
            }

            if (nextState is not Crouch) {
                Actor.AnimationPlayer.PlayBackwards("crouch");
                await Actor.AnimationPlayer.WaitToFinished();
            }
        }

        public override void PhysicsUpdate(double delta) {
            base.PhysicsUpdate(delta);

            if (ReduceSpeedGradually)
                _decreaseRate -= (float)delta;

            var momentum = _decreaseRate + FrictionMomentum;

            Actor.Velocity = new Vector3(_entryVelocity.X * momentum, Actor.Velocity.Y, _entryVelocity.Z * momentum);

            if (SwingHead && SlideTilt > 0)
                Head.Rotation = Head.Rotation with { Z = Mathf.Lerp(Head.Rotation.Z, _slideSide * Mathf.DegToRad(SlideTilt), (float)delta * SlideLerpSpeed) };

            if (!Actor.CeilShapeCast.IsColliding())
                DetectJump();

            Actor.MoveAndSlide();
        }

        private void CreateSlideTimer() {
            _slideTimer ??= new Timer {
                Name = "SlideTimer",
                WaitTime = SlideTime,
                ProcessCallback = Timer.TimerProcessCallback.Physics,
                Autostart = false,
                OneShot = true
            };

            AddChild(_slideTimer);
            _slideTimer.Timeout += OnSlideTimerTimeout;

        }

        private void OnSlideTimerTimeout() {
            if (Actor.Crouch && Actor.CeilShapeCast.IsColliding())
                FSM?.ChangeStateTo<Crouch>();
            else
                FSM?.ChangeStateTo<Walk>();
        }
    }
}
