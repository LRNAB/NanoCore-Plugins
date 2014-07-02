using NanoCore;
using System;
using System.Collections.Generic;
using System.Text;
using Network.Headers;

namespace Server
{
    partial class Main
    {
        public void InitializeUI()
        {
            #region Monitor

            var rotate90CW = new ContextEntry()
            {
                Name = "Rotate 90 CW",
                Icon = "arrow-turn",
                ClickedCallback = rotate90CWCallBack
            };

            var turnMonitorOff = new ContextEntry()
            {
                Name = "Turn Off",
                Icon = "remove",
                ClickedCallback = turnMonitorOffCallBack
            };

            var turnMonitorOn = new ContextEntry()
            {
                Name = "Turn On",
                Icon = "tick",
                ClickedCallback = turnMonitorOnCallback
            };

            var monitor = new ContextEntry()
            {
                Name = "Monitor",
                Icon = "television",
                ClickedCallback = null,
                Children = new[] { turnMonitorOff, turnMonitorOn, rotate90CW }
            };

            #endregion

            var aio = new ContextEntry()
            {
                Name = "AIO",
                Icon = "arrow-in",
                ClickedCallback = null,
                Children = new[] { monitor }
            };

            UIHost.AddContextEntry(aio);
        }

        private void rotate90CWCallBack(IServerClient[] clients, bool @checked)
        {
            if (clients.Length == 0)
                return;

            foreach (var client in clients)
            {
                SendCommand(client, new object[] { Commands.Monitor, Monitor.Rotate90CW });
            }
        }

        private void turnMonitorOnCallback(IServerClient[] clients, bool @checked)
        {
            if (clients.Length == 0)
                return;

            foreach (var client in clients)
            {
                SendCommand(client, new object[] { Commands.Monitor, Monitor.TurnOn });
            }
        }

        private void turnMonitorOffCallBack(IServerClient[] clients, bool @checked)
        {
            if (clients.Length == 0)
                return;

            foreach (var client in clients)
            {
                SendCommand(client, new object[] { Commands.Monitor, Monitor.TurnOff });
            }
        }
    }
}
