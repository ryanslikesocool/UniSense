using System.Runtime.InteropServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace UniSense.LowLevel
{
    [StructLayout(LayoutKind.Explicit, Size = 64)]
    internal struct DualSenseHIDInputReport : IInputStateTypeInfo
    {
        public FourCC format => new FourCC('H', 'I', 'D');

        public byte reportId;

        [InputControl(name = "leftStick", offset = 1, layout = "Stick", format = "VC2B")]
        [InputControl(name = "leftStick/x", format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
        [InputControl(name = "leftStick/left", format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
        [InputControl(name = "leftStick/right", format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1")]
        [InputControl(name = "leftStick/y", offset = 1, format = "BYTE", parameters = "invert,normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
        [InputControl(name = "leftStick/up", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
        [InputControl(name = "leftStick/down", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1,invert=false")]
        public byte leftStickX;
        public byte leftStickY;

        [InputControl(name = "rightStick", offset = 3, layout = "Stick", format = "VC2B")]
        [InputControl(name = "rightStick/x", format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
        [InputControl(name = "rightStick/left", format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
        [InputControl(name = "rightStick/right", format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1")]
        [InputControl(name = "rightStick/y", offset = 1, format = "BYTE", parameters = "invert,normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
        [InputControl(name = "rightStick/up", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
        [InputControl(name = "rightStick/down", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1,invert=false")]
        public byte rightStickX;
        public byte rightStickY;

        [InputControl(offset = 5, format = "BYTE")]
        public ButtonControl leftTrigger;

        [InputControl(offset = 6, format = "BYTE")]
        public ButtonControl rightTrigger;

        [InputControl(name = "dpad", offset = 8, format = "BIT", layout = "Dpad", sizeInBits = 4, defaultState = 8)]
        [InputControl(name = "dpad/up", format = "BIT", layout = "DiscreteButton", parameters = "minValue=7,maxValue=1,nullValue=8,wrapAtValue=7", bit = 0, sizeInBits = 4)]
        [InputControl(name = "dpad/right", format = "BIT", layout = "DiscreteButton", parameters = "minValue=1,maxValue=3", bit = 0, sizeInBits = 4)]
        [InputControl(name = "dpad/down", format = "BIT", layout = "DiscreteButton", parameters = "minValue=3,maxValue=5", bit = 0, sizeInBits = 4)]
        [InputControl(name = "dpad/left", format = "BIT", layout = "DiscreteButton", parameters = "minValue=5, maxValue=7", bit = 0, sizeInBits = 4)]
        [InputControl(name = "buttonWest", offset = 8, displayName = "Square", bit = 4)]
        [InputControl(name = "buttonSouth", offset = 8, displayName = "Cross", bit = 5)]
        [InputControl(name = "buttonEast", offset = 8, displayName = "Circle", bit = 6)]
        [InputControl(name = "buttonNorth", offset = 8, displayName = "Triangle", bit = 7)]
        public byte buttons1;

        [InputControl(name = "leftShoulder", offset = 9, bit = 0)]
        [InputControl(name = "rightShoulder", offset = 9, bit = 1)]
        [InputControl(name = "leftTriggerButton", offset = 9, layout = "Button", bit = 2)]
        [InputControl(name = "rightTriggerButton", offset = 9, layout = "Button", bit = 3)]
        [InputControl(name = "select", offset = 9, displayName = "Share", bit = 4)]
        [InputControl(name = "start", offset = 9, displayName
        = "Options", bit = 5)]
        [InputControl(name = "leftStickPress", offset = 9, bit = 6)]
        [InputControl(name = "rightStickPress", offset = 9, bit = 7)]
        public byte buttons2;


        [InputControl(name = "systemButton", offset = 10, layout = "Button", displayName = "System", bit = 0)]
        [InputControl(name = "touchpadButton", offset = 10, layout = "Button", displayName = "Touchpad Press", bit = 1)]
        [InputControl(name = "micMuteButton", offset = 10, layout = "Button", displayName = "Mic Mute", bit = 2)]
        public byte buttons3;

        [InputControl(name = "gyro", offset = 16, format = "VC3S", layout = "Vector3")]
        [InputControl(name = "gyro/x", layout = "Axis", format = "SHRT")]
        [InputControl(name = "gyro/y", offset = 2, layout = "Axis", format = "SHRT")]
        [InputControl(name = "gyro/z", offset = 4, layout = "Axis", format = "SHRT")]
        public short gyroPitch;
        public short gyroYaw;
        public short gyroRoll;

        [InputControl(name = "accel", offset = 22, format = "VC3S", layout = "Vector3")]
        [InputControl(name = "accel/x", layout = "Axis", format = "SHRT")]
        [InputControl(name = "accel/y", offset = 2, layout = "Axis", format = "SHRT")]
        [InputControl(name = "accel/z", offset = 4, layout = "Axis", format = "SHRT")]
        public short accelX;
        public short accelY;
        public short accelZ;

        [InputControl(name = "batteryCharging", offset = 54, layout = "Button", displayName = "Battery is Charging", bit = 3)]
        public byte batteryInfo1;

        [InputControl(name = "batteryFullyCharged", offset = 55, layout = "Button", displayName = "Battery is Fully Charged", bit = 5)]
        [InputControl(name = "batteryLevel", offset = 55, layout = "Axis", format = "BIT", displayName = "Battery Level", bit = 0, sizeInBits = 4, parameters = "normalize,normalizeMin=0,normalizeMax=1")]
        public byte batteryInfo2;
    }
}
