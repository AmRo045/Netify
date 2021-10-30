namespace Netify
{
    public interface INetworkStatusNotifier
    {
        ConnectivityStatus CheckNow();
        void AddObserver(INetworkObserver observer);
        void Start();
        void Stop();
    }
}