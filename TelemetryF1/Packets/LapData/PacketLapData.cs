namespace TelemetryF1.Packets.LapData
{
    public struct PacketLapData
    {
        public PacketHeader m_header;

        public LapData[] m_lapData;
    }
}