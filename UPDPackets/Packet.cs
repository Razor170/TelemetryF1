namespace UPDPackets
{
    public abstract class Packet
    {
        public PacketHeader m_header;

        protected Packet(byte[] bytes)
        {
            m_header = new PacketHeader(bytes);
        }
    }
}