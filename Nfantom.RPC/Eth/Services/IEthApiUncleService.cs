using Nfantom.RPC.Eth.Uncles;

namespace Nfantom.RPC.Eth.Services
{
    public interface IEthApiUncleService
    {
        IEthGetUncleByBlockHashAndIndex GetUncleByBlockHashAndIndex { get; }
        IEthGetUncleByBlockNumberAndIndex GetUncleByBlockNumberAndIndex { get; }
        IEthGetUncleCountByBlockHash GetUncleCountByBlockHash { get; }
        IEthGetUncleCountByBlockNumber GetUncleCountByBlockNumber { get; }
    }
}