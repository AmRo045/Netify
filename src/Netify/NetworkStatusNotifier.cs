using System.Collections.Generic;

namespace Netify
{
    public class NetworkStatusNotifier : INetworkStatusNotifier
    {
        private readonly HashSet<INetworkObserver> _observers = new();
        private readonly INetifyNetworkListManagerEvents _networkListManagerEvents;

        public NetworkStatusNotifier()
        {
            _observers = new();
            _networkListManagerEvents = new NetifyNetworkListManagerEvents();
            _networkListManagerEvents.ConnectivityStatusChanged += OnConnectivityStatusChanged;
        }

        private void OnConnectivityStatusChanged(ConnectivityStatus status) => NotifyObservers(status);

        private void NotifyObservers(ConnectivityStatus status)
        {
            foreach (var observer in _observers)
                observer.ConnectivityChanged(status);
        }

        public ConnectivityStatus CheckNow() => _networkListManagerEvents.GetCurrentStatus();
        public void AddObserver(INetworkObserver observer) => _observers.Add(observer);
        public void Start() => _networkListManagerEvents.Start();
        public void Stop() => _networkListManagerEvents.Stop();
    }
}
