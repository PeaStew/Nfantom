using Nfantom.Geth.Extensions;
using System;

namespace Nfantom.Geth.Exceptions
{
    public class SmartContractCustomErrorRevertException : Exception
    {
        private const string ERROR_PREFIX = "Smart contract error";
        public string ExceptionEncodedData { get; set; }

        public SmartContractCustomErrorRevertException(string encodedData) : base(ERROR_PREFIX)
        {
            ExceptionEncodedData = encodedData;
        }

        public bool IsCustomErrorFor<TError>()
        {
            return ExceptionEncodedData.IsExceptionEncodedDataForError<TError>();
        }

        public TError DecodeError<TError>() where TError : class, new()
        {
            return ExceptionEncodedData.DecodeExceptionEncodedData<TError>();
        }
    }
}