namespace Netify
{
    public interface INetworkObserver
    {
        void ConnectivityChanged(ConnectivityStatus status);
    }
}
