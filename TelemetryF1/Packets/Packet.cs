using System;

namespace TelemetryF1.Packets
{
    public abstract class Packet
    {
        public PacketHeader m_header;

        protected Packet(byte[] bytes)
        {
            byte[] bytesHeader = new byte[PacketHeader.SIZE];
            Buffer.BlockCopy(bytes, 0, bytesHeader, 0, PacketHeader.SIZE);
            m_header = new PacketHeader(bytesHeader);
        }
    }
}