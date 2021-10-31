<div align="center">
    <img src="docs/icon/Netify.png" alt="Netify icon" />
    <h1>Netify</h1>
    <p>Instantly get notified when the network connection changes.</p>
    <a href="https://www.nuget.org/packages/Netify/">
        <img src="https://img.shields.io/nuget/vpre/Netify.svg?label=Netify&style=flat-square" />
    </a>
</div>

## Installation

You can add Netify to your project using .NET CLI:

```
dotnet add package Netify
```

or NuGet package manager console:

```
Install-Package Netify
```

## Example Usage

```c#
using Netify;
using static System.Console;

var networkStatusNotifier = new NetworkStatusNotifier();
var sampleApp = new SampleApp(networkStatusNotifier);

networkStatusNotifier.Start();
sampleApp.DoSomething();
networkStatusNotifier.Stop();

internal class SampleApp : INetworkObserver
{
    public SampleApp(INetworkStatusNotifier networkStatusNotifier)
    {
        networkStatusNotifier.AddObserver(this);
    }

    public void ConnectivityChanged(ConnectivityStatus status)
    {
        WriteLine($"Connectivity status changed: {status}");
    }

    public void DoSomething()
    {
        WriteLine("Change your connection status to see app reaction.");
        ReadKey();
    }
}
```

## Demo App
<p align="center">
    <img src="docs/screenshots/connected.png" alt="Netify Demo App - Connected" />
    <img src="docs/screenshots/disconnected.png" alt="Netify Demo App - Disconnected" />
</p>
