namespace Nfantom.JsonRpc.Client.Streaming
{
    public interface IRpcStreamingSubscriptionHandler : IRpcStreamingResponseHandler
    {
        string SubscriptionId { get; }
        SubscriptionState SubscriptionState { get; }
    }
}