using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Client.Core
{
    class NativeMethods
    {
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        internal static extern void SendMessage(int hWnd, int uMsg, int wParam, int lParam);
    }
}
