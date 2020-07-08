using System.Runtime.InteropServices;

namespace TelemetryF1.Packets.Event
{
    [StructLayout(LayoutKind.Explicit)]
    public struct EventDataDetails
    {
        [FieldOffset(0)] public FastestLap fastestLap;
        [FieldOffset(0)] public Retirement retirement;
        [FieldOffset(0)] public TeamMateInPits teamMateInPits;
        [FieldOffset(0)] public RaceWinner raceWinner;
        [FieldOffset(0)] public Penalty penalty;
        [FieldOffset(0)] public SpeedTrap speedTrap;
    }

    public struct FastestLap
    {
        public byte vehicleIdx; // Vehicle index of car achieving fastest lap
        public float lapTime;    // Lap time is in seconds
    }

    public struct Retirement
    {
        public byte vehicleIdx; // Vehicle index of car retiring
    }

    public struct TeamMateInPits
    {
        public byte vehicleIdx; // Vehicle index of team mate
    }

    public struct RaceWinner
    {
        public byte vehicleIdx; // Vehicle index of the race winner
    }

    public struct Penalty
    {
        public byte penaltyType;          // Penalty type – see Appendices
        public byte infringementType;     // Infringement type – see Appendices
        public byte vehicleIdx;           // Vehicle index of the car the penalty is applied to
        public byte otherVehicleIdx;      // Vehicle index of the other car involved
        public byte time;                 // Time gained, or time spent doing action in seconds
        public byte lapNum;               // Lap the penalty occurred on
        public byte placesGained;         // Number of places gained by this
    }

    public struct SpeedTrap
    {
        public byte vehicleIdx; // Vehicle index of the vehicle triggering speed trap
        public float speed;      // Top speed achieved in kilometres per hour
    }
}