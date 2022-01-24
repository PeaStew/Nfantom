﻿using Nfantom.Hex.HexTypes;
using Newtonsoft.Json;
using System.Collections;
using System.Runtime.Serialization;

namespace Nfantom.RPC.Eth.DTOs
{
    [DataContract]
    public class Block
    {
        /// <summary>
        ///     QUANTITY - the block number. null when its pending block. 
        /// </summary>
        [DataMember(Name = "number")]
        public HexBigInteger Number { get; set; }

        /// <summary>
        ///     DATA, 32 Bytes - hash of the block.  
        /// </summary>
      [DataMember(Name = "hash")]
        public string BlockHash { get; set; }

        /// <summary>
        ///  block author.
        /// </summary>
      [DataMember(Name = "author")]
        public string Author { get; set; }


        /// <summary>
        ///  Seal fields. 
        /// </summary>
      [DataMember(Name = "sealFields")]
        public string[] SealFields { get; set; }

        /// <summary>
        ///     DATA, 32 Bytes - hash of the parent block. 
        /// </summary>
      [DataMember(Name = "parentHash")]
        public string ParentHash { get; set; }

        /// <summary>
        ///     DATA, 8 Bytes - hash of the generated proof-of-work. null when its pending block. 
        /// </summary>
      [DataMember(Name = "nonce")]
        public string Nonce { get; set; }

        /// <summary>
        ///     DATA, 32 Bytes - SHA3 of the uncles data in the block. 
        /// </summary>
      [DataMember(Name = "sha3Uncles")]
        public string Sha3Uncles { get; set; }


        /// <summary>
        ///     DATA, 256 Bytes - the bloom filter for the logs of the block. null when its pending block. 
        /// </summary>
      [DataMember(Name = "logsBloom")]
        public string LogsBloom { get; set; }


        /// <summary>
        ///     DATA, 32 Bytes - the root of the transaction trie of the block.
        /// </summary>
      [DataMember(Name = "transactionsRoot")]
        public string TransactionsRoot { get; set; }

        /// <summary>
        ///     DATA, 32 Bytes - the root of the final state trie of the block.
        /// </summary>
      [DataMember(Name = "stateRoot")]
        public string StateRoot { get; set; }

        /// <summary>
        ///     DATA, 32 Bytes - the root of the receipts trie of the block. 
        /// </summary>
      [DataMember(Name = "receiptsRoot")]
        public string ReceiptsRoot { get; set; }

        /// <summary>
        ///     DATA, 20 Bytes - the address of the beneficiary to whom the mining rewards were given.
        /// </summary>
      [DataMember(Name = "miner")]
        public string Miner { get; set; }

        /// <summary>
        ///     QUANTITY - integer of the difficulty for this block.   
        /// </summary>
      [DataMember(Name = "difficulty")]
        public HexBigInteger Difficulty { get; set; } 

        /// <summary>
        ///     QUANTITY - integer of the total difficulty of the chain until this block.
        /// </summary>
      [DataMember(Name = "totalDifficulty")]
        public HexBigInteger TotalDifficulty { get; set; }

        /// <summary>
        ///     DATA - the "mix hash" field of this block.  
        /// </summary>
      [DataMember(Name = "mixHash")]
        public string MixHash { get; set; }

        /// <summary>
        ///     DATA - the "extra data" field of this block.  
        /// </summary>
      [DataMember(Name = "extraData")]
        public string ExtraData { get; set; }

        /// <summary>
        ///     QUANTITY - integer the size of this block in bytes. 
        /// </summary>
      [DataMember(Name = "size")]
        public HexBigInteger Size { get; set; }

        /// <summary>
        ///     QUANTITY - the maximum gas allowed in this block. 
        /// </summary>
      [DataMember(Name = "gasLimit")]
        public HexBigInteger GasLimit { get; set; }

        /// <summary>
        ///     QUANTITY - the total used gas by all transactions in this block. 
        /// </summary>
      [DataMember(Name = "gasUsed")]
        public HexBigInteger GasUsed { get; set; }

        /// <summary>
        ///     QUANTITY - the unix timestamp for when the block was collated.
        /// </summary>
      [DataMember(Name = "timestamp")]
        public HexBigInteger Timestamp { get; set; }

        /// <summary>
        ///     Array - Array of uncle hashes.
        /// </summary>
      [DataMember(Name = "uncles")]
        public string[] Uncles { get; set; }

        /// <summary>
        ///     QUANTITY - the base fee per gas.
        /// </summary>
        [JsonProperty("baseFeePerGas")]
        public HexBigInteger BaseFeePerGas { get; set; }


    }
}

