using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Netify.Core
{
    [ComImport]
    [Guid("DCB00000-570F-4A9B-8D69-199FDBA5723B")]
    [TypeIdentifier]
    public interface INetworkListManager
    {
        void _VtblGap1_6();

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(7)]
        NLM_CONNECTIVITY GetConnectivity();
    }
}
