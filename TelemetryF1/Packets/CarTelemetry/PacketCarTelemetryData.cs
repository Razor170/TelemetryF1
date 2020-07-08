using System;

namespace TelemetryF1.Packets.CarTelemetry
{
    public class PacketCarTelemetryData : Packet
    {
        public PacketHeader m_header;         // Header

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

        public PacketCarTelemetryData(byte[] bytes)
        {
            int byteStartPtr = 0;

            byte[] bytesHeader = new byte[PacketHeader.SIZE];
            Buffer.BlockCopy(bytes, byteStartPtr, bytesHeader, 0, PacketHeader.SIZE);
            m_header = new PacketHeader(bytesHeader);
            byteStartPtr = PacketHeader.SIZE;
            m_carTelemetryData = new CarTelemetryData[20];

            for (int i = 0; i < 20; i++)
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