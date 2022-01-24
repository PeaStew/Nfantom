using System.Runtime.Serialization;

namespace Nfantom.RPC.Eth.DTOs
{
    /// <summary>
    ///     Block including just the transaction hashes
    /// </summary>
    [DataContract]
    public class BlockWithTransactionHashes : Block
    {
        /// <summary>
        ///     Array - Array of transaction hashes
        /// </summary>
        [DataMember(Name = "transactions")]
        public string[] TransactionHashes { get; set; }
    }
}