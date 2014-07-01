using NanoCore;
using NanoCore.ServerPlugin;
using NanoCore.ServerPluginHost;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Server
{
    partial class Main : IServerNetwork
    {
        #region Plugin Hosts

        public IServerDatabaseHost DatabaseHost;
        public IServerLoggingHost LoggingHost;
        public IServerNetworkHost NetworkHost;
        public IServerTransferHost TransferHost;
        public IServerUIHost UIHost;

        #endregion

        #region Public Methods

        public Main(IServerDatabaseHost databaseHost, IServerLoggingHost loggingHost, IServerNetworkHost networkHost,
            IServerTransferHost transferHost, IServerUIHost uiHost)
        {
            DatabaseHost = databaseHost;
            LoggingHost = loggingHost;
            NetworkHost = networkHost;
            TransferHost = transferHost;
            UIHost = uiHost;

            InitializeUI();
        }

        public void SendCommand(IServerClient client, object[] parameters)
        {
            NetworkHost.SendToClient(client, null, true, parameters);
        }

        #endregion

        #region Network Callbacks

        public void ClientPipeCreated(NanoCore.IServerClient client, string pipeName)
        {
            //throw new NotImplementedException();
        }

        public void ClientPipeDestroyed(NanoCore.IServerClient client, string pipeName)
        {
            //throw new NotImplementedException();
        }

        public void ClientReadPacket(NanoCore.IServerClient client, string pipeName, object[] @params)
        {
            //throw new NotImplementedException();
        }

        public void ClientStateChanged(NanoCore.IServerClient client, bool connected)
        {
            //throw new NotImplementedException();
        }

        public void HostListenFailed(ushort port)
        {
            //throw new NotImplementedException();
        }

        public void HostStateChanged(ushort port, bool listening)
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}
