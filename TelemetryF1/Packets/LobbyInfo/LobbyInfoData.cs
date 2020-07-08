using System.Runtime.InteropServices;

namespace TelemetryF1.Packets.LobbyInfo
{
    [StructLayout(LayoutKind.Explicit, Pack = 0, Size = 52)]
    public struct LobbyInfoData
    {
        [FieldOffset(0)]
        public byte m_aiControlled;            // Whether the vehicle is AI (1) or Human (0) controlled
        [FieldOffset(1)]
        public byte m_teamId;                  // Team id - see appendix (255 if no team currently selected)
        [FieldOffset(2)]
        public byte m_nationality;             // Nationality of the driver
        [FieldOffset(3)]
        public char[] m_name;                // 22 Char Array // Name of participant in UTF-8 format – null terminated
        // Will be truncated with ... (U+2026) if too long
        [FieldOffset(51)]
        public byte m_readyStatus;             // 0 = not ready, 1 = ready, 2 = spectating
    }
}