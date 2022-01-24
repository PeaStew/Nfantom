using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC.NonceServices
{
    public interface INonceService
    {
        IClient Client { get; set; }
        Task<HexBigInteger> GetNextNonceAsync();
        Task ResetNonceAsync();
    }
}