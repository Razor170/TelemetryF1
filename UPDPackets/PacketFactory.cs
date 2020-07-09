using UPDPackets.CarSetups;
using UPDPackets.CarStatus;
using UPDPackets.CarTelemetry;
using UPDPackets.Event;
using UPDPackets.FinalClassification;
using UPDPackets.LapData;
using UPDPackets.LobbyInfo;
using UPDPackets.Motion;
using UPDPackets.Participants;
using UPDPackets.Session;

namespace UPDPackets
{
    public class PacketFactory
    {
        public static Packet GetPacket(byte[] bytes)
        {
            switch (bytes[5])
            {
                case 0:
                    return new PacketMotionData(bytes);
                case 1:
                    return new PacketSessionData(bytes);
                case 2:
                    return new PacketLapData(bytes);
                case 3:
                    return new PacketEventData(bytes);
                case 4:
                    return new PacketParticipantsData(bytes);
                case 5:
                    return new PacketCarSetupData(bytes);
                case 6:
                    return new PacketCarTelemetryData(bytes);
                case 7:
                    return new PacketCarStatusData(bytes);
                case 8:
                    return new PacketFinalClassificationData(bytes);
                case 9:
                    return new PacketLobbyInfoData(bytes);
                default:
                    return null;
            }
        }
    }
}