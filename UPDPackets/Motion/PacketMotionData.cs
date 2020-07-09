using System;

namespace UPDPackets.Motion
{
    public class PacketMotionData : Packet
    {
        public CarMotionData[] m_carMotionData;      // Data for all cars on track

        // Extra player car ONLY data
        public float[] m_suspensionPosition;      // Note: All wheel arrays have the following order:
        public float[] m_suspensionVelocity;      // RL, RR, FL, FR
        public float[] m_suspensionAcceleration;  // RL, RR, FL, FR
        public float[] m_wheelSpeed;              // Speed of each wheel
        public float[] m_wheelSlip;               // Slip ratio for each wheel
        public float m_localVelocityX;             // Velocity in local space
        public float m_localVelocityY;             // Velocity in local space
        public float m_localVelocityZ;             // Velocity in local space
        public float m_angularVelocityX;           // Angular velocity x-component
        public float m_angularVelocityY;           // Angular velocity y-component
        public float m_angularVelocityZ;           // Angular velocity z-component
        public float m_angularAccelerationX;       // Angular velocity x-component
        public float m_angularAccelerationY;       // Angular velocity y-component
        public float m_angularAccelerationZ;       // Angular velocity z-component
        public float m_frontWheelsAngle;           // Current front wheels angle in radians

        public PacketMotionData(byte[] bytes) : base(bytes[..PacketHeader.SIZE])
        {
            bytes = bytes[PacketHeader.SIZE..];

            m_carMotionData = new CarMotionData[22];

            for (int i = 0; i < 22; i++)
            {
                m_carMotionData[i] = new CarMotionData(bytes[..CarMotionData.SIZE]);

                bytes = bytes[CarMotionData.SIZE..];
            }

            m_suspensionPosition = new float[4];
            Buffer.BlockCopy(bytes, 0, m_suspensionPosition, 0, 16);

            m_suspensionVelocity = new float[4];
            Buffer.BlockCopy(bytes, 16, m_suspensionVelocity, 0, 16);

            m_suspensionAcceleration = new float[4];
            Buffer.BlockCopy(bytes, 32, m_suspensionAcceleration, 0, 16);

            m_wheelSpeed = new float[4];
            Buffer.BlockCopy(bytes, 48, m_wheelSpeed, 0, 16);

            m_wheelSlip = new float[4];
            Buffer.BlockCopy(bytes, 64, m_wheelSlip, 0, 16);

            m_localVelocityX = BitConverter.ToSingle(bytes, 80);
            m_localVelocityY = BitConverter.ToSingle(bytes, 84);
            m_localVelocityZ = BitConverter.ToSingle(bytes, 88);

            m_angularVelocityX = BitConverter.ToSingle(bytes, 92);
            m_angularVelocityY = BitConverter.ToSingle(bytes, 96);
            m_angularVelocityZ = BitConverter.ToSingle(bytes, 100);

            m_angularAccelerationX = BitConverter.ToSingle(bytes, 104);
            m_angularAccelerationY = BitConverter.ToSingle(bytes, 108);
            m_angularAccelerationZ = BitConverter.ToSingle(bytes, 112);

            m_frontWheelsAngle = BitConverter.ToSingle(bytes, 116);
        }
    }
}