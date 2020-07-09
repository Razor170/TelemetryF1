using System;

namespace UPDPackets.FinalClassification
{
    public class FinalClassificationData
    {
        public const int SIZE = 37;
        public byte m_position;              // Finishing position
        public byte m_numLaps;               // Number of laps completed
        public byte m_gridPosition;          // Grid position of the car
        public byte m_points;                // Number of points scored
        public byte m_numPitStops;           // Number of pit stops made
        public byte m_resultStatus;          // Result status - 0 = invalid, 1 = inactive, 2 = active
        // 3 = finished, 4 = disqualified, 5 = not classified
        // 6 = retired
        public float m_bestLapTime;           // Best lap time of the session in seconds
        public double m_totalRaceTime;         // Total race time in seconds without penalties
        public byte m_penaltiesTime;         // Total penalties accumulated in seconds
        public byte m_numPenalties;          // Number of penalties applied to this driver
        public byte m_numTyreStints;         // Number of tyres stints up to maximum
        public byte[] m_tyreStintsActual;   // Actual tyres used by this driver
        public byte[] m_tyreStintsVisual;   // Visual tyres used by this driver

        public FinalClassificationData(byte[] bytes)
        {
            m_position = bytes[0];
            m_numLaps = bytes[1];
            m_gridPosition = bytes[2];
            m_points = bytes[3];
            m_numPitStops = bytes[4];
            m_resultStatus = bytes[5];
            m_bestLapTime = BitConverter.ToSingle(bytes, 6);
            m_totalRaceTime = BitConverter.ToDouble(bytes, 10);
            m_penaltiesTime = bytes[18];
            m_numPenalties = bytes[19];
            m_numTyreStints = bytes[20];
            m_tyreStintsActual = bytes[21..28];
            m_tyreStintsVisual = bytes[29..36];
        }
    }
}