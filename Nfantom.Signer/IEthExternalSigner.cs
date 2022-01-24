using System.Threading.Tasks;
using Nfantom.Signer.Crypto;

namespace Nfantom.Signer
{
#if !DOTNET35

    public enum ExternalSignerTransactionFormat
    {
        RLP,
        Hash,
        Transaction
    }
    
#endif
}