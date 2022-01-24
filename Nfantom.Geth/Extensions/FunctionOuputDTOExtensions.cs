using Nfantom.ABI.FunctionEncoding;
using Nfantom.ABI.FunctionEncoding.Attributes;

namespace Nfantom.Geth.Extensions
{
    public static class FunctionOuputDTOExtensions
    {
        private static readonly FunctionCallDecoder _functionCallDecoder = new FunctionCallDecoder();

        public static TFunctionOutputDTO DecodeOutput<TFunctionOutputDTO>(this TFunctionOutputDTO functionOuputDTO, string output) where TFunctionOutputDTO : IFunctionOutputDTO
        {
            return _functionCallDecoder.DecodeFunctionOutput(functionOuputDTO, output);
        }
    }
}