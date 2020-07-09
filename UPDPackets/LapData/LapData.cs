using System;

namespace UPDPackets.LapData
{
    public class LapData
    {
        public const int SIZE = 53;
        public float m_lastLapTime;               // Last lap time in seconds
        public float m_currentLapTime;            // Current time around the lap in seconds

        //UPDATED in Beta 3:
        public ushort m_sector1TimeInMS;           // Sector 1 time in milliseconds
        public ushort m_sector2TimeInMS;           // Sector 2 time in milliseconds
        public float m_bestLapTime;               // Best lap time of the session in seconds
        public byte m_bestLapNum;                // Lap number best time achieved on
        public ushort m_bestLapSector1TimeInMS;    // Sector 1 time of best lap in the session in milliseconds
        public ushort m_bestLapSector2TimeInMS;    // Sector 2 time of best lap in the session in milliseconds
        public ushort m_bestLapSector3TimeInMS;    // Sector 3 time of best lap in the session in milliseconds
        public ushort m_bestOverallSector1TimeInMS;// Best overall sector 1 time of the session in milliseconds
        public byte m_bestOverallSector1LapNum;  // Lap number best overall sector 1 time achieved on
        public ushort m_bestOverallSector2TimeInMS;// Best overall sector 2 time of the session in milliseconds
        public byte m_bestOverallSector2LapNum;  // Lap number best overall sector 2 time achieved on
        public ushort m_bestOverallSector3TimeInMS;// Best overall sector 3 time of the session in milliseconds
        public byte m_bestOverallSector3LapNum;  // Lap number best overall sector 3 time achieved on


        public float m_lapDistance;               // Distance vehicle is around current lap in metres – could
                                                  // be negative if line hasn’t been crossed yet
        public float m_totalDistance;             // Total distance travelled in session in metres – could
                                                  // be negative if line hasn’t been crossed yet
        public float m_safetyCarDelta;            // Delta in seconds for safety car
        public byte m_carPosition;               // Car race position
        public byte m_currentLapNum;             // Current lap number
        public byte m_pitStatus;                 // 0 = none, 1 = pitting, 2 = in pit area
        public byte m_sector;                    // 0 = sector1, 1 = sector2, 2 = sector3
        public byte m_currentLapInvalid;         // Current lap invalid - 0 = valid, 1 = invalid
        public byte m_penalties;                 // Accumulated time penalties in seconds to be added
        public byte m_gridPosition;              // Grid position the vehicle started the race in
        public byte m_driverStatus;              // Status of driver - 0 = in garage, 1 = flying lap
                                                 // 2 = in lap, 3 = out lap, 4 = on track
        public byte m_resultStatus;              // Result status - 0 = invalid, 1 = inactive, 2 = active
                                           // 3 = finished, 4 = disqualified, 5 = not classified
                                           // 6 = retired

        public LapData(byte[] bytes)
        {
            m_lastLapTime = BitConverter.ToSingle(bytes, 0);
            m_currentLapTime = BitConverter.ToSingle(bytes, 4);

            m_sector1TimeInMS = BitConverter.ToUInt16(bytes, 8);
            m_sector2TimeInMS = BitConverter.ToUInt16(bytes, 10);

            m_bestLapTime = BitConverter.ToSingle(bytes, 12);

            m_bestLapNum = bytes[16];

            m_bestLapSector1TimeInMS = BitConverter.ToUInt16(bytes, 17);
            m_bestLapSector2TimeInMS = BitConverter.ToUInt16(bytes, 19);
            m_bestLapSector3TimeInMS = BitConverter.ToUInt16(bytes, 21);

            m_bestOverallSector1TimeInMS = BitConverter.ToUInt16(bytes, 23);
            m_bestOverallSector1LapNum = bytes[25];
            m_bestOverallSector2TimeInMS = BitConverter.ToUInt16(bytes, 26);
            m_bestOverallSector2LapNum = bytes[28];
            m_bestOverallSector3TimeInMS = BitConverter.ToUInt16(bytes, 29);
            m_bestOverallSector3LapNum = bytes[31];

            m_lapDistance = BitConverter.ToSingle(bytes, 32);
            m_totalDistance = BitConverter.ToSingle(bytes, 36);
            m_safetyCarDelta = BitConverter.ToSingle(bytes, 40);
            m_carPosition = bytes[44];
            m_currentLapNum = bytes[45];
            m_pitStatus = bytes[46];
            m_sector = bytes[47];
            m_currentLapInvalid = bytes[48];
            m_penalties = bytes[49];
            m_gridPosition = bytes[50];
            m_driverStatus = bytes[51];
            m_resultStatus = bytes[52];
        }
    }
}