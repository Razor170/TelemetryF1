using System;

namespace UPDPackets.Event
{
    public class EventDataDetails
    {
    }

    public class FastestLap : EventDataDetails
    {
        public const int SIZE = 5;

        public byte vehicleIdx; // Vehicle index of car achieving fastest lap
        public float lapTime;    // Lap time is in seconds

        public FastestLap(byte[] bytes)
        {
            vehicleIdx = bytes[0];
            lapTime = BitConverter.ToSingle(bytes, 1);
        }
    }

    public class Retirement : EventDataDetails
    {
        public const int SIZE = 1;

        public byte vehicleIdx; // Vehicle index of car retiring

        public Retirement(byte[] bytes)
        {
            vehicleIdx = bytes[0];
        }
    }

    public class TeamMateInPits : EventDataDetails
    {
        public const int SIZE = 1;

        public byte vehicleIdx; // Vehicle index of team mate

        public TeamMateInPits(byte[] bytes)
        {
            vehicleIdx = bytes[0];
        }
    }

    public class RaceWinner : EventDataDetails
    {
        public const int SIZE = 1;

        public byte vehicleIdx; // Vehicle index of the race winner

        public RaceWinner(byte[] bytes)
        {
            vehicleIdx = bytes[0];
        }
    }

    public class Penalty : EventDataDetails
    {
        public const int SIZE = 7;

        public byte penaltyType;          // Penalty type – see Appendices
        public byte infringementType;     // Infringement type – see Appendices
        public byte vehicleIdx;           // Vehicle index of the car the penalty is applied to
        public byte otherVehicleIdx;      // Vehicle index of the other car involved
        public byte time;                 // Time gained, or time spent doing action in seconds
        public byte lapNum;               // Lap the penalty occurred on
        public byte placesGained;         // Number of places gained by this

        public Penalty(byte[] bytes)
        {
            penaltyType = bytes[0];
            infringementType = bytes[1];
            vehicleIdx = bytes[2];
            otherVehicleIdx = bytes[3];
            time = bytes[4];
            lapNum = bytes[5];
            placesGained = bytes[6];
        }
    }

    public class SpeedTrap : EventDataDetails
    {
        public const int SIZE = 5;

        public byte vehicleIdx; // Vehicle index of the vehicle triggering speed trap
        public float speed;      // Top speed achieved in kilometres per hour

        public SpeedTrap(byte[] bytes)
        {
            vehicleIdx = bytes[0];
            speed = BitConverter.ToSingle(bytes, 1);
        }
    }
}