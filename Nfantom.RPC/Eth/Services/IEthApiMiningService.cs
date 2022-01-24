using Nfantom.RPC.Eth.Mining;

namespace Nfantom.RPC.Eth.Services
{
    public interface IEthApiMiningService
    {
        IEthGetWork GetWork { get; }
        IEthHashrate Hashrate { get; }
        IEthMining IsMining { get; }
        IEthSubmitHashrate SubmitHashrate { get; }
        IEthSubmitWork SubmitWork { get; }
    }
}