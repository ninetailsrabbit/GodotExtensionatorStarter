using Extensionator;
using Godot;
using GodotExtensionator;
using System.Linq;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    public partial class ScreenResolutionsOptionButton : OptionButton {

        [Export] public bool Display16_9 = true;
        [Export] public bool Display4_3 = false;
        [Export] public bool Display16_10 = false;
        [Export] public bool Display21_9 = false;

        public SettingsFileHandlerAutoload SettingsFileHandlerAutoload { get; set; } = null!;

        public override void _EnterTree() {
            SettingsFileHandlerAutoload = this.GetAutoloadNode<SettingsFileHandlerAutoload>();
            ItemSelected += OnResolutionSelected;
        }

        public override void _Ready() {

            if(OSExtension.IsSteamDeck()) {
                Display16_10 = true;
                Display16_9 = false;
                Display21_9 = false;
                Display4_3 = false;
            }

            Vector2I currentWindowSize = DisplayServer.WindowGetSize();

            Clear();

            foreach (var entry in SettingsFileHandlerAutoload.DefaultGameSettings.Resolutions) {
                if (ResolutionIsIncluded(entry.Key)) {
                    AddSeparator(entry.Key);

                    foreach (var resolution in entry.Value) {
                        AddItem($"{resolution.X}x{resolution.Y}");

                        if (currentWindowSize.Equals(resolution))
                            Select(ItemCount - 1);
                    }
                }
            }
        }

        private bool ResolutionIsIncluded(string resolution) {
            return resolution.EqualsIgnoreCase("16:9") && Display16_9 ||
                resolution.EqualsIgnoreCase("16:10") && Display16_10 ||
                resolution.EqualsIgnoreCase("4:3") && Display4_3 ||
                resolution.EqualsIgnoreCase("21:9") && Display21_9;
        }

        private void OnResolutionSelected(long idx) {
            string[] resolution = GetItemText((int)idx).Split("x");

            DisplayServer.WindowSetSize(new Vector2I(resolution.First().ToInt(), resolution.Last().ToInt()));

            SettingsFileHandlerAutoload.UpdateGraphicSection("resolution", DisplayServer.WindowGetSize());
            SettingsFileHandlerAutoload.SaveSettings();
        }
    }
}
