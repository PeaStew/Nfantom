using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.Geth
{
    public interface IEventLog
    {
        FilterLog Log { get; }
    }
}