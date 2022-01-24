using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.Uncles;

namespace Nfantom.RPC.Eth.Services
{
    public class EthApiUncleService : RpcClientWrapper, IEthApiUncleService
    {
        public EthApiUncleService(IClient client) : base(client)
        {
            GetUncleCountByBlockHash = new EthGetUncleCountByBlockHash(client);
            GetUncleCountByBlockNumber = new EthGetUncleCountByBlockNumber(client);
            GetUncleByBlockHashAndIndex = new EthGetUncleByBlockHashAndIndex(client);
            GetUncleByBlockNumberAndIndex = new EthGetUncleByBlockNumberAndIndex(client);
        }

        public IEthGetUncleCountByBlockHash GetUncleCountByBlockHash { get; private set; }
        public IEthGetUncleCountByBlockNumber GetUncleCountByBlockNumber { get; private set; }
        public IEthGetUncleByBlockHashAndIndex GetUncleByBlockHashAndIndex { get; private set; }
        public IEthGetUncleByBlockNumberAndIndex GetUncleByBlockNumberAndIndex { get; private set; }
    }
}