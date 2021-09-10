using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Scripting;

namespace UniSense
{
    [Preserve]
    public struct DualSenseGamepadState
    {
        public Color? LightBarColor;
        public DualSenseMotorSpeed? Motor;
        public DualSenseMicLedState? MicLed;

        public DualSenseTriggerState? RightTrigger;
        public DualSenseTriggerState? LeftTrigger;

        public PlayerLedBrightness? PlayerLedBrightness;
        public PlayerLedState? PlayerLed;
    }

    [Preserve]
    public struct DualSenseMotorSpeed
    {
        public float LowFrequencyMotorSpeed;
        public float HighFrequenceyMotorSpeed;

        public DualSenseMotorSpeed(float lowFrequencyMotorSpeed, float highFrequenceyMotorSpeed)
        {
            LowFrequencyMotorSpeed = lowFrequencyMotorSpeed;
            HighFrequenceyMotorSpeed = highFrequenceyMotorSpeed;
        }
    }

    [Preserve]
    public enum DualSenseMicLedState
    {
        Off,
        On,
        Pulsating,
    }

    [Preserve]
    public enum DualSenseTriggerEffectType : byte
    {
        NoResistance = 0,
        ContinuousResistance,
        SectionResistance,
        EffectEx,
        Calibrate,
    }

    [Preserve, StructLayout(LayoutKind.Explicit)]
    public struct DualSenseTriggerState
    {
        [FieldOffset(0)] public DualSenseTriggerEffectType EffectType;

        [FieldOffset(1)] public DualSenseContinuousResistanceProperties Continuous;
        [FieldOffset(1)] public DualSenseSectionResistanceProperties Section;
        [FieldOffset(1)] public DualSenseEffectExProperties EffectEx;
    }

    [Preserve]
    public struct DualSenseContinuousResistanceProperties
    {
        public byte StartPosition;
        public byte Force;
    }

    [Preserve]
    public struct DualSenseSectionResistanceProperties
    {
        public byte StartPosition;
        public byte EndPosition;
        public byte Force;
    }

    [Preserve]
    public struct DualSenseEffectExProperties
    {
        public byte StartPosition;
        public bool KeepEffect;
        public byte BeginForce;
        public byte MiddleForce;
        public byte EndForce;
        public byte Frequency;
    }

    [Preserve]
    public enum PlayerLedBrightness
    {
        High,
        Medium,
        Low,
    }

    [Preserve]
    public struct PlayerLedState
    {
        private const byte LED1 = 0x10;
        private const byte LED2 = 0x08;
        private const byte LED3 = 0x04;
        private const byte LED4 = 0x02;
        private const byte LED5 = 0x01;
        private const byte LED_MASK = LED1 | LED2 | LED3 | LED4 | LED5;

        private const byte FADE = 0x40;

        public byte Value { get; private set; }

        public PlayerLedState(bool led1, bool led2, bool led3, bool led4, bool led5, bool fade = true)
        {
            Value = 0;
            if (led1) Value |= LED1;
            if (led2) Value |= LED2;
            if (led3) Value |= LED3;
            if (led4) Value |= LED4;
            if (led5) Value |= LED5;
            if (fade) Value |= FADE;
        }

        public PlayerLedState(byte led, bool fade = false)
        {
            Value = (byte)(led & LED_MASK);
            if (fade) Value |= FADE;
        }
    }
}