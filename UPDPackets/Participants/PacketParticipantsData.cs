namespace UPDPackets.Participants
{
    public class PacketParticipantsData : Packet
    {
        public byte m_numActiveCars;  // Number of active cars in the data – should match number of
        // cars on HUD
        public ParticipantData[] m_participants;

        public PacketParticipantsData(byte[] bytes) : base(bytes[..PacketHeader.SIZE])
        {
            m_numActiveCars = bytes[PacketHeader.SIZE];
            bytes = bytes[(PacketHeader.SIZE + 1)..];

            m_participants = new ParticipantData[22];

            for (int i = 0; i < 22; i++)
            {
                m_participants[i] = new ParticipantData(bytes[..ParticipantData.SIZE]);

                bytes = bytes[ParticipantData.SIZE..];
            }
        }
    }
}