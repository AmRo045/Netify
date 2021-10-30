namespace Netify.Demo
{
    public partial class MainWindow : INetworkObserver
    {
        private readonly INetworkStatusNotifier _networkStatusNotifier;

        public MainWindow(INetworkStatusNotifier networkStatusNotifier)
        {
            _networkStatusNotifier = networkStatusNotifier;
            _networkStatusNotifier.AddObserver(this);

            InitializeComponent();
        }

        public void ConnectivityChanged(ConnectivityStatus status)
        {
            
        }
    }
}
