using System;
using System.Collections.Generic;
using System.Text;
using Client.Core;
using Network.Headers;

namespace Client.Network.Packets
{
    public class MonitorProcessor : PacketProcessor
    {
        public void Handle(object[] parameters)
        {
            switch ((Monitor)parameters[1])
            {
                case Monitor.TurnOff:
                    SetMonitorInState(MonitorState.MonitorStateOff);
                    break;
                case Monitor.TurnOn:
                    SetMonitorInState(MonitorState.MonitorStateOn);
                    break;
            }
        }

        private void SetMonitorInState(MonitorState state)
        {
            NativeMethods.SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, (int)state);
        }

        const int HWND_BROADCAST = 0xffff;
        const int SC_MONITORPOWER = 0xF170;
        const int WM_SYSCOMMAND = 0x0112;

        public enum MonitorState
        {
            MonitorStateOn = -1,
            MonitorStateOff = 2,
            MonitorStateStandBy = 1
        }

    }
}
