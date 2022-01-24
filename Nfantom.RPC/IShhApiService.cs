using Nfantom.RPC.Shh;

namespace Nfantom.RPC
{
    public interface IShhApiService
    {
        IShhKeyPair KeyPair { get; } 
        IShhSymKey SymKey { get; } 
        IShhMessageFilter MessageFilter { get; }
        IShhPost Post { get; }
        IShhVersion Version { get; }
    }
}