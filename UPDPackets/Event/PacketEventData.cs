namespace UPDPackets.Event
{
    public class PacketEventData : Packet
    {
        public string m_eventStringCode; // Event string code, see below
        public EventDataDetails m_eventDetails;       // Event details - should be interpreted differently
        // for each type

        public PacketEventData(byte[] bytes) : base(bytes[..PacketHeader.SIZE])
        {
            bytes = bytes[PacketHeader.SIZE..];

            m_eventStringCode = System.Text.Encoding.UTF8.GetString(bytes, 0, 4);

            bytes = bytes[4..];

            switch (m_eventStringCode)
            {
                case EventStringCodes.FastestLap:
                    m_eventDetails = new FastestLap(bytes);
                    break;
                case EventStringCodes.Retirement:
                    m_eventDetails = new Retirement(bytes);
                    break;
                case EventStringCodes.TeamMateInPits:
                    m_eventDetails = new TeamMateInPits(bytes);
                    break;
                case EventStringCodes.RaceWinner:
                    m_eventDetails = new RaceWinner(bytes);
                    break;
                case EventStringCodes.PenaltyIssued:
                    m_eventDetails = new Penalty(bytes);
                    break;
                case EventStringCodes.SpeedTrapTriggered:
                    m_eventDetails = new SpeedTrap(bytes);
                    break;
            }
        }
    }
}