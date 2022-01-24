using Newtonsoft.Json.Linq;
using Nfantom.ABI.FunctionEncoding;
using Nfantom.ABI.Model;
using Nfantom.Geth.Exceptions;
using Nfantom.Geth.Extensions;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nfantom.Geth
{
    public class Event : EventBase
    {
        public Event(Contract contract, EventABI eventABI) : this(contract.Eth.Client, contract.Address, eventABI)
        {
        }

        public Event(IClient client, string contractAddress, EventABI eventABI) : base(client, contractAddress, eventABI)
        {
        }
#if !DOTNET35
        public async Task<List<EventLog<T>>> GetAllChangesAsync<T>(NewFilterInput filterInput) where T : new()
        {
            if (!EventABI.IsFilterInputForEvent(ContractAddress, filterInput)) throw new Exception("Invalid filter input for current event, the filter input does not belong to this contract");
            var logs = await EthGetLogs.SendRequestAsync(filterInput).ConfigureAwait(false);
            return DecodeAllEvents<T>(logs);
        }

        public async Task<List<EventLog<T>>> GetAllChangesAsync<T>(HexBigInteger filterId) where T : new()
        {
            var logs = await EthFilterLogs.SendRequestAsync(filterId).ConfigureAwait(false);
            return DecodeAllEvents<T>(logs);
        }

        public async Task<List<EventLog<T>>> GetFilterChangesAsync<T>(HexBigInteger filterId) where T : new()
        {
            var logs = await EthGetFilterChanges.SendRequestAsync(filterId).ConfigureAwait(false);
            return DecodeAllEvents<T>(logs);
        }


        public async Task<List<EventLog<List<ParameterOutput>>>> GetAllChangesDefaultAsync(NewFilterInput filterInput)
        {
            if (!EventABI.IsFilterInputForEvent(ContractAddress, filterInput)) throw new FilterInputNotForEventException();
            var logs = await EthGetLogs.SendRequestAsync(filterInput).ConfigureAwait(false);
            return EventABI.DecodeAllEventsDefaultTopics(logs);
        }

        public async Task<List<EventLog<List<ParameterOutput>>>> GetAllChangesDefaultAsync(HexBigInteger filterId)
        {
            var logs = await EthFilterLogs.SendRequestAsync(filterId).ConfigureAwait(false);
            return EventABI.DecodeAllEventsDefaultTopics(logs);
        }

        public async Task<List<EventLog<List<ParameterOutput>>>> GetFilterChangeDefaultAsync(HexBigInteger filterId)
        {
            var logs = await EthGetFilterChanges.SendRequestAsync(filterId).ConfigureAwait(false);
            return EventABI.DecodeAllEventsDefaultTopics(logs);
        }
#endif
        public List<EventLog<T>> DecodeAllEventsForEvent<T>(FilterLog[] logs) where T : new()
        {
            return EventABI.DecodeAllEvents<T>(logs);
        }

        public List<EventLog<T>> DecodeAllEventsForEvent<T>(JArray logs) where T : new()
        {
            return EventABI.DecodeAllEvents<T>(logs);
        }

        public List<EventLog<List<ParameterOutput>>> DecodeAllEventsDefaultForEvent(FilterLog[] logs)
        {
            return EventABI.DecodeAllEventsDefaultTopics(logs);
        }

        public List<EventLog<List<ParameterOutput>>> DecodeAllEventsDefaultForEvent(JArray logs)
        {
            return EventABI.DecodeAllEventsDefaultTopics(logs);
        }
    }
}