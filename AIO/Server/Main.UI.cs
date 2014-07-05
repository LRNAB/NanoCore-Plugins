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
            #region Volume

            var volumeUp = new ContextEntry()
            {
                Name = "Up",
                Icon = "speaker-volume-up",
                ClickedCallback = VolumeUpCallBack
            };

            var volumeDown = new ContextEntry()
            {
                Name = "Down",
                Icon = "speaker-volume-none",
                ClickedCallback = VolumeDownCallBack
            };

            var volumeMute = new ContextEntry()
            {
                Name = "Mute",
                Icon = "speaker-volume-control-mute",
                ClickedCallback = VolumeMuteCallBack
            };

            var volume = new ContextEntry()
            {
                Name = "Volume",
                Icon = "speaker-volume",
                Children = new[] { volumeUp, volumeDown, volumeMute}
            };


            #endregion
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
                Children = new[] { monitor, volume }
            };

            UIHost.AddContextEntry(aio);
        }

        #region Volume CallBacks

        private void VolumeMuteCallBack(IServerClient[] clients, bool @checked)
        {
            if (clients.Length == 0)
                return;

            foreach (var client in clients)
            {
                SendCommand(client, new object[] { Commands.Volume, Volume.Mute });
            }
        }

        private void VolumeDownCallBack(IServerClient[] clients, bool @checked)
        {
            if (clients.Length == 0)
                return;

            foreach (var client in clients)
            {
                SendCommand(client, new object[] { Commands.Volume, Volume.Down });
            }
        }

        private void VolumeUpCallBack(IServerClient[] clients, bool @checked)
        {
            if (clients.Length == 0)
                return;

            foreach (var client in clients)
            {
                SendCommand(client, new object[] { Commands.Volume, Volume.Up });
            }
        }

        #endregion

        #region Monitor CallBacks

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

        #endregion
    }
}
