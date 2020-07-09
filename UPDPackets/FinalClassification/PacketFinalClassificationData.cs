namespace UPDPackets.FinalClassification
{
    public class PacketFinalClassificationData : Packet
    {
        public byte m_numCars;                 // Number of cars in the final classification
        public FinalClassificationData[] m_classificationData;

        public PacketFinalClassificationData(byte[] bytes) : base(bytes[0..PacketHeader.SIZE])
        {
            m_numCars = bytes[PacketHeader.SIZE];

            bytes = bytes[(PacketHeader.SIZE + 1)..];

            m_classificationData = new FinalClassificationData[22];

            for (int i = 0; i < 22; i++)
            {
                m_classificationData[i] = new FinalClassificationData(bytes[..FinalClassificationData.SIZE]);

                bytes = bytes[FinalClassificationData.SIZE..];
            }
        }
    }
}