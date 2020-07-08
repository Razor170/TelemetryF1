namespace TelemetryF1.Packets.CarStatus
{
    public struct PacketCarStatusData
    {
        public PacketHeader m_header;

        public CarStatusData[] m_carStatusData;
    }
}