namespace UPDPackets.LobbyInfo
{
    public class LobbyInfoData
    {
        public const int SIZE = 52;
        public byte m_aiControlled;            // Whether the vehicle is AI (1) or Human (0) controlled
        public byte m_teamId;                  // Team id - see appendix (255 if no team currently selected)
        public byte m_nationality;             // Nationality of the driver
        public string m_name;                // 22 Char Array // Name of participant in UTF-8 format – null terminated
        // Will be truncated with ... (U+2026) if too long
        public byte m_readyStatus;             // 0 = not ready, 1 = ready, 2 = spectating

        public LobbyInfoData(byte[] bytes)
        {
            m_aiControlled = bytes[0];
            m_teamId = bytes[1];
            m_nationality = bytes[2];
            m_name = System.Text.Encoding.UTF8.GetString(bytes, 3, 48);
            m_readyStatus = bytes[51];
        }
    }
}