namespace UPDPackets.CarSetups
{
    public class PacketCarSetupData : Packet
    {
        public CarSetupData[] m_carSetups;

        public PacketCarSetupData(byte[] bytes) : base(bytes[..PacketHeader.SIZE])
        {
            bytes = bytes[PacketHeader.SIZE..];

            m_carSetups = new CarSetupData[22];

            for (int i = 0; i < 22; i++)
            {
                m_carSetups[i] = new CarSetupData(bytes[..CarSetupData.SIZE]);
                
                bytes = bytes[CarSetupData.SIZE..];
            }
        }
    }
}