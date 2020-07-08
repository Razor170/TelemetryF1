namespace TelemetryF1.Packets.Event
{
    public struct PacketEventData
    {
        public PacketHeader m_header;             // Header

        public byte[] m_eventStringCode; // Event string code, see below
        public EventDataDetails m_eventDetails;       // Event details - should be interpreted differently
        // for each type
    }
}