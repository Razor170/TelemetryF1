namespace UPDPackets.LobbyInfo
{
    public class PacketLobbyInfoData : Packet
    {
        public byte m_numPlayers;
        public LobbyInfoData[] m_lobbyPlayers;

        public PacketLobbyInfoData(byte[] bytes) : base(bytes[..PacketHeader.SIZE])
        {
            m_numPlayers = bytes[PacketHeader.SIZE];
            bytes = bytes[..(PacketHeader.SIZE + 1)];

            m_lobbyPlayers = new LobbyInfoData[22];

            for (int i = 0; i < 22; i++)
            {
                m_lobbyPlayers[i] = new LobbyInfoData(bytes[..LobbyInfoData.SIZE]);

                bytes = bytes[LobbyInfoData.SIZE..];
            }
        }
    }
}