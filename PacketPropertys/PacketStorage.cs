using UPDPackets;
using UPDPackets.CarSetups;
using UPDPackets.CarStatus;
using UPDPackets.CarTelemetry;
using UPDPackets.FinalClassification;
using UPDPackets.LapData;
using UPDPackets.LobbyInfo;
using UPDPackets.Motion;
using UPDPackets.Participants;
using UPDPackets.Session;

namespace Storage
{
    public class PacketStorage
    {
        public PacketCarTelemetryData CarTelemetryData { get; private set; }
        public PacketCarSetupData CarSetupData { get; private set; }
        public PacketCarStatusData CarStatusData { get; private set; }
        public PacketFinalClassificationData FinalClassificationData { get; private set; }
        public PacketLapData LapData { get; private set; }
        public PacketLobbyInfoData LobbyInfoData { get; private set; }
        public PacketMotionData MotionData { get; private set; }
        public PacketParticipantsData ParticipantsData { get; private set; }
        public PacketSessionData SessionData { get; private set; }

        public void SetPacket(Packet packet)
        {
            switch (packet.m_header.m_packetId)
            {
                case 0:
                    //MotionData
                    MotionData = (PacketMotionData) packet;
                    break;
                case 1:
                    //SessionData
                    SessionData = (PacketSessionData) packet;
                    break;
                case 2:
                    //LapData
                    LapData = (PacketLapData) packet;
                    break;
                case 3:
                    //EventData TODO
                    break;
                case 4:
                    //ParticipantsData
                    ParticipantsData = (PacketParticipantsData) packet;
                    break;
                case 5:
                    //CarSetupData
                    CarSetupData = (PacketCarSetupData) packet;
                    break;
                case 6:
                    //CarTelemetryData
                    CarTelemetryData = (PacketCarTelemetryData) packet;
                    break;
                case 7:
                    //CarStatusData
                    CarStatusData = (PacketCarStatusData) packet;
                    break;
                case 8:
                    //FinalClassificationData
                    FinalClassificationData = (PacketFinalClassificationData) packet;
                    break;
                case 9:
                    //LobbyInfoData
                    LobbyInfoData = (PacketLobbyInfoData) packet;
                    break;
            }
        }
    }
}
