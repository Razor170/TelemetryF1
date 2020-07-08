using System;

namespace TelemetryF1.Packets.CarTelemetry
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

        public PacketCarTelemetryData(byte[] bytes) : base(bytes)
        {
            int byteStartPtr = PacketHeader.SIZE;

            m_carTelemetryData = new CarTelemetryData[22];

            for (int i = 0; i < 22; i++)
            {
                byte[] bytesData = new byte[CarTelemetryData.SIZE];
                Buffer.BlockCopy(bytes, byteStartPtr, bytesData, 0, CarTelemetryData.SIZE);
                m_carTelemetryData[i] = new CarTelemetryData(bytesData);

                byteStartPtr += CarTelemetryData.SIZE;
            }

            m_buttonStatus = BitConverter.ToUInt32(bytes, byteStartPtr);
            byteStartPtr += 4;
            m_mfdPanelIndex = bytes[byteStartPtr++];
            m_mfdPanelIndexSecondaryPlayer = bytes[byteStartPtr++];
            m_suggestedGear = (sbyte)BitConverter.ToChar(bytes, byteStartPtr);
        }
    }
}