using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.Contracts
{
    public interface IEventLog
    {
        FilterLog Log { get; }
    }
}