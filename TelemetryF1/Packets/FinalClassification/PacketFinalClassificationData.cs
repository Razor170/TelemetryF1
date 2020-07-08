namespace TelemetryF1.Packets.FinalClassification
{
    public struct PacketFinalClassificationData
    {
        public PacketHeader m_header;                             // Header

        public byte m_numCars;                 // Number of cars in the final classification
        public FinalClassificationData[] m_classificationData;
    }
}