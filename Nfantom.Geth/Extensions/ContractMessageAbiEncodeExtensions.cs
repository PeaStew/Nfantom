using Nfantom.ABI;
using Nfantom.Opera.CQS;

namespace Nfantom.Opera.Extensions
{
    public static class ContractMessageAbiEncodeExtensions
    {
        public static byte[] GetParamsEncoded<TContractMessage>(this TContractMessage contractMessage) where TContractMessage : ContractMessageBase
        {
            var encoder = new ABIEncode();
            return encoder.GetABIParamsEncoded(contractMessage);
        }

        public static byte[] GetParamsEncodedPacked<TContractMessage>(this TContractMessage contractMessage) where TContractMessage : ContractMessageBase
        {
            var encoder = new ABIEncode();
            return encoder.GetABIParamsEncodedPacked(contractMessage);
        }

        public static byte[] GetSha3ParamsEncoded<TContractMessage>(this TContractMessage contractMessage) where TContractMessage : ContractMessageBase
        {
            var encoder = new ABIEncode();
            return encoder.GetSha3ABIParamsEncoded(contractMessage);
        }

        public static byte[] GetSha3ParamsEncodedPacked<TContractMessage>(this TContractMessage contractMessage) where TContractMessage : ContractMessageBase
        {
            var encoder = new ABIEncode();
            return encoder.GetSha3ABIParamsEncodedPacked(contractMessage);
        }

    }
}