using NETWORKLIST;
using System;

namespace Netify
{
    internal interface INetifyNetworkListManagerEvents : INetworkListManagerEvents
    {
        bool IsStarted { get; }

        event Action<ConnectivityStatus> ConnectivityStatusChanged;

        ConnectivityStatus GetCurrentStatus();
        void Start();
        void Stop();
    }
}
