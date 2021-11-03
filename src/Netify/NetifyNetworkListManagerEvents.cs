using Netify.Core;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Netify
{
    internal class NetifyNetworkListManagerEvents : INetifyNetworkListManagerEvents
    {
        private readonly NetworkListManager _networkListManager = new();
        private IConnectionPoint _connectionPoint;
        private int _cookie;

        public bool IsStarted { get; private set; }

        public event Action<ConnectivityStatus> ConnectivityStatusChanged;

        public void ConnectivityChanged(NLM_CONNECTIVITY newConnectivity)
        {
            var status = GetConnectivityStatus(newConnectivity);
            ConnectivityStatusChanged?.Invoke(status);
        }

        public ConnectivityStatus GetCurrentStatus()
            => GetConnectivityStatus(_networkListManager.GetConnectivity());

        public void Start()
        {
            if (!IsStarted)
            {
                var connectionPointContainer = (IConnectionPointContainer)_networkListManager;
                var eventGuid = typeof(INetworkListManagerEvents).GUID;
                connectionPointContainer.FindConnectionPoint(ref eventGuid, out _connectionPoint);

                if (_connectionPoint is null)
                    throw new InvalidComObjectException("Could not get an 'IConnectionPoint' from this computer.");

                _connectionPoint.Advise(this, out _cookie);
                IsStarted = true;
            }
        }

        public void Stop()
        {
            if (IsStarted)
            {
                _connectionPoint?.Unadvise(_cookie);
                IsStarted = false;
            }
        }

        private static ConnectivityStatus GetConnectivityStatus(NLM_CONNECTIVITY connectivity)
        {
            var hasIPV4Connection = (connectivity & NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV4_INTERNET) != 0;
            var hasIPV6Connection = (connectivity & NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV6_INTERNET) != 0;
            var isDisconnected = (connectivity & NLM_CONNECTIVITY.NLM_CONNECTIVITY_DISCONNECTED) != 0;

            return (hasIPV4Connection || hasIPV6Connection) && !isDisconnected
                ? ConnectivityStatus.Connected
                : ConnectivityStatus.Disconnected;
        }
    }
}
