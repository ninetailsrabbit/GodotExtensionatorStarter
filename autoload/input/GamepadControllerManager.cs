using Extensionator;
using Godot;
using Godot.Collections;

namespace GodotExtensionatorStarter {

    public sealed partial class GamepadControllerManager : Node {

        #region Events
        public delegate void ControllerConnectedEventHandler(long device, string controllerName);
        public event ControllerConnectedEventHandler? ControllerConnected;

        public delegate void ControllerDisconnectedEventHandler(long device, string previousControllerName, string controllerName);
        public event ControllerDisconnectedEventHandler? ControllerDisconnected;
        #endregion

        public const float DefaultVibrationStrength = 0.5f;
        public const float DefaultVibrationDuration = 0.65f;

        public const string DeviceGeneric = "generic";
        public const string DeviceKeyboard = "keyboard";
        public const string DeviceXboxController = "xbox";
        public const string DeviceSwitchController = "switch";
        public const string DeviceSwitchJoyConLeftController = "switch_left_joycon";
        public const string DeviceSwitchJoyConRightController = "switch_right_joycon";
        public const string DevicePlaystationController = "playstation";
        public const string DeviceLunaController = "luna";

        public static readonly string[] XboxButtonLabels = ["A", "B", "X", "Y", "Back", "Home", "Menu", "Left Stick", "Right Stick", "Left Shoulder", "Right Shoulder", "Up", "Down", "Left", "Right", "Share"];
        public static readonly string[] SwitchButtonLabels = ["B", "A", "Y", "X", "-", "", "+", "Left Stick", "Right Stick", "Left Shoulder", "Right Shoulder", "Up", "Down", "Left", "Right", "Capture"];
        public static readonly string[] PlaystationButtonLabels = ["Cross", "Circle", "Square", "Triangle", "Select", "PS", "Options", "L3", "R3", "L1", "R1", "Up", "Down", "Left", "Right", "Microphone"];

        public string CurrentControllerGUID = "";
        public string CurrentControllerName = DeviceKeyboard;
        public int CurrentDeviceId = 0;
        public bool Connected = false;

        public override void _Notification(int what) {
            if (what == NotificationPredelete)
                Input.StopJoyVibration(CurrentDeviceId);
        }

        public override void _EnterTree() {
            Input.JoyConnectionChanged += OnJoyConnectionChanged;
        }

        public static bool HasJoypads() => Joypads().Count > 0;

        public static Array<int> Joypads() => Input.GetConnectedJoypads();

        public void StartControllerVibration(float weakStrength = DefaultVibrationStrength, float strongStrength = DefaultVibrationStrength, float duration = DefaultVibrationDuration) {
            if (!CurrentControllerIsKeyboard() && HasJoypads())
                Input.StartJoyVibration(CurrentDeviceId, weakStrength, strongStrength, duration);
        }

        public void StopControllerVibration(float weakStrength = DefaultVibrationStrength, float strongStrength = DefaultVibrationStrength, float duration = DefaultVibrationDuration) {
            if (!CurrentControllerIsKeyboard() && HasJoypads())
                Input.StopJoyVibration(CurrentDeviceId);
        }

        public void UpdateCurrentController(int device, string controllerName) {
            // https://github.com/mdqinc/SDL_GameControllerDB
            CurrentControllerGUID = Input.GetJoyGuid(device);
            CurrentDeviceId = device;

            CurrentControllerName = controllerName switch {
                "Luna Controller" => DeviceLunaController,
                "XInput Gamepad" or "Xbox Series Controller" or "Xbox 360 Controller" or "Xbox One Controller" => DeviceXboxController,
                "Sony DualSense" or "Nacon Revolution Unlimited Pro Controller" or "PS3 Controller" or "PS4 Controller" or "PS5 Controller" => DevicePlaystationController,
                "Steam Virtual Gamepad" => DeviceGeneric,
                "Switch" or "Switch Controller" or "Nintendo Switch Pro Controller" or "Faceoff Deluxe Wired Pro Controller for Nintendo Switch" => DeviceSwitchController,
                "Joy-Con (L)" => DeviceSwitchJoyConLeftController,
                "Joy-Con (R)" => DeviceSwitchJoyConRightController,
                _ => DeviceKeyboard,
            };
        }

        public bool CurrentControllerIsKeyboard() => CurrentControllerName.EqualsIgnoreCase(DeviceKeyboard);
        public bool CurrentControllerIsGeneric() => CurrentControllerName.EqualsIgnoreCase(DeviceGeneric);
        public bool CurrentControllerIsLuna() => CurrentControllerName.EqualsIgnoreCase(DeviceLunaController);
        public bool CurrentControllerIsPlaystation() => CurrentControllerName.EqualsIgnoreCase(DevicePlaystationController);
        public bool CurrentControllerIsXbox() => CurrentControllerName.EqualsIgnoreCase(DeviceXboxController);
        public bool CurrentControllerIsSwitch() => CurrentControllerName.EqualsIgnoreCase(DeviceSwitchController);
        public bool CurrentControllerIsSwitchJoycon() => CurrentControllerIsSwitchJoyconRight() || CurrentControllerIsSwitchJoyconLeft();
        public bool CurrentControllerIsSwitchJoyconLeft() => CurrentControllerName.EqualsIgnoreCase(DeviceSwitchJoyConLeftController);
        public bool CurrentControllerIsSwitchJoyconRight() => CurrentControllerName.EqualsIgnoreCase(DeviceSwitchJoyConRightController);

        private void OnJoyConnectionChanged(long device, bool connected) {
            string previousControllerName = CurrentControllerName;

            UpdateCurrentController((int)device, connected ? Input.GetJoyName((int)device) : "");

            if (connected)
                ControllerConnected?.Invoke(device, CurrentControllerName);
            else
                ControllerDisconnected?.Invoke(device, previousControllerName, CurrentControllerName);
        }
    }
}