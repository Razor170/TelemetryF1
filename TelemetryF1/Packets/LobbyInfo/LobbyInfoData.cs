namespace TelemetryF1.Packets.LobbyInfo
{
    public struct LobbyInfoData
    {
        public byte m_aiControlled;            // Whether the vehicle is AI (1) or Human (0) controlled
        public byte m_teamId;                  // Team id - see appendix (255 if no team currently selected)
        public byte m_nationality;             // Nationality of the driver
        public char[] m_name;                // Name of participant in UTF-8 format – null terminated
        // Will be truncated with ... (U+2026) if too long
        public byte m_readyStatus;             // 0 = not ready, 1 = ready, 2 = spectating
    }
}