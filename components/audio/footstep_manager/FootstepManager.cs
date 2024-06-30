using Extensionator;
using Godot;
using GodotExtensionator;
using System;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {

    [Icon("res://components/audio/footstep_manager/footstep_manager_3d.svg")]
    public partial class FootstepManager : Node3D {
        [Export] public RayCast3D FloorDetectorRaycast { get; set; } = default!;
        [Export] public bool UsePitch = true;
        [Export] public float MinPitchRange = .9f;
        [Export] public float MaxPitchRange = 1.3f;

        public const float DefaultIntervalTime = .6f;
        public Dictionary<string, AudioStreamPlayer3D> SoundsMaterial = [];

        public Godot.Timer IntervalTimer { get; set; } = default!;
        public bool SfxPlaying = false;

        public override void _EnterTree() {
            ArgumentNullException.ThrowIfNull(FloorDetectorRaycast);

            CreateIntervalTimer();
        }

        public void Footstep(float interval = DefaultIntervalTime) {
            if (FloorDetectorRaycast.IsColliding() &&
                !SoundsMaterial.IsEmpty() &&
                !SfxPlaying &&
                IsInstanceValid(IntervalTimer) &&
                IntervalTimer.TimeLeft == 0
            ) {

                var collider = FloorDetectorRaycast.GetCollider();
                Godot.Collections.Array<StringName> groups = [];

                switch (collider) {
                    case CsgShape3D csgShape3D:
                        groups = csgShape3D.GetGroups();
                        break;
                    case StaticBody3D staticBody:
                        groups = staticBody.GetGroups();
                        break;
                    case Area3D area:
                        groups = area.GetGroups();
                        break;
                }

                if (groups.Count > 0) {
                    foreach (StringName group in groups) {
                        if (SoundsMaterial.TryGetValue(group, out AudioStreamPlayer3D? audioPlayer)) {

                            if (UsePitch)
                                audioPlayer.PlayWithPitchRange(MinPitchRange, MaxPitchRange);
                            else
                                audioPlayer.Play();

                            IntervalTimer.Start(interval);
                            SfxPlaying = true;
                            break;
                        }
                    }
                }
            }
        }

        private void CreateIntervalTimer() {
            IntervalTimer ??= new() {
                Name = "FootstepManagerIntervalTimer",
                ProcessCallback = Godot.Timer.TimerProcessCallback.Physics,
                Autostart = false,
                OneShot = true
            };

            AddChild(IntervalTimer);
            IntervalTimer.Timeout += OnIntervalTimerTimeout;
        }

        private void OnIntervalTimerTimeout() {
            SfxPlaying = false;
        }

    }
}
