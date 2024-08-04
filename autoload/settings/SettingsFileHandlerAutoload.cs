using Extensionator;
using Godot;
using Godot.Collections;
using GodotExtensionator;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GodotExtensionatorStarter {

    public sealed partial class SettingsFileHandlerAutoload : Node {
        #region Signals
        [Signal]
        public delegate void ResetToDefaultSettingsEventHandler();

        [Signal]
        public delegate void CreatedSettingsEventHandler();
        [Signal]
        public delegate void LoadedSettingsEventHandler();
        #endregion

        public const string KeybindingsSection = "keybindings";
        public const string GraphicsSection = "graphics";
        public const string AudioSection = "audio";
        public const string AccessibilitySection = "accessibility";
        public const string LocalizationSection = "localization";
        public const string AnalyticsSection = "analytics";

        public const string KeybindingsSeparator = "|";
        public const string InputEventSeparator = ":";

        public const string DefaultFileFormat = "ini"; //  ini or cfg

        public string SettingsFilePath = $"{OS.GetUserDataDir()}/settings.{DefaultFileFormat}";
        public bool IncludeUIKeybindings = false;

        public ConfigFile ConfigFileApi = new();
        public GameSettingsResource DefaultGameSettings = new();

        public GamepadControllerManager GamepadControllerManager { get; set; } = default!;
        public GlobalGameEvents GlobalGameEvents { get; set; } = default!;

        public override void _Ready() {
            GamepadControllerManager = this.GetAutoloadNode<GamepadControllerManager>();
            GlobalGameEvents = this.GetAutoloadNode<GlobalGameEvents>();

            if (!SettingsFileExists())
                CreateSettingsFile();

            LoadSettingsFromFile();
        }

        public SettingsFileHandlerAutoload ChangeConfigPath(string newPath) {
            if (!string.IsNullOrEmpty(newPath) && newPath.IsAbsolutePath())
                SettingsFilePath = newPath;

            return this;
        }

        public SettingsFileHandlerAutoload ReturnToDefaultConfigPath() {
            SettingsFilePath = $"{OS.GetUserDataDir()}/settings.{DefaultFileFormat}";

            return this;
        }

        public void LoadSettingsFromFile(ConfigFile? configFile = null) {
            if (configFile is null && SettingsFileExists()) {
                ConfigFileApi.Clear();
                ConfigFileApi.Load(SettingsFilePath);
            }

            LoadAudio(ConfigFileApi);
            LoadKeybindings(ConfigFileApi);
            LoadGraphics(ConfigFileApi);
            LoadLocalization(ConfigFileApi);

            EmitSignal(SignalName.LoadedSettings);
        }

        public void CreateSettingsFile(GameSettingsResource? gameSettings = null) {
            gameSettings ??= DefaultGameSettings;

            CreateKeybindingsSection();
            CreateGraphicsSection(gameSettings);
            CreateAudioSection(gameSettings);
            CreateAccessibilitySection(gameSettings);
            CreateAnalyticsSection(gameSettings);
            CreateLocalizationSection(gameSettings);

            SaveSettings();

            EmitSignal(SignalName.CreatedSettings);
        }

        #region Create settings
        public void CreateKeybindingsSection() {
            Godot.Collections.Dictionary<string, string> Keybindings = [];

            foreach (StringName action in GetInputMapActions()) {
                Array<string> KeybindingsEvents = [];

                foreach (InputEvent inputEvent in InputExtension.GetAllInputsForAction(action)) {
                    if (inputEvent is InputEventKey eventKey)
                        KeybindingsEvents.Add($"InputEventKey:{WhiteSpaceRegex().Replace(InputExtension.ReadableKey(eventKey), "")}");




                    if (inputEvent is InputEventMouseButton eventMouse) {
                        string mouseButton = "";

                        switch (eventMouse.ButtonIndex) {
                            case MouseButton.Left:
                                mouseButton = $"InputEventMouseButton{InputEventSeparator}{(int)eventMouse.ButtonIndex}{InputEventSeparator}LMB";
                                break;
                            case MouseButton.Middle:
                                mouseButton = $"InputEventMouseButton{InputEventSeparator}{(int)eventMouse.ButtonIndex}{InputEventSeparator}MMB";
                                break;
                            case MouseButton.Right:
                                mouseButton = $"InputEventMouseButton{InputEventSeparator}{(int)eventMouse.ButtonIndex}{InputEventSeparator}RMB";
                                break;
                        }

                        KeybindingsEvents.Add(mouseButton);
                    }

                    if (inputEvent is InputEventJoypadMotion eventJoypadMotion) {

                        string joypadAxis = "";

                        switch (eventJoypadMotion.Axis) {
                            case JoyAxis.LeftX:
                                joypadAxis = $"InputEventJoypadMotion{InputEventSeparator}{eventJoypadMotion.Axis}{InputEventSeparator}{eventJoypadMotion.AxisValue}{InputEventSeparator}Left Stick {(eventJoypadMotion.AxisValue < 0 ? "Left" : "Right")}";
                                break;
                            case JoyAxis.LeftY:
                                joypadAxis = $"InputEventJoypadMotion{InputEventSeparator}{eventJoypadMotion.Axis}{InputEventSeparator}{eventJoypadMotion.AxisValue}{InputEventSeparator}Left Stick {(eventJoypadMotion.AxisValue < 0 ? "Up" : "Down")}";
                                break;
                            case JoyAxis.RightX:
                                joypadAxis = $"InputEventJoypadMotion{InputEventSeparator}{eventJoypadMotion.Axis}{InputEventSeparator}{eventJoypadMotion.AxisValue}{InputEventSeparator}Right Stick {(eventJoypadMotion.AxisValue < 0 ? "Left" : "Right")}";
                                break;
                            case JoyAxis.RightY:
                                joypadAxis = $"InputEventJoypadMotion{InputEventSeparator}{eventJoypadMotion.Axis}{InputEventSeparator}{eventJoypadMotion.AxisValue}{InputEventSeparator}Right Stick {(eventJoypadMotion.AxisValue < 0 ? "Up" : "Down")}";
                                break;
                            case JoyAxis.TriggerLeft:
                                joypadAxis = $"InputEventJoypadMotion{InputEventSeparator}{eventJoypadMotion.Axis}{InputEventSeparator}{eventJoypadMotion.AxisValue}{InputEventSeparator}Left Trigger";
                                break;
                            case JoyAxis.TriggerRight:
                                joypadAxis = $"InputEventJoypadMotion{InputEventSeparator}{eventJoypadMotion.Axis}{InputEventSeparator}{eventJoypadMotion.AxisValue}{InputEventSeparator}Right Trigger";
                                break;
                        }

                        KeybindingsEvents.Add(joypadAxis);
                    }

                    if (inputEvent is InputEventJoypadButton) {
                        if (inputEvent is InputEventJoypadButton eventJoypadButton) {
                            string joypadButton = "";

                            if (GamepadControllerManager.CurrentControllerIsXbox() || GamepadControllerManager.CurrentControllerIsGeneric())
                                joypadButton = $"InputEventJoypadButton{InputEventSeparator}{eventJoypadButton.ButtonIndex}{InputEventSeparator}{GamepadControllerManager.XboxButtonLabels[(int)eventJoypadButton.ButtonIndex]} Button";

                            else if (GamepadControllerManager.CurrentControllerIsSwitch() || GamepadControllerManager.CurrentControllerIsSwitchJoycon())
                                joypadButton = $"InputEventJoypadButton{InputEventSeparator}{eventJoypadButton.ButtonIndex}{InputEventSeparator}{GamepadControllerManager.SwitchButtonLabels[(int)eventJoypadButton.ButtonIndex]} Button";

                            else if (GamepadControllerManager.CurrentControllerIsPlaystation())
                                joypadButton = $"InputEventJoypadButton{InputEventSeparator}{eventJoypadButton.ButtonIndex}{InputEventSeparator}{GamepadControllerManager.PlaystationButtonLabels[(int)eventJoypadButton.ButtonIndex]} Button";

                            KeybindingsEvents.Add(joypadButton);
                        }
                    }
                }

                Keybindings[action] = string.Join(KeybindingsSeparator, KeybindingsEvents);
                ConfigFileApi.SetValue(KeybindingsSection, action, Keybindings[action]);
            }
        }

        public void CreateAudioSection(GameSettingsResource gameSettings) {
            foreach (string bus in AudioManager.EnumerateAvailableBuses())
                UpdateAudioSection(bus, gameSettings.AudioVolumes[bus.ToLower()]);

            UpdateAudioSection("muted", gameSettings.MutedAudio);
        }

        public void CreateGraphicsSection(GameSettingsResource gameSettings) {
            UpdateGraphicSection("fps_counter", gameSettings.FPSCounter);
            UpdateGraphicSection("max_fps", gameSettings.MaxFPS);
            UpdateGraphicSection("display", (int)gameSettings.DisplayMode);
            UpdateGraphicSection("resolution", DisplayServer.WindowGetSize());
            UpdateGraphicSection("vsync", (int)gameSettings.Vsync);
            UpdateGraphicSection("antialiasing_2d", (int)gameSettings.AntiaAliasing2D);
            UpdateGraphicSection("antialiasing_3d", (int)gameSettings.AntiaAliasing3D);
            UpdateGraphicSection("quality_preset", (int)gameSettings.CurrentQualityPreset);
        }

        public void CreateAccessibilitySection(GameSettingsResource gameSettings) {
            UpdateAccessibilitySection("controller_vibration", gameSettings.ControllerVibration);
            UpdateAccessibilitySection("screen_brightness", gameSettings.ScreenBrightness);
            UpdateAccessibilitySection("photosensitive", gameSettings.PhotoSensitive);
            UpdateAccessibilitySection("screenshake", gameSettings.ScreenShake);
            UpdateAccessibilitySection("daltonism", (int)gameSettings.DaltonismType);
        }
        #endregion

        public void CreateLocalizationSection(GameSettingsResource gameSettings) {
            UpdateLocalizationSection("current_language", Localization.AvailableLanguages[gameSettings.CurrentLanguage].IsoCode);
            UpdateLocalizationSection("voices_language", Localization.AvailableLanguages[gameSettings.VoicesLanguage].IsoCode);
            UpdateLocalizationSection("subtitles", gameSettings.SubtitlesEnabled);
            UpdateLocalizationSection("subtitles_language", Localization.AvailableLanguages[gameSettings.SubtitlesLanguage].IsoCode);
        }

        public void CreateAnalyticsSection(GameSettingsResource gameSettings) {
            ConfigFileApi.SetValue(AnalyticsSection, "allow_telemetry", gameSettings.AllowTelemetry);
        }


        #region Load settings
        public static void LoadKeybindings(ConfigFile configFile) {
            foreach (StringName action in configFile.GetSectionKeys(KeybindingsSection)) {
                var keybinding = configFile.GetValue(KeybindingsSection, action).ToString();

                InputMap.ActionEraseEvents(action);

                if (keybinding.Contains(KeybindingsSeparator)) {
                    foreach (string value in keybinding.Split(KeybindingsSeparator)) {
                        AddKeybindingEvent(action, value.Split(InputEventSeparator));
                    }
                }
                else {
                    AddKeybindingEvent(action, keybinding.Split(InputEventSeparator));
                }
            }
        }

        public static void LoadAudio(ConfigFile configFile) {
            bool mutedBuses = (bool)configFile.GetValue(AudioSection, "muted");

            foreach (string bus in configFile.GetSectionKeys(AudioSection)) {
                if (AudioManager.Instance.AvailableBuses.Contains(bus)) {
                    AudioManager.ChangeVolume(bus, (float)configFile.GetValue(AudioSection, bus));
                    AudioManager.MuteBus(bus, mutedBuses);
                }
            }

        }

        public void LoadGraphics(ConfigFile configFile) {
            foreach (string key in configFile.GetSectionKeys(GraphicsSection)) {
                var configValue = configFile.GetValue(GraphicsSection, key);

                switch (key) {
                    case "max_fps":
                        Engine.MaxFps = (int)configValue;
                        break;
                    case "display":
                        DisplayServer.WindowSetMode((DisplayServer.WindowMode)(int)configValue);
                        break;
                    case "resolution":
                        DisplayServer.WindowSetSize((Vector2I)configValue);
                        break;
                    case "vsync":
                        DisplayServer.WindowSetVsyncMode((DisplayServer.VSyncMode)(int)configValue);
                        break;
                    case "antialiasing_2d":
                        GetViewport().Msaa2D = (Viewport.Msaa)(int)configValue;
                        break;
                    case "antialiasing_3d":
                        GetViewport().Msaa3D = (Viewport.Msaa)(int)configValue;
                        break;
                }
            }
        }

        public void LoadLocalization(ConfigFile configFile) {
            foreach (string key in configFile.GetSectionKeys(LocalizationSection)) {
                var configValue = configFile.GetValue(LocalizationSection, key);

                switch (key) {
                    case "current_language":
                        TranslationServer.SetLocale(configValue.ToString());
                        GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.ChangedLanguage, configValue.ToString());
                        break;

                    case "subtitles_language":
                        // TODO - UPDATE WHEN SUBTITLES IMPLEMENTED
                        break;

                    case "voices_language":
                        // TODO - UPDATE WHEN VOICES IMPLEMENTED

                        break;
                }
            }
        }
        #endregion

        public void ResetToFactorySettings() {
            if (SettingsFileExists()) {
                ConfigFileApi.Clear();
                DirAccess.RemoveAbsolute(SettingsFilePath);
            }

            CreateSettingsFile();
            LoadSettingsFromFile();

            EmitSignal(SignalName.ResetToDefaultSettings);
        }

        public void SaveSettings() {
            ConfigFileApi.Save(SettingsFilePath);
        }

        #region Getters
        public Variant GetAudioSection(string key) => ConfigFileApi.GetValue(AudioSection, key);
        public Variant GetGraphicSection(string key) => ConfigFileApi.GetValue(GraphicsSection, key);
        public Variant GetAccessibilitySection(string key) => ConfigFileApi.GetValue(AccessibilitySection, key);
        public Variant GetAnalyticsSection(string key) => ConfigFileApi.GetValue(AnalyticsSection, key);
        public Variant GetLocalizationSection(string key) => ConfigFileApi.GetValue(LocalizationSection, key);

        #endregion

        #region Update
        public void UpdateAudioSection(string key, Variant value) {
            ConfigFileApi.SetValue(AudioSection, key, value);
        }

        public void UpdateGraphicSection(string key, Variant value) {
            ConfigFileApi.SetValue(GraphicsSection, key, value);

            if (key.EqualsIgnoreCase("quality_preset"))
                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.UpdatedGraphicSettings, value);
        }

        public void UpdateAccessibilitySection(string key, Variant value) {
            ConfigFileApi.SetValue(AccessibilitySection, key, value);
        }

        public void UpdateAnalyticsSection(string key, Variant value) {
            ConfigFileApi.SetValue(AnalyticsSection, key, value);
        }

        public void UpdateLocalizationSection(string key, Variant value) {
            ConfigFileApi.SetValue(LocalizationSection, key, value);

            if (key.EqualsIgnoreCase("current_language")) {
                TranslationServer.SetLocale(value.ToString());
                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.ChangedLanguage, value.ToString());
                GlobalGameEvents.UpdateAllTranslatables();
            }

            if (key.EqualsIgnoreCase("subtitles")) {
                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.ChangedSubtitlesDisplayOption, (bool)value);
            }
            if (key.EqualsIgnoreCase("subtitles_language")) {
                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.ChangedSubtitlesLanguage, value.ToString());
            }

            if (key.EqualsIgnoreCase("voices_language")) {
                GlobalGameEvents.EmitSignal(GlobalGameEvents.SignalName.ChangedVoiceLanguage, value.ToString());
            }
        }
        #endregion


        private static void AddKeybindingEvent(string action, string[] keybindingType) {

            switch (keybindingType[0]) {
                case "InputEventKey":

                    var inputEventKey = new InputEventKey {
                        Keycode = OS.FindKeycodeFromString(KeybindingModifiersRegex().Replace(keybindingType[1], "").StripEdges()),
                        AltPressed = !keybindingType[1].EqualsIgnoreCase("Alt") && keybindingType[1].Contains("Alt", System.StringComparison.OrdinalIgnoreCase),
                        CtrlPressed = !keybindingType[1].EqualsIgnoreCase("Ctrl") && keybindingType[1].Contains("Ctrl", System.StringComparison.OrdinalIgnoreCase),
                        ShiftPressed = !keybindingType[1].EqualsIgnoreCase("Shift") && keybindingType[1].Contains("Shift", System.StringComparison.OrdinalIgnoreCase),
                        MetaPressed = keybindingType[1].Contains("Meta", System.StringComparison.OrdinalIgnoreCase)
                    };

                    InputMap.ActionAddEvent(action, inputEventKey);

                    break;

                case "InputEventMouseButton":
                    var inputEventMouseButton = new InputEventMouseButton {
                        ButtonIndex = (MouseButton)keybindingType[1].ToInt()
                    };

                    InputMap.ActionAddEvent(action, inputEventMouseButton);

                    break;

                case "InputEventJoypadMotion":
                    var joypadMotion = new InputEventJoypadMotion {
                        Axis = (JoyAxis)keybindingType[1].ToInt(),
                        AxisValue = keybindingType[2].ToFloat()
                    };

                    InputMap.ActionAddEvent(action, joypadMotion);

                    break;

                case "InputEventJoypadButton":
                    var joypadButton = new InputEventJoypadButton {
                        ButtonIndex = (JoyButton)keybindingType[1].ToInt()
                    };

                    InputMap.ActionAddEvent(action, joypadButton);
                    break;
            }
        }


        private List<StringName> GetInputMapActions() {
            if (IncludeUIKeybindings)
                return [.. InputMap.GetActions()];
            else
                return InputMap.GetActions().Where((action) => !action.ToString().StartsWith("ui_")).ToList();
        }
        private bool SettingsFileExists() => FileAccess.FileExists(SettingsFilePath);

        [GeneratedRegex(@"\s+")]
        private static partial Regex WhiteSpaceRegex();

        [GeneratedRegex(@"\b(Shift|Ctrl|Alt)\+\b")]
        private static partial Regex KeybindingModifiersRegex();
    }
}