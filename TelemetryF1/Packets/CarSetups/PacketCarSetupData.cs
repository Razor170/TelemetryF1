using System;

namespace TelemetryF1.Packets.CarSetups
{
    public class PacketCarSetupData : Packet
    {
        public CarSetupData[] m_carSetups;

        public PacketCarSetupData(byte[] bytes) : base(bytes)
        {
            int byteStartPtr = PacketHeader.SIZE;

            m_carSetups = new CarSetupData[22];

            for (int i = 0; i < 22; i++)
            {
                byte[] bytesData = new byte[CarSetupData.SIZE];
                Buffer.BlockCopy(bytes, byteStartPtr, bytesData, 0, CarSetupData.SIZE);
                m_carSetups[i] = new CarSetupData(bytesData);

                byteStartPtr += CarSetupData.SIZE;
            }
        }
    }
}