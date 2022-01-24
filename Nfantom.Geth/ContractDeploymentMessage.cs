using Nfantom.Util;
using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.Geth.CQS;

namespace Nfantom.Geth
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