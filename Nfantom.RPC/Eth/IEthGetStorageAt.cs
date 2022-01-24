using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth
{
    public interface IEthGetStorageAt
    {
        BlockParameter DefaultBlock { get; set; }

        RpcRequest BuildRequest(string address, HexBigInteger position, BlockParameter block, object id = null);
        Task<string> SendRequestAsync(string address, HexBigInteger position, object id = null);
        Task<string> SendRequestAsync(string address, HexBigInteger position, BlockParameter block, object id = null);
    }
}