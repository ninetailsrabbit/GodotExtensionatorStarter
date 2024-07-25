using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {
    public partial class GameSettingsUI : Control {

        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;
        public HSlider MasterBusSlider { get; set; } = default!;
        public HSlider MusicBusSlider { get; set; } = default!;
        public HSlider AmbientBusSlider { get; set; } = default!;
        public HSlider SFXBusSlider { get; set; } = default!;
        public HSlider VoiceBusSlider { get; set; } = default!;
        public HSlider UIBusSlider { get; set; } = default!;

        public CheckButton MuteCheckButton { get; set; } = default!;
        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
            //SettingsFileHandlerAutoload.LoadSettings();
        }

        public override void _Ready() {
            MasterBusSlider = GetNode<HSlider>($"%{nameof(MasterBusSlider)}");
            MusicBusSlider = GetNode<HSlider>($"%{nameof(MusicBusSlider)}");
            AmbientBusSlider = GetNode<HSlider>($"%{nameof(AmbientBusSlider)}");
            SFXBusSlider = GetNode<HSlider>($"%{nameof(SFXBusSlider)}");
            VoiceBusSlider = GetNode<HSlider>($"%{nameof(VoiceBusSlider)}");
            UIBusSlider = GetNode<HSlider>($"%{nameof(UIBusSlider)}");
            MuteCheckButton = GetNode<CheckButton>($"%{nameof(MuteCheckButton)})");

            MasterBusSlider.Value = AudioManager.Instance.GetActualVolumeDbFromBus("Master");
            MusicBusSlider.Value = AudioManager.Instance.GetActualVolumeDbFromBus("Music");
            AmbientBusSlider.Value = AudioManager.Instance.GetActualVolumeDbFromBus("Ambient");
            SFXBusSlider.Value = AudioManager.Instance.GetActualVolumeDbFromBus("SFX");
            VoiceBusSlider.Value = AudioManager.Instance.GetActualVolumeDbFromBus("Voice");
            UIBusSlider.Value = AudioManager.Instance.GetActualVolumeDbFromBus("UI");

        }
    }

}