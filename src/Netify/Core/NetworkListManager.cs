using System.Runtime.InteropServices;
using System;

namespace Netify.Core
{
    [ComImport]
    [Guid("DCB00000-570F-4A9B-8D69-199FDBA5723B")]
    [CoClass(typeof(NetworkListManagerClass))]
    [TypeIdentifier]
    public interface NetworkListManager : INetworkListManager, INetworkEvents_Event
    {
    }
}


