using Nfantom.ABI.Decoders;
using Nfantom.ABI.Encoders;

namespace Nfantom.ABI
{
    public class BytesElementaryType : ABIType
    {
        public BytesElementaryType(string name, int size) : base(name)
        {
            Decoder = new BytesElementaryTypeDecoder(size);
            Encoder = new BytesElementaryTypeEncoder(size);
        }
    }
}