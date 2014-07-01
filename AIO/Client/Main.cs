using NanoCore.ClientPlugin;
using NanoCore.ClientPluginHost;
using Network.Headers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    partial class Main : IClientNetwork
    {
        #region Plugin Hosts

        public IClientAppHost AppHost;
        public IClientDataHost DataHost;
        public IClientLoggingHost LoggingHost;
        public IClientNetworkHost NetworkHost;
        public IClientUIHost UIHost;

        #endregion

        #region Public Methods

        public Main(IClientAppHost appHost, IClientDataHost dataHost, IClientLoggingHost loggingHost,
            IClientNetworkHost networkHost, IClientUIHost uiHost)
        {
            AppHost = appHost;
            DataHost = dataHost;
            LoggingHost = loggingHost;
            NetworkHost = networkHost;
            UIHost = uiHost;
        }

        #endregion

        #region Network Callbacks

        public void HostConnectFailed(string host, ushort port)
        {
            //throw new NotImplementedException();
        }

        public void HostStateChanged(bool connected)
        {
            //throw new NotImplementedException();
        }

        public void PipeCreated(string pipeName)
        {
            //throw new NotImplementedException();
        }

        public void PipeDestroyed(string pipeName)
        {
            //throw new NotImplementedException();
        }

        public void ReadPacket(string pipeName, object[] @params)
        {
            Packets[(Commands)@params[0]].Handle(@params);
            LoggingHost.LogClientMessage(String.Concat("Packet recieved of type ", ((Commands)@params[0]).ToString()));
        }

        #endregion
    }
}
