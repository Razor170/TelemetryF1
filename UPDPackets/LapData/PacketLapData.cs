namespace UPDPackets.LapData
{
    public class PacketLapData : Packet
    {
        public LapData[] m_lapData;

        public PacketLapData(byte[] bytes) : base(bytes[..PacketHeader.SIZE])
        {
            bytes = bytes[PacketHeader.SIZE..];

            m_lapData = new LapData[22];

            for (int i = 0; i < 22; i++)
            {
                m_lapData[i] = new LapData(bytes[..LapData.SIZE]);

                bytes = bytes[LapData.SIZE..];
            }
        }
    }
}