using Godot;
using GodotExtensionator;

namespace GodotExtensionatorStarter {

    [GlobalClass]
    public partial class DynamicWorldEnvironment3D : WorldEnvironment {

        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;
        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = default!;

        public override void _ExitTree() {
            GlobalGameEvents.UpdatedGraphicSettings -= OnUpdatedGraphicSettings;
        }

        public override void _EnterTree() {
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
            GlobalGameEvents.UpdatedGraphicSettings += OnUpdatedGraphicSettings;
        }

        public override void _Ready() {
            UpdateGraphicSettings((GameSettingsResource.QualityPresets)(int)SettingsFileHandlerAutoload.GetGraphicSection("quality_preset"));
        }

        private void UpdateGraphicSettings(GameSettingsResource.QualityPresets preset) {
            var qualityPresets = SettingsFileHandlerAutoload.DefaultGameSettings.GraphicQualityPresets;
            var selectedQualityPreset = qualityPresets[preset];

            bool glowEnabled = selectedQualityPreset.Settings["environment/glow_enabled"].Enabled == 1;
            bool ssrEnabled = selectedQualityPreset.Settings["environment/ss_reflections_enabled"].Enabled == 1;
            bool ssaoEnabled = selectedQualityPreset.Settings["environment/ssao_enabled"].Enabled == 1;
            Viewport.Msaa antialiasingMode = (Viewport.Msaa)selectedQualityPreset.Settings["rendering/anti_aliasing/quality/msaa_3d"].Enabled;

            Environment.GlowEnabled = glowEnabled;
            Environment.SsrEnabled = ssrEnabled;
            Environment.SsaoEnabled = ssaoEnabled;
            GetViewport().Msaa3D = antialiasingMode;
        }
        private void OnUpdatedGraphicSettings(int qualityPreset) {
            UpdateGraphicSettings((GameSettingsResource.QualityPresets)qualityPreset);
        }


    }
}
