using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Netify.Core
{
    [ComImport]
    [Guid("DCB00001-570F-4A9B-8D69-199FDBA5723B")]
    [InterfaceType(1)]
    [TypeIdentifier]
    public interface INetworkListManagerEvents
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void ConnectivityChanged([In] NLM_CONNECTIVITY newConnectivity);
    }
}
