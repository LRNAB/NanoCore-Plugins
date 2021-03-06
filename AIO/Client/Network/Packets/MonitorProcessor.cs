﻿using System;
using System.Collections.Generic;
using System.Text;
using Client.Core;
using Network.Headers;
using System.Runtime.InteropServices;

namespace Client.Network.Packets
{
    public class MonitorProcessor : PacketProcessor
    {
        public void Handle(object[] parameters)
        {
            switch ((Monitor)parameters[1])
            {
                case Monitor.TurnOff:
                    SetMonitorInState(NativeMethods.MonitorState.MonitorStateOff);
                    break;
                case Monitor.TurnOn:
                    SetMonitorInState(NativeMethods.MonitorState.MonitorStateOn);
                    break;
                case Monitor.Rotate90CW:
                    RotateScreen();
                    break;
            }
        }

        private void RotateScreen()
        {
            // initialize the DEVMODE structure
            NativeMethods.DEVMODE dm = new NativeMethods.DEVMODE();
            dm.dmDeviceName = new string(new char[32]);
            dm.dmFormName = new string(new char[32]);
            dm.dmSize = (short)Marshal.SizeOf(dm);

            if (0 != NativeMethods.EnumDisplaySettings(null, NativeMethods.ENUM_CURRENT_SETTINGS, ref dm))
            {
                // swap width and height
                int temp = dm.dmPelsHeight;
                dm.dmPelsHeight = dm.dmPelsWidth;
                dm.dmPelsWidth = temp;

                // determine new orientation
                switch (dm.dmDisplayOrientation)
                {
                    case NativeMethods.DMDO_DEFAULT:
                        dm.dmDisplayOrientation = NativeMethods.DMDO_270;
                        break;
                    case NativeMethods.DMDO_270:
                        dm.dmDisplayOrientation = NativeMethods.DMDO_180;
                        break;
                    case NativeMethods.DMDO_180:
                        dm.dmDisplayOrientation = NativeMethods.DMDO_90;
                        break;
                    case NativeMethods.DMDO_90:
                        dm.dmDisplayOrientation = NativeMethods.DMDO_DEFAULT;
                        break;
                    default:
                        // unknown orientation value
                        // add exception handling here
                        break;
                }

                int iRet = NativeMethods.ChangeDisplaySettings(ref dm, 0);
                if ((NativeMethods.DISP_CHANGE)iRet != NativeMethods.DISP_CHANGE.Successful)
                {
                    // add exception handling here
                }
            }
        }

        private void SetMonitorInState(NativeMethods.MonitorState state)
        {
            NativeMethods.SendMessage(NativeMethods.HWND_BROADCAST, NativeMethods.WM_SYSCOMMAND, NativeMethods.SC_MONITORPOWER, (int)state);
        }        
    }
}
