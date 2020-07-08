namespace TelemetryF1.Packets.Participants
{
    public struct PacketParticipantsData
    {
        public PacketHeader m_header;           // Header

        public byte m_numActiveCars;  // Number of active cars in the data – should match number of
        // cars on HUD
        public ParticipantData[] m_participants;
    }
}