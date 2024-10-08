﻿using Extensionator;
using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class Slide : GroundState {
        private readonly Random _rng = new();
        public enum SlideSide {
            Random,
            Left,
            Right
        }

        [Export] public Node3D Head { get; set; } = null!;
        [Export] public float SlideTime { get; set; } = 0.9f;
        [Export] public float SlideLerpSpeed { get; set; } = 8f;
        [Export] public float SlideTiltComebackTime { get; set; } = 0.35f;
        [Export(PropertyHint.Range, "0, 360f, 0.01")] public float SlideTilt { get; set; } = 7f;
        [Export] public SlideSide SlideTiltSide { get; set; } = SlideSide.Random;
        [Export] public float FrictionMomentum { get; set; } = 0.1f;
        [Export] public bool ReduceSpeedGradually { get; set; } = true;
        [Export] public bool SwingHead { get; set; } = true;

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
                case SlideSide.Random:
                    _slideSide = _rng.Chance(0.5f).ToSign();
                    break;
                case SlideSide.Left:
                    _slideSide = 1;
                    break;
                case SlideSide.Right:
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
                Head.Rotation = Head.Rotation with { Z = Mathf.LerpAngle(Head.Rotation.Z, _slideSide * Mathf.DegToRad(SlideTilt), (float)delta * SlideLerpSpeed) };

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
