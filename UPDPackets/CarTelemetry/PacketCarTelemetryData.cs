using System;

namespace UPDPackets.CarTelemetry
{
    public class PacketCarTelemetryData : Packet
    {
        public CarTelemetryData[] m_carTelemetryData;

        public uint m_buttonStatus;        // Bit flags specifying which buttons are being pressed
        // currently - see appendices

        // Added in Beta 3:
        public byte m_mfdPanelIndex;       // Index of MFD panel open - 255 = MFD closed
        // Single player, race – 0 = Car setup, 1 = Pits
        // 2 = Damage, 3 =  Engine, 4 = Temperatures
        // May vary depending on game mode
        public byte m_mfdPanelIndexSecondaryPlayer;   // See above
        public sbyte m_suggestedGear;       // Suggested gear for the player (1-8)
        // 0 if no gear suggested

        public PacketCarTelemetryData(byte[] bytes) : base(bytes[..PacketHeader.SIZE])
        {
            bytes = bytes[PacketHeader.SIZE..];

            m_carTelemetryData = new CarTelemetryData[22];

            for (int i = 0; i < 22; i++)
            {
                m_carTelemetryData[i] = new CarTelemetryData(bytes[..CarTelemetryData.SIZE]);

                bytes = bytes[CarTelemetryData.SIZE..];
            }

            m_buttonStatus = BitConverter.ToUInt32(bytes, bytes[0]);
            m_mfdPanelIndex = bytes[4];
            m_mfdPanelIndexSecondaryPlayer = bytes[5];
            m_suggestedGear = (sbyte)BitConverter.ToChar(bytes, 6);
        }
    }
}