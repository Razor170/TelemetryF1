using System;

namespace TelemetryF1.Packets.CarTelemetry
{
    public class CarTelemetryData
    {
        public const int SIZE = 66;
        public ushort m_speed;                         // Speed of car in kilometres per hour
        public float m_throttle;                      // Amount of throttle applied (0.0 to 1.0)
        public float m_steer;                         // Steering (-1.0 (full lock left) to 1.0 (full lock right))
        public float m_brake;                         // Amount of brake applied (0.0 to 1.0)
        public byte m_clutch;                        // Amount of clutch applied (0 to 100)
        public sbyte m_gear;                          // Gear selected (1-8, N=0, R=-1)
        public ushort m_engineRPM;                     // Engine RPM
        public byte m_drs;                           // 0 = off, 1 = on
        public byte m_revLightsPercent;              // Rev lights indicator (percentage)
        public ushort[] m_brakesTemperature;          // Brakes temperature (celsius)
        public ushort[] m_tyresSurfaceTemperature;    // Tyres surface temperature (celsius)
        public ushort[] m_tyresInnerTemperature;      // Tyres inner temperature (celsius)
        public ushort m_engineTemperature;             // Engine temperature (celsius)
        public float[] m_tyresPressure;              // Tyres pressure (PSI)
        public byte[] m_surfaceType;                // Driving surface, see appendices

        public CarTelemetryData(byte[] bytes)
        {
            m_speed = BitConverter.ToUInt16(bytes, 0);
            m_throttle = BitConverter.ToSingle(bytes, 2);
            m_steer = BitConverter.ToSingle(bytes, 6);
            m_brake = BitConverter.ToSingle(bytes, 10);
            m_clutch = bytes[14];
            m_gear = (sbyte)BitConverter.ToChar(bytes, 15);
            m_engineRPM = BitConverter.ToUInt16(bytes, 16);
            m_drs = bytes[18];
            m_revLightsPercent = bytes[19];

            m_brakesTemperature = new ushort[4];
            Buffer.BlockCopy(bytes, 20, m_brakesTemperature, 0, 8);
            
            m_tyresSurfaceTemperature = new ushort[4];
            Buffer.BlockCopy(bytes, 28, m_tyresSurfaceTemperature, 0, 8);

            m_tyresInnerTemperature = new ushort[4];
            Buffer.BlockCopy(bytes, 36, m_tyresInnerTemperature, 0, 8);

            m_engineTemperature = BitConverter.ToUInt16(bytes, 44);
            
            m_tyresPressure = new float[4];
            Buffer.BlockCopy(bytes, 46, m_tyresPressure, 0, 16);

            m_surfaceType = new byte[4];
            Buffer.BlockCopy(bytes, 62, m_surfaceType, 0, 4);
        }
    }
}