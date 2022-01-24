using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;
using System.Numerics;
using System.Threading;
using Nfantom.RPC.Accounts;
using Nfantom.RPC.Fee1559Suggestions;
using Nfantom.RPC.TransactionReceipts;

namespace Nfantom.RPC.TransactionManagers
{
    public interface ITransactionManager
    {
        IClient Client { get; set; }
        BigInteger DefaultGasPrice { get; set; }
        BigInteger DefaultGas { get; set; }
        IAccount Account { get; }
        bool UseLegacyAsDefault { get; set; }
#if !DOTNET35
        IFee1559SuggestionStrategy Fee1559SuggestionStrategy { get; set; }

        Task<string> SendTransactionAsync(TransactionInput transactionInput);
        Task<HexBigInteger> EstimateGasAsync(CallInput callInput);
        Task<string> SendTransactionAsync(string from, string to, HexBigInteger amount);
        Task<string> SignTransactionAsync(TransactionInput transaction);
        ITransactionReceiptService TransactionReceiptService { get; set; }
        Task<TransactionReceipt> SendTransactionAndWaitForReceiptAsync(TransactionInput transactionInput, CancellationTokenSource tokenSource);
#endif

    }
}
