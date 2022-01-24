using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Fee1559Suggestions;

namespace Nfantom.RPC
{
    public class FeeSuggestionService : RpcClientWrapper
    {
        public FeeSuggestionService(IClient client) : base(client)
        {
        }

#if !DOTNET35

        public SimpleFeeSuggestionStrategy GetSimpleFeeSuggestionStrategy()
        {
            return new SimpleFeeSuggestionStrategy(Client);
        }

        public TimePreferenceFeeSuggestionStrategy GeTimePreferenceFeeSuggestionStrategy()
        {
            return new TimePreferenceFeeSuggestionStrategy(Client);
        }

        public MedianPriorityFeeHistorySuggestionStrategy GetMedianPriorityFeeHistorySuggestionStrategy()
        {
            return new MedianPriorityFeeHistorySuggestionStrategy(Client);
        }
#endif
    }
}