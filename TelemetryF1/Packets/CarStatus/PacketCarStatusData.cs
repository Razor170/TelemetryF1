using System;

namespace TelemetryF1.Packets.CarStatus
{
    public class PacketCarStatusData : Packet
    {
        public CarStatusData[] m_carStatusData;

        public PacketCarStatusData(byte[] bytes) : base(bytes)
        {
            int byteStartPtr = PacketHeader.SIZE;

            m_carStatusData = new CarStatusData[22];

            for (int i = 0; i < 22; i++)
            {
                byte[] bytesData = new byte[CarStatusData.SIZE];
                Buffer.BlockCopy(bytes, byteStartPtr, bytesData, 0, CarStatusData.SIZE);
                m_carStatusData[i] = new CarStatusData(bytesData);

                byteStartPtr += CarStatusData.SIZE;
            }
        }
    }
}