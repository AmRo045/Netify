using System.ComponentModel;
using System.Windows.Media;

namespace Netify.Demo
{
    public partial class MainWindow : INetworkObserver, INotifyPropertyChanged
    {
        private readonly INetworkStatusNotifier _networkStatusNotifier;

        private string? _connectionStatusText;
        private SolidColorBrush? _connectionStatusBrush;
        private ImageSource? _connectionStatusImage;

        public MainWindow(INetworkStatusNotifier networkStatusNotifier)
        {
            _networkStatusNotifier = networkStatusNotifier;
            _networkStatusNotifier.AddObserver(this);

            InitializeComponent();
            SetCurrentStatus();

            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyname)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));

        public string ConnectionStatusText
        {
            get => _connectionStatusText!;
            set
            {
                _connectionStatusText = value;
                OnPropertyChanged(nameof(ConnectionStatusText));
            }
        }

        public SolidColorBrush ConnectionStatusBrush
        {
            get => _connectionStatusBrush!;
            set
            {
                _connectionStatusBrush = value;
                OnPropertyChanged(nameof(ConnectionStatusBrush));
            }
        }

        public ImageSource ConnectionStatusImage
        {
            get => _connectionStatusImage!;
            set
            {
                _connectionStatusImage = value;
                OnPropertyChanged(nameof(ConnectionStatusImage));
            }
        }

        public void ConnectivityChanged(ConnectivityStatus status)
            => UpdateUI(status);

        private void UpdateUI(ConnectivityStatus status)
        {
            Dispatcher.Invoke(() =>
            {
                if (status == ConnectivityStatus.Connected)
                {
                    ConnectionStatusText = Constants.ConnectedText;
                    ConnectionStatusBrush = Constants.ConnectedBrush;
                    ConnectionStatusImage = Constants.ConnectedImage;
                }
                else
                {
                    ConnectionStatusText = Constants.DisconnectedText;
                    ConnectionStatusBrush = Constants.DisconnectedBrush;
                    ConnectionStatusImage = Constants.DisconnectedImage;
                }
            });
        }

        private void SetCurrentStatus()
        {
            var currentStatus = _networkStatusNotifier.CheckNow();
            UpdateUI(currentStatus);
        }
    }
}
