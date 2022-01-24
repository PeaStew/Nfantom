using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.KeyStore.Model;
using Newtonsoft.Json;

namespace Nfantom.KeyStore.JsonDeserialisation
{
    public class CryptoInfoPbkdf2DTO : CryptoInfoDTOBase
    {
        public CryptoInfoPbkdf2DTO()
        {
            kdfparams = new Pbkdf2ParamsDTO();
        }

        public Pbkdf2ParamsDTO kdfparams { get; set; }
    }
}