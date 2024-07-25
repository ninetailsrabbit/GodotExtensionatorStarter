﻿using Extensionator;
using Godot;
using Godot.Collections;
using GodotExtensionator;
using System.Collections.Generic;
using System.Linq;

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

        public const string KEYBINDINGS_SECTION = "keybindings";
        public const string GRAPHICS_SECTION = "graphics";
        public const string AUDIO_SECTION = "audio";
        public const string ACCESSIBILITY_SECTION = "accessibility";
        public const string LOCALIZATION_SECTION = "localization";
        public const string ANALYTICS_SECTION = "analytics";

        public const string KEYBINDING_SEPARATOR = "|";
        public const string INPUT_EVENT_SEPARATOR = ":";

        public const string FILE_FORMAT = "ini"; //  ini or cfg

        public string SettingsFilePath = $"{OS.GetUserDataDir()}/settings.{FILE_FORMAT}";
        public bool IncludeUIKeybindings = false;

        public ConfigFile ConfigFileApi = new();
        public GameSettingsResource DefaultGameSettings = new();

        public GamepadControllerManager GamepadControllerManager { get; set; } = default!;

        public override void _Ready() {
            GamepadControllerManager = this.GetAutoloadNode<GamepadControllerManager>();

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
            SettingsFilePath = $"{OS.GetUserDataDir()}/settings.{FILE_FORMAT}";

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

            EmitSignal(SignalName.LoadedSettings);
        }

        public void CreateSettingsFile(GameSettingsResource? gameSettings = null) {
            gameSettings ??= DefaultGameSettings;

            CreateKeybindingsSection();
            CreateGraphicsSection(gameSettings);
            CreateAudioSection(gameSettings);
            CreateAccessibilitySection(gameSettings);
            CreateAnalyticsSection(gameSettings);

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
                        KeybindingsEvents.Add($"InputEventKey:{InputExtension.ReadableKey(eventKey)}");

                    if (inputEvent is InputEventMouseButton eventMouse) {
                        string mouseButton = "";

                        switch (eventMouse.ButtonIndex) {
                            case MouseButton.Left:
                                mouseButton = $"InputEventMouseButton{INPUT_EVENT_SEPARATOR}{eventMouse.ButtonIndex}{INPUT_EVENT_SEPARATOR}LMB";
                                break;
                            case MouseButton.Middle:
                                mouseButton = $"InputEventMouseButton{INPUT_EVENT_SEPARATOR}{eventMouse.ButtonIndex}{INPUT_EVENT_SEPARATOR}MMB";
                                break;
                            case MouseButton.Right:
                                mouseButton = $"InputEventMouseButton{INPUT_EVENT_SEPARATOR}{eventMouse.ButtonIndex}{INPUT_EVENT_SEPARATOR}RMB";
                                break;
                        }

                        KeybindingsEvents.Add(mouseButton);
                    }

                    if (inputEvent is InputEventJoypadMotion eventJoypadMotion) {

                        string joypadAxis = "";

                        switch (eventJoypadMotion.Axis) {
                            case JoyAxis.LeftX:
                                joypadAxis = $"InputEventJoypadMotion{INPUT_EVENT_SEPARATOR}{eventJoypadMotion.Axis}{INPUT_EVENT_SEPARATOR}{eventJoypadMotion.AxisValue}{INPUT_EVENT_SEPARATOR}Left Stick {(eventJoypadMotion.AxisValue < 0 ? "Left" : "Right")}";
                                break;
                            case JoyAxis.LeftY:
                                joypadAxis = $"InputEventJoypadMotion{INPUT_EVENT_SEPARATOR}{eventJoypadMotion.Axis}{INPUT_EVENT_SEPARATOR}{eventJoypadMotion.AxisValue}{INPUT_EVENT_SEPARATOR}Left Stick {(eventJoypadMotion.AxisValue < 0 ? "Up" : "Down")}";
                                break;
                            case JoyAxis.RightX:
                                joypadAxis = $"InputEventJoypadMotion{INPUT_EVENT_SEPARATOR}{eventJoypadMotion.Axis}{INPUT_EVENT_SEPARATOR}{eventJoypadMotion.AxisValue}{INPUT_EVENT_SEPARATOR}Right Stick {(eventJoypadMotion.AxisValue < 0 ? "Left" : "Right")}";
                                break;
                            case JoyAxis.RightY:
                                joypadAxis = $"InputEventJoypadMotion{INPUT_EVENT_SEPARATOR}{eventJoypadMotion.Axis}{INPUT_EVENT_SEPARATOR}{eventJoypadMotion.AxisValue}{INPUT_EVENT_SEPARATOR}Right Stick {(eventJoypadMotion.AxisValue < 0 ? "Up" : "Down")}";
                                break;
                            case JoyAxis.TriggerLeft:
                                joypadAxis = $"InputEventJoypadMotion{INPUT_EVENT_SEPARATOR}{eventJoypadMotion.Axis}{INPUT_EVENT_SEPARATOR}{eventJoypadMotion.AxisValue}{INPUT_EVENT_SEPARATOR}Left Trigger";
                                break;
                            case JoyAxis.TriggerRight:
                                joypadAxis = $"InputEventJoypadMotion{INPUT_EVENT_SEPARATOR}{eventJoypadMotion.Axis}{INPUT_EVENT_SEPARATOR}{eventJoypadMotion.AxisValue}{INPUT_EVENT_SEPARATOR}Right Trigger";
                                break;
                        }

                        KeybindingsEvents.Add(joypadAxis);
                    }

                    if (inputEvent is InputEventJoypadButton) {
                        if (inputEvent is InputEventJoypadButton eventJoypadButton) {
                            string joypadButton = "";

                            if (GamepadControllerManager.CurrentControllerIsXbox() || GamepadControllerManager.CurrentControllerIsGeneric())
                                joypadButton = $"InputEventJoypadButton{INPUT_EVENT_SEPARATOR}{eventJoypadButton.ButtonIndex}{INPUT_EVENT_SEPARATOR}{GamepadControllerManager.XBOX_BUTTON_LABELS[(int)eventJoypadButton.ButtonIndex]} Button";

                            else if (GamepadControllerManager.CurrentControllerIsSwitch() || GamepadControllerManager.CurrentControllerIsSwitchJoycon())
                                joypadButton = $"InputEventJoypadButton{INPUT_EVENT_SEPARATOR}{eventJoypadButton.ButtonIndex}{INPUT_EVENT_SEPARATOR}{GamepadControllerManager.SWITCH_BUTTON_LABELS[(int)eventJoypadButton.ButtonIndex]} Button";

                            else if (GamepadControllerManager.CurrentControllerIsPlaystation())
                                joypadButton = $"InputEventJoypadButton{INPUT_EVENT_SEPARATOR}{eventJoypadButton.ButtonIndex}{INPUT_EVENT_SEPARATOR}{GamepadControllerManager.PLAYSTATION_BUTTON_LABELS[(int)eventJoypadButton.ButtonIndex]} Button";

                            KeybindingsEvents.Add(joypadButton);
                        }
                    }
                }

                Keybindings[action] = string.Join(KEYBINDING_SEPARATOR, KeybindingsEvents);
                ConfigFileApi.SetValue(KEYBINDINGS_SECTION, action, Keybindings[action]);
            }
        }

        public void CreateAudioSection(GameSettingsResource gameSettings) {
            foreach (string bus in AudioManager.EnumerateAvailableBuses())
                UpdateAudioSection(bus, gameSettings.AudioVolumes[bus.ToLower()]);

            UpdateAudioSection("muted", gameSettings.MutedAudio);
        }

        public void CreateGraphicsSection(GameSettingsResource gameSettings) {
            ConfigFileApi.SetValue(GRAPHICS_SECTION, "fps_counter", gameSettings.FPSCounter);
            ConfigFileApi.SetValue(GRAPHICS_SECTION, "max_fps", gameSettings.MaxFPS);
            ConfigFileApi.SetValue(GRAPHICS_SECTION, "display", (int)DisplayServer.WindowGetMode());
            ConfigFileApi.SetValue(GRAPHICS_SECTION, "resolution", DisplayServer.WindowGetSize());
            ConfigFileApi.SetValue(GRAPHICS_SECTION, "vsync", (int)DisplayServer.WindowGetVsyncMode());
            ConfigFileApi.SetValue(GRAPHICS_SECTION, "antialiasing_2d", (int)GetViewport().Msaa2D);
            ConfigFileApi.SetValue(GRAPHICS_SECTION, "antialiasing_3d", (int)GetViewport().Msaa3D);

            ConfigFileApi.SetValue(GRAPHICS_SECTION, "Quality_preset", gameSettings.CurrentQualityPreset.ToString());
        }

        public void CreateAccessibilitySection(GameSettingsResource gameSettings) {
            ConfigFileApi.SetValue(ACCESSIBILITY_SECTION, "mouse_sensitivity", gameSettings.MouseSensitivity);
            ConfigFileApi.SetValue(ACCESSIBILITY_SECTION, "controller_vibration", gameSettings.ControllerVibration);
            ConfigFileApi.SetValue(ACCESSIBILITY_SECTION, "screen_brightness", gameSettings.ScreenBrightness);
            ConfigFileApi.SetValue(ACCESSIBILITY_SECTION, "photosensitive", gameSettings.PhotoSensitive);
            ConfigFileApi.SetValue(ACCESSIBILITY_SECTION, "screenshake", gameSettings.ScreenShake);
        }
        #endregion

        public void UpdateLocalization(GameSettingsResource gameSettings) {
            ConfigFileApi.SetValue(LOCALIZATION_SECTION, "current_language", (int)gameSettings.CurrentLanguage);
        }

        public void CreateAnalyticsSection(GameSettingsResource gameSettings) {
            ConfigFileApi.SetValue(ANALYTICS_SECTION, "allow_telemetry", gameSettings.AllowTelemetry);
        }


        #region Load settings
        public static void LoadKeybindings(ConfigFile configFile) {
            foreach (StringName action in configFile.GetSectionKeys(KEYBINDINGS_SECTION)) {
                var keybinding = configFile.GetValue(KEYBINDINGS_SECTION, action).ToString();

                InputMap.ActionEraseEvents(action);

                if (keybinding.Contains(KEYBINDING_SEPARATOR)) {
                    foreach (string value in keybinding.Split(KEYBINDING_SEPARATOR)) {
                        AddKeybindingEvent(action, value.Split(INPUT_EVENT_SEPARATOR));
                    }
                }
                else {
                    AddKeybindingEvent(action, keybinding.Split(INPUT_EVENT_SEPARATOR));
                }
            }
        }

        public static void LoadAudio(ConfigFile configFile) {
            bool mutedBuses = (bool)configFile.GetValue(AUDIO_SECTION, "muted");

            foreach (string bus in configFile.GetSectionKeys(AUDIO_SECTION)) {
                if (AudioManager.Instance.AvailableBuses.Contains(bus)) {
                    AudioManager.ChangeVolume(bus, (float)configFile.GetValue(AUDIO_SECTION, bus));
                    AudioManager.MuteBus(bus, mutedBuses);
                }
            }

        }

        public void LoadGraphics(ConfigFile configFile) {
            foreach (string key in configFile.GetSectionKeys(GRAPHICS_SECTION)) {
                var configValue = configFile.GetValue(GRAPHICS_SECTION, key);

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

        #endregion

        private static void AddKeybindingEvent(string action, string[] keybindingType) {
            switch (keybindingType[0]) {
                case "InputEventKey":

                    var inputEventKey = new InputEventKey {
                        Keycode = OS.FindKeycodeFromString(keybindingType[1]),
                        AltPressed = keybindingType[1].Contains("Alt", System.StringComparison.OrdinalIgnoreCase),
                        CtrlPressed = keybindingType[1].Contains("Ctrl", System.StringComparison.OrdinalIgnoreCase),
                        ShiftPressed = keybindingType[1].Contains("Shift", System.StringComparison.OrdinalIgnoreCase),
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

        public void ResetToFactorySettings() {
            if(SettingsFileExists()) {
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

        public void UpdateAudioSection(string key, Variant value) {
            ConfigFileApi.SetValue(AUDIO_SECTION, key, value);
        }

        private bool SettingsFileExists() => FileAccess.FileExists(SettingsFilePath);
    }
}