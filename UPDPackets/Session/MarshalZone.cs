using System;

namespace UPDPackets.Session
{
    public class MarshalZone
    {
        public const int SIZE = 5;
        public float m_zoneStart;   // Fraction (0..1) of way through the lap the marshal zone starts
        public sbyte m_zoneFlag;    // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red

        public MarshalZone(byte[] bytes)
        {
            m_zoneStart = BitConverter.ToSingle(bytes, 0);
            m_zoneFlag = (sbyte)BitConverter.ToChar(bytes, 4);
        }
    }
}