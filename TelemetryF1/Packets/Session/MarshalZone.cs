﻿namespace TelemetryF1.Packets.Session
{
    public struct MarshalZone
    {
        public float m_zoneStart;   // Fraction (0..1) of way through the lap the marshal zone starts
        public sbyte m_zoneFlag;    // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
    }
}