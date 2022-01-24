using Nfantom.ABI.FunctionEncoding.Attributes;
using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.Contracts.Extensions;

namespace Nfantom.Contracts.QueryHandlers.MultiCall
{
    public class MulticallInputOutput<TFunctionMessage, TFunctionOutput> : IMulticallInputOutput
        where TFunctionMessage : FunctionMessage, new()
        where TFunctionOutput : IFunctionOutputDTO, new()
    {
        public MulticallInputOutput(TFunctionMessage functionMessage, string contractAddressTarget)
        {
            Target = contractAddressTarget;
            Input = functionMessage;
        }

        public string Target { get; set; }
        public TFunctionMessage Input { get; set; }
        public TFunctionOutput Output { get; private set; }
        public byte[] RawOutput { get; private set; }

        public byte[] GetCallData()
        {
            return Input.GetCallData();
        }

        public void Decode(byte[] output)
        {
            Output = new TFunctionOutput().DecodeOutput(output.ToHex());
            RawOutput = output;
        }
    }
}