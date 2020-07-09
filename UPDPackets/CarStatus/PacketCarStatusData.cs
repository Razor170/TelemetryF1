namespace UPDPackets.CarStatus
{
    public class PacketCarStatusData : Packet
    {
        public CarStatusData[] m_carStatusData;

        public PacketCarStatusData(byte[] bytes) : base(bytes[..PacketHeader.SIZE])
        {
            bytes = bytes[PacketHeader.SIZE..];

            m_carStatusData = new CarStatusData[22];

            for (int i = 0; i < 22; i++)
            {
                m_carStatusData[i] = new CarStatusData(bytes[..CarStatusData.SIZE]);

                bytes = bytes[CarStatusData.SIZE..];
            }
        }
    }
}