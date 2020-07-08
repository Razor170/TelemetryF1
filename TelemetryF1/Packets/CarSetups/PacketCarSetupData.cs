namespace TelemetryF1.Packets.CarSetups
{
    public struct PacketCarSetupData
    {
        public PacketHeader m_header;            // Header

        public CarSetupData[] m_carSetups;
    }
}