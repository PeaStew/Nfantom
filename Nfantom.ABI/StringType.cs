using Nfantom.ABI.Decoders;
using Nfantom.ABI.Encoders;

namespace Nfantom.ABI
{
    public class StringType : ABIType
    {
        public StringType() : base("string")
        {
            Decoder = new StringTypeDecoder();
            Encoder = new StringTypeEncoder();
        }

        public override int FixedSize => -1;
    }
}