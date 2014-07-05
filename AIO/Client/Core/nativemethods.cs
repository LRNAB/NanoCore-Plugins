using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Client.Core
{
    public class NativeMethods
    {
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern void SendMessage(int hWnd, int uMsg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        internal static extern int EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

        [DllImport("user32.dll")]
        internal static extern int ChangeDisplaySettings(ref DEVMODE lpDevMode, int dwFlags);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;

            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public int dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;

            public short dmLogPixels;
            public short dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        };

        public enum DISP_CHANGE : int
        {
            Successful = 0,
            Restart = 1,
            Failed = -1,
            BadMode = -2,
            NotUpdated = -3,
            BadFlags = -4,
            BadParam = -5,
            BadDualView = -6
        }
        public enum MonitorState
        {
            MonitorStateOn = -1,
            MonitorStateOff = 2,
            MonitorStateStandBy = 1
        }

        public const int ENUM_CURRENT_SETTINGS = -1;
        public const int DMDO_DEFAULT = 0;
        public const int DMDO_90 = 1;
        public const int DMDO_180 = 2;
        public const int DMDO_270 = 3;
        public const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        public const int APPCOMMAND_VOLUME_UP = 0xA0000;
        public const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        public const int WM_APPCOMMAND = 0x319;
        public const int HWND_BROADCAST = 0xffff;
        public const int SC_MONITORPOWER = 0xF170;
        public const int WM_SYSCOMMAND = 0x0112;       

    }
}
