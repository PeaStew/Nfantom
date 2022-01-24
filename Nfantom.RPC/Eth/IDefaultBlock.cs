using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth
{
    public interface IDefaultBlock
    {
        BlockParameter DefaultBlock { get; set; }
    }
}