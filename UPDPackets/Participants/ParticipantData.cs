namespace UPDPackets.Participants
{
    public class ParticipantData
    {
        public const int SIZE = 54;
        public byte m_aiControlled;           // Whether the vehicle is AI (1) or Human (0) controlled
        public byte m_driverId;               // Driver id - see appendix
        public byte m_teamId;                 // Team id - see appendix
        public byte m_raceNumber;             // Race number of the car
        public byte m_nationality;            // Nationality of the driver
        public string m_name;               // Name of participant in UTF-8 format – null terminated
        // Will be truncated with … (U+2026) if too long
        public byte m_yourTelemetry;          // The player's UDP setting, 0 = restricted, 1 = public

        public ParticipantData(byte[] bytes)
        {
            m_aiControlled = bytes[0];
            m_driverId = bytes[1];
            m_teamId = bytes[2];
            m_raceNumber = bytes[3];
            m_nationality = bytes[4];
            m_name = System.Text.Encoding.UTF8.GetString(bytes, 5, 48);
            m_yourTelemetry = bytes[53];
        }
    }
}