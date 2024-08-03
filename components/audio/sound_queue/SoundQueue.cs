using Extensionator;
using Godot;
using GodotExtensionator;
using System.Collections.Generic;
using System.Linq;

namespace GodotExtensionatorStarter {

    [Tool]
    [GlobalClass, Icon("res://components/audio/sound_queue/sound_queue.svg")]
    public partial class SoundQueue : Node {

        [Export]
        public int QueueCount {
            get => _queueCount;
            set {
                _queueCount = Mathf.Max(2, value);
            }
        }

        private int _queueCount = 2;
        private int _next = 0;

        public List<AudioStreamPlayer> AudioStreamPlayers = [];
        public List<AudioStreamPlayer2D> AudioStreamPlayers2D = [];
        public List<AudioStreamPlayer3D> AudioStreamPlayers3D = [];

        public bool IsNormalPlayer = false;
        public bool Is2DPlayer = false;
        public bool Is3DPlayer = false;

        public override string[] _GetConfigurationWarnings() {
            if (GetChildCount() == 0)
                return ["No children found. Expected AudioStreamPlayer/2D/3D child."];

            bool audioStreamPlayerFound = false;

            foreach (var child in GetChildren()) {
                if (child is AudioStreamPlayer || child is AudioStreamPlayer2D || child is AudioStreamPlayer3D) {
                    audioStreamPlayerFound = true;

                    break;
                }
            }

            if (!audioStreamPlayerFound)
                return ["Expected child to be an AudioStreamPlayer/2D/3D"];

            return base._GetConfigurationWarnings();
        }

        public override void _Ready() {
            if (GetChildCount() == 0) {
                GD.PushError("SoundQueue: No AudioStreamPlayer child found.");

                return;
            }

            var child = GetChild(0);

            if (child is AudioStreamPlayer audioStreamPlayer) {
                IsNormalPlayer = true;

                foreach (var _ in Enumerable.Range(0, QueueCount)) {
                    var audioStreamPlayerDuplicated = (AudioStreamPlayer)audioStreamPlayer.Duplicate();
                    AudioStreamPlayers.Add(audioStreamPlayerDuplicated);
                    AddChild(audioStreamPlayerDuplicated);
                }
            }

            else if (child is AudioStreamPlayer2D audioStreamPlayer2D) {
                Is2DPlayer = true;

                foreach (var _ in Enumerable.Range(0, QueueCount)) {
                    var audioStreamPlayerDuplicated = (AudioStreamPlayer2D)audioStreamPlayer2D.Duplicate();
                    AudioStreamPlayers2D.Add(audioStreamPlayerDuplicated);
                    AddChild(audioStreamPlayerDuplicated);
                }
            }

            else if (child is AudioStreamPlayer3D audioStreamPlayer3D) {
                Is3DPlayer = true;

                foreach (var _ in Enumerable.Range(0, QueueCount)) {
                    var audioStreamPlayerDuplicated = (AudioStreamPlayer3D)audioStreamPlayer3D.Duplicate();
                    AudioStreamPlayers3D.Add(audioStreamPlayerDuplicated);
                    AddChild(audioStreamPlayerDuplicated);
                }
            }
        }

        #region Play sounds
        public void PlaySound() {
            if (AudioStreamPlayersAreEmpty())
                return;

            if (IsNormalPlayer && !AudioStreamPlayers[_next].Playing) {
                AudioStreamPlayers[_next++].Play();
                _next %= AudioStreamPlayers.Count;
            }

            if (Is2DPlayer && !AudioStreamPlayers2D[_next].Playing) {
                AudioStreamPlayers2D[_next++].Play();
                _next %= AudioStreamPlayers2D.Count;
            }

            if (Is3DPlayer && !AudioStreamPlayers3D[_next].Playing) {
                AudioStreamPlayers3D[_next++].Play();
                _next %= AudioStreamPlayers3D.Count;
            }
        }

        public void PlaySoundWithPitch(float pitch = 0.9f) {
            if (AudioStreamPlayersAreEmpty())
                return;

            if (CanPlayNextAudioStreamPlayer()) {
                AudioStreamPlayers[_next++].PlayWithPitch(pitch);
                _next %= AudioStreamPlayers.Count;
            }

            if (CanPlayNextAudioStreamPlayer2D()) {
                AudioStreamPlayers2D[_next++].PlayWithPitch(pitch);
                _next %= AudioStreamPlayers2D.Count;
            }

            if (CanPlayNextAudioStreamPlayer3D()) {
                AudioStreamPlayers3D[_next++].PlayWithPitch(pitch);
                _next %= AudioStreamPlayers3D.Count;
            }
        }

        public void PlaySoundEaseWithPitch(float duration = 1f, float pitch = 0.9f) {
            if (AudioStreamPlayersAreEmpty())
                return;

            if (CanPlayNextAudioStreamPlayer()) {
                AudioStreamPlayers[_next++].PlayEaseWithPitch(duration, pitch);
                _next %= AudioStreamPlayers.Count;
            }

            if (CanPlayNextAudioStreamPlayer2D()) {
                AudioStreamPlayers2D[_next++].PlayWithPitchRange(duration, pitch);
                _next %= AudioStreamPlayers2D.Count;
            }

            if (CanPlayNextAudioStreamPlayer3D()) {
                AudioStreamPlayers3D[_next++].PlayWithPitchRange(duration, pitch);
                _next %= AudioStreamPlayers3D.Count;
            }
        }

        public void PlaySoundWithPitchRange(float minPitch = 0.9f, float maxPitch = 1.3f) {
            if (AudioStreamPlayersAreEmpty())
                return;

            if (CanPlayNextAudioStreamPlayer()) {
                AudioStreamPlayers[_next++].PlayWithPitchRange(minPitch, maxPitch);
                _next %= AudioStreamPlayers.Count;
            }

            if (CanPlayNextAudioStreamPlayer2D()) {
                AudioStreamPlayers2D[_next++].PlayWithPitchRange(minPitch, maxPitch);
                _next %= AudioStreamPlayers2D.Count;
            }

            if (CanPlayNextAudioStreamPlayer3D()) {
                AudioStreamPlayers3D[_next++].PlayWithPitchRange(minPitch, maxPitch);
                _next %= AudioStreamPlayers3D.Count;
            }
        }

        public void PlaySoundEaseWithPitchRange(float duration = 1f, float minPitch = 0.9f, float maxPitch = 1.3f) {
            if (AudioStreamPlayersAreEmpty())
                return;

            if (CanPlayNextAudioStreamPlayer()) {
                AudioStreamPlayers[_next++].PlayEaseWithPitchRange(duration, minPitch, maxPitch);
                _next %= AudioStreamPlayers.Count;
            }

            if (CanPlayNextAudioStreamPlayer2D()) {
                AudioStreamPlayers2D[_next++].PlayEaseWithPitchRange(duration, minPitch, maxPitch);
                _next %= AudioStreamPlayers2D.Count;
            }

            if (CanPlayNextAudioStreamPlayer3D()) {
                AudioStreamPlayers3D[_next++].PlayEaseWithPitchRange(duration, minPitch, maxPitch);
                _next %= AudioStreamPlayers3D.Count;
            }
        }

        public void StopSounds() {
            foreach (var audioStreamPlayer in AudioStreamPlayers)
                audioStreamPlayer.Stop();

            foreach (var audioStreamPlayer in AudioStreamPlayers2D)
                audioStreamPlayer.Stop();

            foreach (var audioStreamPlayer in AudioStreamPlayers3D)
                audioStreamPlayer.Stop();
        }
        #endregion

        #region Helpers
        private bool CanPlayNextAudioStreamPlayer() => IsNormalPlayer && !AudioStreamPlayers[_next].Playing;
        private bool CanPlayNextAudioStreamPlayer2D() => Is2DPlayer && !AudioStreamPlayers2D[_next].Playing;
        private bool CanPlayNextAudioStreamPlayer3D() => Is3DPlayer && !AudioStreamPlayers3D[_next].Playing;
        private bool AudioStreamPlayersAreEmpty() => AudioStreamPlayers.IsEmpty() && AudioStreamPlayers2D.IsEmpty() && AudioStreamPlayers3D.IsEmpty();
        #endregion
    }

}
