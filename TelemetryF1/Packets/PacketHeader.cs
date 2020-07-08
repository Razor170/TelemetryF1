using System;
using System.Runtime.InteropServices;

namespace TelemetryF1.Packets
{
    public class PacketHeader
    {
        public const int SIZE = 24;
        public ushort m_packetFormat; // 2020
        public byte m_gameMajorVersion; // Game major version - "X.00"
        public byte m_gameMinorVersion; // Game minor version - "1.XX"
        public byte m_packetVersion; // Version of this packet type, all start from 1
        public byte m_packetId; // Identifier for the packet type, see below
        public ulong m_sessionUID; // Unique identifier for the session
        public float m_sessionTime; // Session timestamp
        public uint m_frameIdentifier; // Identifier for the frame the data was retrieved on
        public byte m_playerCarIndex; // Index of player's car in the array

        // ADDED IN BETA 2: 
        public byte m_secondaryPlayerCarIndex; // Index of secondary player's car in the array (splitscreen)
        // 255 if no second player

        public PacketHeader(byte[] bytes)
        {
            m_packetFormat = BitConverter.ToUInt16(bytes, 0);
            m_gameMajorVersion = bytes[2];
            m_gameMinorVersion = bytes[3];
            m_packetVersion = bytes[4];
            m_packetId = bytes[5];
            m_sessionUID = BitConverter.ToUInt64(bytes, 6);
            m_sessionTime = BitConverter.ToSingle(bytes, 14);
            m_frameIdentifier = BitConverter.ToUInt32(bytes, 18);
            m_playerCarIndex = bytes[22];
            m_secondaryPlayerCarIndex = bytes[24];
        }
    }
}