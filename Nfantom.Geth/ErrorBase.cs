using System;
using System.Collections.Generic;
using Nfantom.ABI.FunctionEncoding;
using Nfantom.ABI.Model;
using Nfantom.JsonRpc.Client;
using Nfantom.Geth.Builders;
using Nfantom.Geth.Extensions;

namespace Nfantom.Geth
{
    public class ErrorBase
    {
        public ErrorABI ErrorABI { get; protected set; }

        public ErrorBase(ErrorABI errorABI)
        {
            ErrorABI = errorABI;
        }

        public ErrorBase(Type errorTypeAbi)
        {
            ErrorABI = ABITypedRegistry.GetError(errorTypeAbi);
        }

        public bool IsExceptionEncodedDataForError(string data)
        {
            return ErrorABI.IsExceptionEncodedDataForError(data);
        }

        public bool IsExceptionForError(RpcResponseException exception)
        {
            return ErrorABI.IsExceptionForError(exception);
        }

        public List<ParameterOutput> DecodeExceptionEncodedDataToDefault(string data)
        {
            if (ErrorABI.IsExceptionEncodedDataForError(data))
            {
                return ErrorABI.DecodeExceptionEncodedDataToDefault(data);
            }
            return null;
        }
    }
}