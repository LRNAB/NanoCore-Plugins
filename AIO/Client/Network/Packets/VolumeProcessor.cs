using Network.Headers;
using System;
using System.Collections.Generic;
using System.Text;
using Client.Core;

namespace Client.Network.Packets
{
    class VolumeProcessor : PacketProcessor
    {
        public void Handle(object[] parameters)
        {
            switch ((Volume)parameters[1])
            {
                case Volume.Up:
                    NativeMethods.SendMessage(NativeMethods.HWND_BROADCAST, NativeMethods.WM_APPCOMMAND, NativeMethods.HWND_BROADCAST, NativeMethods.APPCOMMAND_VOLUME_UP);
                    break;

                case Volume.Down:
                    NativeMethods.SendMessage(NativeMethods.HWND_BROADCAST, NativeMethods.WM_APPCOMMAND, NativeMethods.HWND_BROADCAST, NativeMethods.APPCOMMAND_VOLUME_DOWN);
                    break;

                case Volume.Mute:
                    NativeMethods.SendMessage(NativeMethods.HWND_BROADCAST, NativeMethods.WM_APPCOMMAND, NativeMethods.HWND_BROADCAST, NativeMethods.APPCOMMAND_VOLUME_MUTE);
                    break;
            }
        }
    }
}