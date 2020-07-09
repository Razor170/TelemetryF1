using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using UPDPackets;
using Storage;

namespace UDPReceiver
{
    public class Receiver
    {
        private IPEndPoint remoteIp;
        private readonly UdpClient udp;
        private readonly PacketStorage storage;

        private Thread captureThread = null;

        static readonly object syncObj = new object();

        public Receiver(int _port, PacketStorage _storage)
        {
            storage = _storage;
            udp = new UdpClient(_port);
            remoteIp = new IPEndPoint(IPAddress.Any, _port);
        }

        public void Start()
        {
            if (captureThread == null)
            {
                captureThread = new Thread(FetchData);
                captureThread.Start();
            }
        }

        public void Stop()
        {
            if (captureThread != null)
            {
                captureThread.Abort();
                captureThread = null;
            }
        }

        private void FetchData()
        {
            while (true)
            {
                Byte[] receivedBytes = udp.Receive(ref remoteIp);

                Monitor.Enter(syncObj);

                Packet packet = PacketFactory.GetPacket(receivedBytes);

                storage.SetPacket(packet);

                Monitor.Exit(syncObj);
            }
        }

        
    }
}
