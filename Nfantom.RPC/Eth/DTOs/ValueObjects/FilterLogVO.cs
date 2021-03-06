using Nfantom.Hex.HexTypes;
using System.Numerics;

namespace Nfantom.RPC.Eth.DTOs.ValueObjects
{
    public class FilterLogVO
    {
        public FilterLogVO()
        { }

        public FilterLogVO(Transaction transaction, TransactionReceipt receipt, FilterLog log)
        {
            Transaction = transaction;
            Receipt = receipt;
            Log = log;
        }

        public Transaction Transaction { get; private set; }
        public TransactionReceipt Receipt { get; private set; }
        public FilterLog Log { get; private set; }
        public HexBigInteger LogIndex => Log?.LogIndex;
        public string Address => Log?.Address;

        //public string EventSignature => Log?.EventSignature();

        //public virtual bool IsForEvent<TEvent>() where TEvent : new()
        //{
        //    return Log?.IsLogForEvent<TEvent>() ?? false;
        //}

        //public virtual EventLog<TEvent> Decode<TEvent>() where TEvent : new()
        //{
        //    return Log?.DecodeEvent<TEvent>();
        //}

        public virtual bool IsTo(string toAddress)
        {
            return Transaction?.IsTo(toAddress) ?? false;
        }
    }
}