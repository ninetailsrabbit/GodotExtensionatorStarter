using Extensionator;
using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class AudioSlider : HSlider {
        [Export(PropertyHint.Enum, "Master,Music,SFX,Voice,Ambient,UI")] public string AudioBus = string.Empty;
        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public bool IsMuted = false;

        public override void _EnterTree() {
            Name = $"{AudioBus}AudioSlider";

            if (!AudioManager.Instance.BusExists(AudioBus)) {
                GD.PushError($"{Name}: The bus {AudioBus} does not exist in the actual bus layout");
                throw new ArgumentException($"{Name}: The bus {AudioBus} does not exist in the actual bus layout");
            }

            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();

            MinValue = 0f;
            MaxValue = 1f;
            Step = 0.001f;

            ValueChanged += OnVolumeValueChanged;
        }

        public override void _Ready() {
            if (Visible)
                this.Enable();
            else
                this.Disable();

            Value = (float)SettingsFileHandlerAutoload.ConfigFileApi.GetValue(SettingsFileHandlerAutoload.AudioSection, AudioBus);
            IsMuted = AudioManager.IsMuted(AudioBus);
        }

        private void OnVolumeValueChanged(double value) {
            AudioManager.ChangeVolume(AudioBus, (float)value);
            SettingsFileHandlerAutoload.UpdateAudioSection(AudioBus, AudioManager.GetActualVolumeDbFromBus(AudioBus));
            SettingsFileHandlerAutoload.SaveSettings();
        }


    }
}
