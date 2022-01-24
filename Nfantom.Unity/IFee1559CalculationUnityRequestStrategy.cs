using System;
using System.Collections;
using System.Numerics;
using Nfantom.RPC.Fee1559Suggestions;

namespace Nfantom.Unity
{
    public interface IFee1559SuggestionUnityRequestStrategy
    {
        IEnumerator SuggestFee(BigInteger? maxPriorityFeePerGas = null);
        Fee1559 Result { get; set; }
        Exception? Exception { get; set; }
    }
}