using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Netify.Demo
{
    public static class Constants
    {
        public static readonly ImageSource ConnectedImage = new BitmapImage(new("\\Resources\\Images\\Connected.png", UriKind.Relative));
        public static readonly ImageSource DisconnectedImage = new BitmapImage(new("\\Resources\\Images\\Disconnected.png", UriKind.Relative));

        public const string ConnectedText = "You are online 😍";
        public const string DisconnectedText = "You are offline 😟";

        public const string GitHubPageUrl = "https://github.com/AmRo045/Netify";
        public const string NugetPageUrl = "https://www.nuget.org/packages/Netify";

        public static readonly SolidColorBrush ConnectedBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#4caf50");
        public static readonly SolidColorBrush DisconnectedBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#eb434d");
    }
}
