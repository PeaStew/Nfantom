using Nfantom.Util;
using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.Opera.CQS;

namespace Nfantom.Opera
{
    public class ContractDeploymentMessage : ContractMessageBase
    {

        public ContractDeploymentMessage(string byteCode)
        {
            ByteCode = byteCode;
        }

        /// <summary>
        /// ByteCode (Compiled code) used for deployment
        /// </summary>
        public string ByteCode { get; internal set; }

    }
}