using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Nfantom.ABI.FunctionEncoding;
using Nfantom.ABI.FunctionEncoding.Attributes;
using Nfantom.ABI.Model;
using Nfantom.RPC.Eth.DTOs.Comparers;
using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nfantom.Opera.Comparers;
using Nfantom.RPC.Eth.DTOs.ValueObjects;
using Nfantom.Opera.Extensions;
using Nfantom.Opera.Builders;
using Nfantom.Opera.Builders.FilterInput;
using Nfantom.Opera.Services;

namespace Nfantom.Opera.Extensions
{

    public static class EventExtensions
    {
        public static bool IsLogForEvent<TEventDTO>(this JToken log)
        {
            var eventABI = ABITypedRegistry.GetEvent<TEventDTO>();
            return eventABI.IsLogForEvent(log);
        }

        public static bool IsLogForEvent<TEventDTO>(this FilterLog log)
        {
            var eventABI = ABITypedRegistry.GetEvent<TEventDTO>();
            return eventABI.IsLogForEvent(log);
        }

        public static bool IsLogForEvent<TEventDTO>(this FilterLogVO filterLogVO)
        {
            if (filterLogVO.Log == null) return false;
            return filterLogVO.Log.IsLogForEvent<TEventDTO>();
        }

        public static bool IsFilterInputForEvent<TEventDTO>(string contractAddress,
            NewFilterInput filterInput)
        {
            var eventABI = ABITypedRegistry.GetEvent<TEventDTO>();
            return eventABI.IsFilterInputForEvent(contractAddress, filterInput);
        }

        public static bool IsLogForEvent(this EventABI eventABI, JToken log)
        {
            return IsLogForEvent(eventABI, JsonConvert.DeserializeObject<FilterLog>(log.ToString()));
        }

        public static bool IsLogForEvent(this EventABI eventABI, FilterLog log)
        {
            if (eventABI.IsAnonymous)
                return true;

            if (!eventABI.HasSameNumberOfIndexes(log)) return false;

            return log.IsLogForEvent(eventABI.Sha3Signature);
        }

        public static bool IsLogForEvent(this FilterLog log, string signature)
        {
            if (log.Topics != null && log.Topics.Length > 0)
            {
                var eventtopic = log.Topics[0].ToString();
                if (signature.IsTheSameHex(eventtopic))
                    return true;
            }
            return false;
        }

        public static EventABI GetEventABI<TEventDTO>() where TEventDTO : IEventDTO
        {
            var eventABI = ABITypedRegistry.GetEvent<TEventDTO>();
            return eventABI;
        }

        public static EventABI GetEventABI<TEventDTO>(this TEventDTO eventDTO) where TEventDTO : IEventDTO
        {
            var eventABI = ABITypedRegistry.GetEvent<TEventDTO>();
            return eventABI;
        }

        public static FilterInputBuilder<TEventDTO> GetFilterBuilder<TEventDTO>(this IEthApiContractService contractService) where TEventDTO : class, IEventDTO, new()
        {
            return new FilterInputBuilder<TEventDTO>();
        }

        public static FilterInputBuilder<TEventDTO> GetFilterBuilder<TEventDTO>(this Event<TEventDTO> e) where TEventDTO : class, IEventDTO, new()
        {
            return new FilterInputBuilder<TEventDTO>();
        }

        public static FilterInputBuilder<TEventDTO> GetFilterBuilder<TEventDTO>(this TEventDTO eventDTO) where TEventDTO : class, IEventDTO
        {
            return new FilterInputBuilder<TEventDTO>();
        }

        public static EventTopicBuilder GetTopicBuilder(this EventABI eventABI)
        {
            return new EventTopicBuilder(eventABI);
        }

        public static NewFilterInput CreateFilterInput(this EventABI eventABI, BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput((string)null, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetSignatureTopicAsTheOnlyTopic();
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput(this EventABI eventABI, string contractAddress, BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetSignatureTopicAsTheOnlyTopic();
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput(this EventABI eventABI, string[] contractAddress, BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetSignatureTopicAsTheOnlyTopic();
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput(this EventABI eventABI, string contractAddress, object[] filterTopic1, BlockParameter fromBlock = null,
            BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput(this EventABI eventABI, string[] contractAddress, object[] filterTopic1, BlockParameter fromBlock = null,
            BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput<T1>(this EventABI eventABI, string contractAddress, T1 filterTopic1,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput<T1>(this EventABI eventABI, string[] contractAddress, T1 filterTopic1,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput<T1>(this EventABI eventABI, T1 filterTopic1,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput((string)null, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1);
            return ethFilterInput;
        }
        public static NewFilterInput CreateFilterInput(this EventABI eventABI, string contractAddress, object[] filterTopic1, object[] filterTopic2,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1, filterTopic2);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput(this EventABI eventABI, string[] contractAddress, object[] filterTopic1, object[] filterTopic2,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1, filterTopic2);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput<T1, T2>(this EventABI eventABI, string contractAddress, T1 filterTopic1, T2 filterTopic2,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1, filterTopic2);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput<T1, T2>(this EventABI eventABI, string[] contractAddress, T1 filterTopic1, T2 filterTopic2,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1, filterTopic2);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput<T1, T2>(this EventABI eventABI, T1 filterTopic1, T2 filterTopic2,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput((string)null, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1, filterTopic2);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput(this EventABI eventABI, string contractAddress, object[] filterTopic1, object[] filterTopic2, object[] filterTopic3,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1, filterTopic2, filterTopic3);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput(this EventABI eventABI, string[] contractAddress, object[] filterTopic1, object[] filterTopic2, object[] filterTopic3,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1, filterTopic2, filterTopic3);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput<T1, T2, T3>(this EventABI eventABI, string contractAddress, T1 filterTopic1, T2 filterTopic2, T3 filterTopic3,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {

            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1, filterTopic2, filterTopic3);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput<T1, T2, T3>(this EventABI eventABI, string[] contractAddress, T1 filterTopic1, T2 filterTopic2, T3 filterTopic3,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput(contractAddress, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1, filterTopic2, filterTopic3);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput<T1, T2, T3>(this EventABI eventABI, T1 filterTopic1, T2 filterTopic2, T3 filterTopic3,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            var ethFilterInput = FilterInputBuilder.GetDefaultFilterInput((string)null, fromBlock, toBlock);
            ethFilterInput.Topics = eventABI.GetTopicBuilder().GetTopics(filterTopic1, filterTopic2, filterTopic3);
            return ethFilterInput;
        }

        public static NewFilterInput CreateFilterInput<T1>(this EventABI eventABI, T1[] filterOrTopics1,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            return eventABI.CreateFilterInput(filterOrTopics1.Cast<object>().ToArray()
                , fromBlock, toBlock);
        }

        public static NewFilterInput CreateFilterInput<T1>(this EventABI eventABI, string contractAddress, T1[] filterOrTopics1,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            return eventABI.CreateFilterInput(contractAddress, filterOrTopics1.Cast<object>().ToArray(),
                 fromBlock, toBlock);
        }

        public static NewFilterInput CreateFilterInput<T1>(this EventABI eventABI, string[] contractAddresses, T1[] filterOrTopics1,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            return eventABI.CreateFilterInput(contractAddresses, filterOrTopics1.Cast<object>().ToArray(),
                fromBlock, toBlock);
        }

        public static NewFilterInput CreateFilterInput<T1, T2>(this EventABI eventABI, T1[] filterOrTopics1, T2[] filterOrTopics2,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            return eventABI.CreateFilterInput(filterOrTopics1.Cast<object>().ToArray(), filterOrTopics2.Cast<object>().ToArray()
                , fromBlock, toBlock);
        }

        public static NewFilterInput CreateFilterInput<T1, T2>(this EventABI eventABI, string contractAddress, T1[] filterOrTopics1, T2[] filterOrTopics2,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            return eventABI.CreateFilterInput(contractAddress, filterOrTopics1.Cast<object>().ToArray(), filterOrTopics2.Cast<object>().ToArray()
                , fromBlock, toBlock);
        }

        public static NewFilterInput CreateFilterInput<T1, T2>(this EventABI eventABI, string[] contractAddresses, T1[] filterOrTopics1, T2[] filterOrTopics2,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            return eventABI.CreateFilterInput(contractAddresses, filterOrTopics1.Cast<object>().ToArray(), filterOrTopics2.Cast<object>().ToArray(),
                fromBlock, toBlock);
        }

        public static NewFilterInput CreateFilterInput<T1, T2, T3>(this EventABI eventABI, T1[] filterOrTopics1, T2[] filterOrTopics2, T3[] filterOrTopics3,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            return eventABI.CreateFilterInput(filterOrTopics1.Cast<object>().ToArray(), filterOrTopics2.Cast<object>().ToArray(),
                filterOrTopics3.Cast<object>().ToArray(), fromBlock, toBlock);
        }

        public static NewFilterInput CreateFilterInput<T1, T2, T3>(this EventABI eventABI, string contractAddress, T1[] filterOrTopics1, T2[] filterOrTopics2, T3[] filterOrTopics3,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            return eventABI.CreateFilterInput(contractAddress, filterOrTopics1.Cast<object>().ToArray(), filterOrTopics2.Cast<object>().ToArray(),
                filterOrTopics3.Cast<object>().ToArray(), fromBlock, toBlock);
        }

        public static NewFilterInput CreateFilterInput<T1, T2, T3>(this EventABI eventABI, string[] contractAddresses, T1[] filterOrTopics1, T2[] filterOrTopics2, T3[] filterOrTopics3,
            BlockParameter fromBlock = null, BlockParameter toBlock = null)
        {
            return eventABI.CreateFilterInput(contractAddresses, filterOrTopics1.Cast<object>().ToArray(), filterOrTopics2.Cast<object>().ToArray(),
                filterOrTopics3.Cast<object>().ToArray(), fromBlock, toBlock);
        }

        public static bool IsFilterInputForEvent(this EventABI eventABI, string contractAddress, NewFilterInput filterInput)
        {
            if (filterInput.Topics != null && filterInput.Topics.Length > 0)
            {
                if (!IsFilterInputForContractAddress(contractAddress, filterInput))
                {
                    return false;
                }

                if (eventABI.IsAnonymous)
                    return true;

                if (eventABI.IsTopicSignatureForEvent(filterInput.Topics[0]))
                    return true;
            }
            return false;
        }

        public static bool IsFilterInputForContractAddress(string contractAdress, NewFilterInput filterInput)
        {
            if (contractAdress == null) return true;
            if (filterInput.Address != null && filterInput.Address.Length > 0)
            {
                return filterInput.Address.Count(x =>
                           x.IsTheSameAddress(contractAdress)) > 0;

            }
            return false;
        }

        public static bool IsTopicSignatureForEvent(this EventABI eventABI, object topic)
        {
            if (topic is IEnumerable<object> topicArray)
            {
                return topicArray.Any(x => eventABI.Sha3Signature.IsTheSameHex(x.ToString()));
            }
            else
            {
                if (topic is string topicString)
                {
                    return eventABI.Sha3Signature.IsTheSameHex(topicString);
                }
            }
            return false;
        }

        public static JArray ConvertToJArray(this FilterLog[] filterLogs)
        {
            return JArray.FromObject(filterLogs);
        }

        public static JObject ConvertToJObject(this FilterLog filterLog)
        {
            return JObject.FromObject(filterLog);
        }

        public static FilterLog ConvertToFilterLog(this JObject log)
        {
            return JsonConvert.DeserializeObject<FilterLog>(log.ToString());
        }

        public static FilterLog[] ConvertToFilterLog(this JArray logs)
        {
            return JsonConvert.DeserializeObject<FilterLog[]>(logs.ToString());
        }

        public static FilterLog[] GetLogsForEvent(this EventABI eventABI, JArray logs)
        {
            var returnList = new List<FilterLog>();
            foreach (var log in logs)
            {
                var filterLog = JsonConvert.DeserializeObject<FilterLog>(log.ToString());
                if (IsLogForEvent(eventABI, filterLog))
                    returnList.Add(filterLog);
            }
            return returnList.ToArray();
        }

        public static List<EventLog<TEventDTO>> DecodeAllEvents<TEventDTO>(this JArray logs) where TEventDTO : new()
        {
            var eventABI = ABITypedRegistry.GetEvent<TEventDTO>();
            return eventABI.DecodeAllEvents<TEventDTO>(logs);
        }


        public static List<EventLog<TEventDTO>> DecodeAllEvents<TEventDTO>(this FilterLog[] logs) where TEventDTO : new()
        {
            var eventABI = ABITypedRegistry.GetEvent<TEventDTO>();
            return eventABI.DecodeAllEvents<TEventDTO>(logs);
        }

        public static List<EventLog<TEventDTO>> DecodeAllEvents<TEventDTO>(this TransactionReceipt transactionReceipt) where TEventDTO : new()
        {
            return transactionReceipt.Logs.DecodeAllEvents<TEventDTO>();
        }

        public static List<EventLog<TEventDTO>> DecodeAllEvents<TEventDTO>(this EventABI eventABI, JArray logs) where TEventDTO : new()
        {
            return eventABI.DecodeAllEvents<TEventDTO>(eventABI.GetLogsForEvent(logs));
        }

        public static List<EventLog<List<ParameterOutput>>> DecodeAllEventsDefaultTopics(this EventABI eventABI, JArray logs)
        {
            return eventABI.DecodeAllEventsDefaultTopics(eventABI.GetLogsForEvent(logs));
        }

        public static List<EventLog<List<ParameterOutput>>> DecodeAllEventsDefaultTopics(this EventABI eventABI, FilterLog[] logs)
        {
            var result = new List<EventLog<List<ParameterOutput>>>();
            if (logs == null) return null;

            foreach (var log in logs)
            {
                var eventDecoded = eventABI.DecodeEventDefaultTopics(log);
                if (eventDecoded != null)
                {
                    result.Add(eventDecoded);
                }
            }
            return result;
        }

        public static List<EventLog<TEventDTO>> DecodeAllEvents<TEventDTO>(this EventABI eventABI, FilterLog[] logs) where TEventDTO : new()
        {
            var result = new List<EventLog<TEventDTO>>();
            if (logs == null) return result;

            foreach (var log in logs)
            {
                var eventDecoded = eventABI.DecodeEvent<TEventDTO>(log);
                if (eventDecoded != null)
                {
                    result.Add(eventDecoded);
                }
            }
            return result;
        }

        public static EventLog<List<ParameterOutput>> DecodeEventDefaultTopics(this EventABI eventABI, FilterLog log)
        {
            if (!eventABI.IsLogForEvent(log)) return null;
            var eventDecoder = new EventTopicDecoder();
            var eventObject = eventDecoder.DecodeDefaultTopics(eventABI, log.Topics, log.Data);
            return new EventLog<List<ParameterOutput>>(eventObject, log);
        }

        public static EventLog<List<ParameterOutput>> DecodeEventDefaultTopics(this EventABI eventABI, JToken log)
        {
            return DecodeEventDefaultTopics(eventABI, JsonConvert.DeserializeObject<FilterLog>(log.ToString()));
        }

        public static EventLog<TEventDTO> DecodeEvent<TEventDTO>(this EventABI eventABI, FilterLog log) where TEventDTO : new()
        {
            if (!eventABI.IsLogForEvent(log)) return null;
            var eventDecoder = new EventTopicDecoder(eventABI.IsAnonymous);
            var eventObject = eventDecoder.DecodeTopics<TEventDTO>(log.Topics, log.Data);
            return new EventLog<TEventDTO>(eventObject, log);
        }

        public static EventLog<TEventDTO> DecodeEvent<TEventDTO>(this FilterLog log) where TEventDTO : new()
        {
            var eventABI = ABITypedRegistry.GetEvent<TEventDTO>();
            return eventABI.DecodeEvent<TEventDTO>(log);
        }

        public static TEventDTO DecodeEvent<TEventDTO>(this TEventDTO eventDTO, JToken log) where TEventDTO : IEventDTO
        {
            var filterLog = JsonConvert.DeserializeObject<FilterLog>(log.ToString());
            return DecodeEvent<TEventDTO>(eventDTO, filterLog);
        }

        public static TEventDTO DecodeEvent<TEventDTO>(this TEventDTO eventDTO, FilterLog log) where TEventDTO : IEventDTO
        {
            var eventABI = ABITypedRegistry.GetEvent<TEventDTO>();

            return eventDTO.DecodeEvent(eventABI, log);
        }

        public static TEventDTO DecodeEvent<TEventDTO>(this TEventDTO eventDTO, EventABI eventABI, FilterLog log) where TEventDTO : IEventDTO
        {
            if (!eventABI.IsLogForEvent(log)) return default;
            var eventDecoder = new EventTopicDecoder();
            return eventDecoder.DecodeTopics(eventDTO, log.Topics, log.Data);
        }

        public static bool IsLogForEvent<TEventDTO>(this TEventDTO eventDTO, JToken log) where TEventDTO : IEventDTO
        {
            return log.IsLogForEvent<TEventDTO>();
        }

        public static bool IsLogForEvent<TEventDTO>(this TEventDTO eventDTO, FilterLog log) where TEventDTO : IEventDTO
        {
            return log.IsLogForEvent<TEventDTO>();
        }

        public static bool HasSameNumberOfIndexes<TEventDTO>(FilterLog log) where TEventDTO : IEventDTO
        {
            var eventABI = ABITypedRegistry.GetEvent<TEventDTO>();
            return eventABI.HasSameNumberOfIndexes(log);
        }

        public static bool HasSameNumberOfIndexes<TEventDTO>(this TEventDTO eventDTO, FilterLog log) where TEventDTO : IEventDTO
        {
            return eventDTO.GetEventABI().HasSameNumberOfIndexes(log);
        }

        public static bool HasSameNumberOfIndexes(this EventABI eventAbi, FilterLog log)
        {
            return eventAbi.NumberOfIndexes == log.Topics?.Length - 1;
        }

        public static List<EventLog<TEventDTO>> DecodeAllEventsIgnoringIndexMisMatches<TEventDTO>(this FilterLog[] logs) where TEventDTO : class, new()
        {
            var list = new List<EventLog<TEventDTO>>();

            foreach (var log in logs)
            {
                if (log.IsLogForEvent<TEventDTO>())
                {
                    list.Add(log.DecodeEvent<TEventDTO>());
                }
            }

            return list;
        }

        public static FilterLog[] Sort(this IEnumerable<FilterLog> logs)
        {
            var list = logs.ToList();
            list.Sort(new FilterLogBlockNumberTransactionIndexLogIndexComparer());
            return list.ToArray();
        }

        public static EventLog<TEventDTO>[] Sort<TEventDTO>(this IEnumerable<EventLog<TEventDTO>> events) where TEventDTO : IEventDTO
        {
            var list = events.ToList();
            list.Sort(new EventLogBlockNumberTransactionIndexComparer<EventLog<TEventDTO>>());
            return list.ToArray();
        }

        public static string EventSignature(this FilterLog log) => log.GetTopic(0);
        public static string IndexedVal1(this FilterLog log) => log.GetTopic(1);
        public static string IndexedVal2(this FilterLog log) => log.GetTopic(2);
        public static string IndexedVal3(this FilterLog log) => log.GetTopic(3);
        public static string GetTopic(this FilterLog log, int number)
        {
            if (log.Topics == null) return null;

            if (log.Topics.Length > number)
                return log.Topics[number].ToString();

            return null;
        }


    }
}