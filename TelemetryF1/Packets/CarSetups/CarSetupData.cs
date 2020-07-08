using System;

namespace TelemetryF1.Packets.CarSetups
{
    public class CarSetupData
    {
        public const int SIZE = 49;
        public byte m_frontWing;                // Front wing aero
        public byte m_rearWing;                 // Rear wing aero
        public byte m_onThrottle;               // Differential adjustment on throttle (percentage)
        public byte m_offThrottle;              // Differential adjustment off throttle (percentage)
        public float m_frontCamber;              // Front camber angle (suspension geometry)
        public float m_rearCamber;               // Rear camber angle (suspension geometry)
        public float m_frontToe;                 // Front toe angle (suspension geometry)
        public float m_rearToe;                  // Rear toe angle (suspension geometry)
        public byte m_frontSuspension;          // Front suspension
        public byte m_rearSuspension;           // Rear suspension
        public byte m_frontAntiRollBar;         // Front anti-roll bar
        public byte m_rearAntiRollBar;          // Front anti-roll bar
        public byte m_frontSuspensionHeight;    // Front ride height
        public byte m_rearSuspensionHeight;     // Rear ride height
        public byte m_brakePressure;            // Brake pressure (percentage)
        public byte m_brakeBias;                // Brake bias (percentage)
        public float m_rearLeftTyrePressure;     // Rear left tyre pressure (PSI)
        public float m_rearRightTyrePressure;    // Rear right tyre pressure (PSI)
        public float m_frontLeftTyrePressure;    // Front left tyre pressure (PSI)
        public float m_frontRightTyrePressure;   // Front right tyre pressure (PSI)
        public byte m_ballast;                  // Ballast
        public float m_fuelLoad;                 // Fuel load

        public CarSetupData(byte[] bytes)
        {
            m_frontWing = bytes[0];
            m_rearWing = bytes[1];
            m_onThrottle = bytes[2];
            m_offThrottle = bytes[3];

            m_frontCamber = BitConverter.ToSingle(bytes, 4);
            m_rearCamber = BitConverter.ToSingle(bytes, 8);
            m_frontToe = BitConverter.ToSingle(bytes, 12);
            m_rearToe = BitConverter.ToSingle(bytes, 16);

            m_frontSuspension = bytes[20];
            m_rearSuspension = bytes[21];
            m_frontAntiRollBar = bytes[22];
            m_rearAntiRollBar = bytes[23];
            m_frontSuspensionHeight = bytes[24];
            m_rearSuspensionHeight = bytes[25];
            m_brakePressure = bytes[26];
            m_brakeBias = bytes[27];

            m_rearLeftTyrePressure = BitConverter.ToSingle(bytes, 28);
            m_rearRightTyrePressure = BitConverter.ToSingle(bytes, 32);
            m_frontLeftTyrePressure = BitConverter.ToSingle(bytes, 36);
            m_frontRightTyrePressure = BitConverter.ToSingle(bytes, 40);

            m_ballast = bytes[44];
            m_fuelLoad = BitConverter.ToSingle(bytes, 45);
        }
    }
}