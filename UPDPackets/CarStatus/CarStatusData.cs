using System;

namespace UPDPackets.CarStatus
{
    public class CarStatusData
    {
        public const int SIZE = 60;
        public byte m_tractionControl;          // 0 (off) - 2 (high)
        public byte m_antiLockBrakes;           // 0 (off) - 1 (on)
        public byte m_fuelMix;                  // Fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max
        public byte m_frontBrakeBias;           // Front brake bias (percentage)
        public byte m_pitLimiterStatus;         // Pit limiter status - 0 = off, 1 = on
        public float m_fuelInTank;               // Current fuel mass
        public float m_fuelCapacity;             // Fuel capacity
        public float m_fuelRemainingLaps;        // Fuel remaining in terms of laps (value on MFD)
        public ushort m_maxRPM;                   // Cars max RPM, point of rev limiter
        public ushort m_idleRPM;                  // Cars idle RPM
        public byte m_maxGears;                 // Maximum number of gears
        public byte m_drsAllowed;               // 0 = not allowed, 1 = allowed, -1 = unknown


        // Added in Beta3:
        public ushort m_drsActivationDistance;    // 0 = DRS not available, non-zero - DRS will be available
                                           // in [X] metres

        public byte[] m_tyresWear;             // Tyre wear percentage
        public byte m_actualTyreCompound;     // F1 Modern - 16 = C5, 17 = C4, 18 = C3, 19 = C2, 20 = C1
                                        // 7 = inter, 8 = wet
                                        // F1 Classic - 9 = dry, 10 = wet
                                        // F2 – 11 = super soft, 12 = soft, 13 = medium, 14 = hard
                                        // 15 = wet
        public byte m_visualTyreCompound;        // F1 visual (can be different from actual compound)
                                           // 16 = soft, 17 = medium, 18 = hard, 7 = inter, 8 = wet
                                           // F1 Classic – same as above
                                           // F2 – same as above
        public byte m_tyresAgeLaps;             // Age in laps of the current set of tyres
        public byte[] m_tyresDamage;           // Tyre damage (percentage)
        public byte m_frontLeftWingDamage;      // Front left wing damage (percentage)
        public byte m_frontRightWingDamage;     // Front right wing damage (percentage)
        public byte m_rearWingDamage;           // Rear wing damage (percentage)

        // Added Beta 3:
        public byte m_drsFault;                 // Indicator for DRS fault, 0 = OK, 1 = fault

        public byte m_engineDamage;             // Engine damage (percentage)
        public byte m_gearBoxDamage;            // Gear box damage (percentage)
        public sbyte m_vehicleFiaFlags;          // -1 = invalid/unknown, 0 = none, 1 = green
                                         // 2 = blue, 3 = yellow, 4 = red
        public float m_ersStoreEnergy;           // ERS energy store in Joules
        public byte m_ersDeployMode;            // ERS deployment mode, 0 = none, 1 = medium
                                          // 2 = overtake, 3 = hotlap
        public float m_ersHarvestedThisLapMGUK;  // ERS energy harvested this lap by MGU-K
        public float m_ersHarvestedThisLapMGUH;  // ERS energy harvested this lap by MGU-H
        public float m_ersDeployedThisLap;       // ERS energy deployed this lap

        public CarStatusData(byte[] bytes)
        {
            m_tractionControl = bytes[0];
            m_antiLockBrakes = bytes[1];
            m_fuelMix = bytes[2];
            m_frontBrakeBias = bytes[3];
            m_pitLimiterStatus = bytes[4];

            m_fuelInTank = BitConverter.ToSingle(bytes, 5);
            m_fuelCapacity = BitConverter.ToSingle(bytes, 9);
            m_fuelRemainingLaps = BitConverter.ToSingle(bytes, 13);

            m_maxRPM = BitConverter.ToUInt16(bytes, 17);
            m_idleRPM = BitConverter.ToUInt16(bytes, 19);

            m_maxGears = bytes[21];
            m_drsAllowed = bytes[22];

            m_drsActivationDistance = BitConverter.ToUInt16(bytes, 23);

            m_tyresWear = bytes[25..28];

            m_actualTyreCompound = bytes[29];
            m_visualTyreCompound = bytes[30];
            m_tyresAgeLaps = bytes[31];

            m_tyresDamage = bytes[32..35];

            m_frontLeftWingDamage = bytes[36];
            m_frontRightWingDamage = bytes[37];
            m_rearWingDamage = bytes[38];
            m_drsFault = bytes[39];
            m_engineDamage = bytes[40];
            m_gearBoxDamage = bytes[41];

            m_vehicleFiaFlags = (sbyte)BitConverter.ToChar(bytes, 42);
            m_ersStoreEnergy = BitConverter.ToSingle(bytes, 43);

            m_ersDeployMode = bytes[47];

            m_ersHarvestedThisLapMGUK = BitConverter.ToSingle(bytes, 48);
            m_ersHarvestedThisLapMGUH = BitConverter.ToSingle(bytes, 52);
            m_ersDeployedThisLap = BitConverter.ToSingle(bytes, 56);
        }
    }
}