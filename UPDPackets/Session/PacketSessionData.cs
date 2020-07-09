using System;

namespace UPDPackets.Session
{
    public class PacketSessionData : Packet
    {
        public byte m_weather; // Weather - 0 = clear, 1 = light cloud, 2 = overcast

        // 3 = light rain, 4 = heavy rain, 5 = storm
        public sbyte m_trackTemperature; // Track temp. in degrees celsius
        public sbyte m_airTemperature; // Air temp. in degrees celsius
        public byte m_totalLaps; // Total number of laps in this race
        public ushort m_trackLength; // Track length in metres

        public byte m_sessionType; // 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P

        // 5 = Q1, 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ
        // 10 = R, 11 = R2, 12 = Time Trial
        public sbyte m_trackId; // -1 for unknown, 0-21 for tracks, see appendix

        public byte m_formula; // Formula, 0 = F1 Modern, 1 = F1 Classic, 2 = F2,

        // 3 = F1 Generic
        public ushort m_sessionTimeLeft; // Time left in session in seconds
        public ushort m_sessionDuration; // Session duration in seconds
        public byte m_pitSpeedLimit; // Pit speed limit in kilometres per hour
        public byte m_gamePaused; // Whether the game is paused
        public byte m_isSpectating; // Whether the player is spectating
        public byte m_spectatorCarIndex; // Index of the car being spectated
        public byte m_sliProNativeSupport; // SLI Pro support, 0 = inactive, 1 = active
        public byte m_numMarshalZones; // Number of marshal zones to follow
        public MarshalZone[] m_marshalZones; // List of marshal zones – max 21

        public byte m_safetyCarStatus; // 0 = no safety car, 1 = full safety car

        // 2 = virtual safety car
        public byte m_networkGame; // 0 = offline, 1 = online
        public byte m_numWeatherForecastSamples; // Number of weather samples to follow
        public WeatherForecastSample[] m_weatherForecastSamples; // Array of weather forecast samples

        public PacketSessionData(byte[] bytes) : base(bytes[..PacketHeader.SIZE])
        {
            bytes = bytes[PacketHeader.SIZE..];

            m_weather = bytes[0];

            m_trackTemperature = (sbyte)BitConverter.ToChar(bytes, 1);
            m_airTemperature = (sbyte)BitConverter.ToChar(bytes, 2);
            m_totalLaps = bytes[3];
            m_trackLength = BitConverter.ToUInt16(bytes, 4);
            m_sessionType = bytes[6];

            m_trackId = (sbyte)BitConverter.ToChar(bytes, 7);
            m_formula = bytes[8];

            m_sessionTimeLeft = BitConverter.ToUInt16(bytes, 9);
            m_sessionDuration = BitConverter.ToUInt16(bytes, 11);
            m_pitSpeedLimit = bytes[13];
            m_gamePaused = bytes[14];
            m_isSpectating = bytes[15];
            m_spectatorCarIndex = bytes[16];
            m_sliProNativeSupport = bytes[17];
            m_numMarshalZones = bytes[18];

            m_marshalZones = new MarshalZone[21];
            bytes = bytes[19..];

            for (int i = 0; i < 21; i++)
            {
                m_marshalZones[i] = new MarshalZone(bytes[..MarshalZone.SIZE]);

                bytes = bytes[MarshalZone.SIZE..];
            }

            m_safetyCarStatus = bytes[0];
            m_networkGame = bytes[1];
            m_numWeatherForecastSamples = bytes[2];

            m_weatherForecastSamples = new WeatherForecastSample[20];
            bytes = bytes[3..];

            for (int i = 0; i < 20; i++)
            {
                m_weatherForecastSamples[i] = new WeatherForecastSample(bytes[..WeatherForecastSample.SIZE]);

                bytes = bytes[WeatherForecastSample.SIZE..];
            }
        }
    }
}