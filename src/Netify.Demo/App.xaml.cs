using System.Windows;

namespace Netify.Demo
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var networkStatusNotifier = new NetworkStatusNotifier();
            var mainWindow = new MainWindow(networkStatusNotifier);

            mainWindow.Loaded += (sender, args) => networkStatusNotifier.Start();
            mainWindow.Closing += (sender, args) => networkStatusNotifier.Stop();

            Current.MainWindow = mainWindow;
            Current.MainWindow.Show();
        }
    }
}
