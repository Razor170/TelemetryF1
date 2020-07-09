using System;

namespace UPDPackets.Motion
{
    //[StructLayout(LayoutKind.Explicit, Pack = 0, Size = 60)]
    public class CarMotionData
    {
        public const int SIZE = 60;
        public float m_worldPositionX;           // World space X position
        public float m_worldPositionY;           // World space Y position
        public float m_worldPositionZ;           // World space Z position
        public float m_worldVelocityX;           // Velocity in world space X
        public float m_worldVelocityY;           // Velocity in world space Y
        public float m_worldVelocityZ;           // Velocity in world space Z
        public short m_worldForwardDirX;         // World space forward X direction (normalised)
        public short m_worldForwardDirY;         // World space forward Y direction (normalised)
        public short m_worldForwardDirZ;         // World space forward Z direction (normalised)
        public short m_worldRightDirX;           // World space right X direction (normalised)
        public short m_worldRightDirY;           // World space right Y direction (normalised)
        public short m_worldRightDirZ;           // World space right Z direction (normalised)
        public float m_gForceLateral;            // Lateral G-Force component
        public float m_gForceLongitudinal;       // Longitudinal G-Force component
        public float m_gForceVertical;           // Vertical G-Force component
        public float m_yaw;                      // Yaw angle in radians
        public float m_pitch;                    // Pitch angle in radians
        public float m_roll;                     // Roll angle in radians

        public CarMotionData(byte[] bytes)
        {
            m_worldPositionX = BitConverter.ToSingle(bytes, 0);
            m_worldPositionY = BitConverter.ToSingle(bytes, 4);
            m_worldPositionZ = BitConverter.ToSingle(bytes, 8);
            m_worldVelocityX = BitConverter.ToSingle(bytes, 12);
            m_worldVelocityY = BitConverter.ToSingle(bytes, 16);
            m_worldVelocityZ = BitConverter.ToSingle(bytes, 20);

            m_worldForwardDirX = BitConverter.ToInt16(bytes, 24);
            m_worldForwardDirY = BitConverter.ToInt16(bytes, 26);
            m_worldForwardDirZ = BitConverter.ToInt16(bytes, 28);
            m_worldRightDirX = BitConverter.ToInt16(bytes, 30);
            m_worldRightDirY = BitConverter.ToInt16(bytes, 32);
            m_worldRightDirZ = BitConverter.ToInt16(bytes, 34);

            m_gForceLateral = BitConverter.ToSingle(bytes, 36);
            m_gForceLongitudinal = BitConverter.ToSingle(bytes, 40);
            m_gForceVertical = BitConverter.ToSingle(bytes, 44);
            m_yaw = BitConverter.ToSingle(bytes, 48);
            m_pitch = BitConverter.ToSingle(bytes, 52);
            m_roll = BitConverter.ToSingle(bytes, 56);
        }
    }
}