using System.Runtime.InteropServices;

namespace Netify.Core
{
    [TypeIdentifier("dcb00d01-570f-4a9b-8d69-199fdba5723b", "NETWORKLIST.NLM_CONNECTIVITY")]
    public enum NLM_CONNECTIVITY
    {
        NLM_CONNECTIVITY_DISCONNECTED = 0,
        NLM_CONNECTIVITY_IPV4_NOTRAFFIC = 1,
        NLM_CONNECTIVITY_IPV6_NOTRAFFIC = 2,
        NLM_CONNECTIVITY_IPV4_SUBNET = 16,
        NLM_CONNECTIVITY_IPV4_LOCALNETWORK = 32,
        NLM_CONNECTIVITY_IPV4_INTERNET = 64,
        NLM_CONNECTIVITY_IPV6_SUBNET = 256,
        NLM_CONNECTIVITY_IPV6_LOCALNETWORK = 512,
        NLM_CONNECTIVITY_IPV6_INTERNET = 1024
    }
}
