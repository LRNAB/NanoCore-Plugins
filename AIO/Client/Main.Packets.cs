using Client.Network.Packets;
using Network.Headers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    partial class Main
    {
        Dictionary<Commands, PacketProcessor> Packets = new Dictionary<Commands, PacketProcessor>
        {
            {Commands.Monitor, new MonitorProcessor()},
            {Commands.Volume, new VolumeProcessor()}
        };
    }
}
