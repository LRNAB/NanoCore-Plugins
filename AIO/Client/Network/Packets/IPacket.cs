using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Network.Packets
{
    public interface PacketProcessor
    {
        void Handle(object[] parameters);
    }
}
