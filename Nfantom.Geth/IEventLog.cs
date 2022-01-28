using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.Opera
{
    public interface IEventLog
    {
        FilterLog Log { get; }
    }
}