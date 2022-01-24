using Nfantom.ABI.Decoders;
using Nfantom.ABI.Encoders;

namespace Nfantom.ABI
{
    public class BytesType : ABIType
    {
        public BytesType() : base("bytes")
        {
            Decoder = new BytesTypeDecoder();
            Encoder = new BytesTypeEncoder();
        }

        public override int FixedSize => -1;
    }
}