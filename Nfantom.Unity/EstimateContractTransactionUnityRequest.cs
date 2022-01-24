using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Nfantom.Contracts;
using Nfantom.Contracts.CQS;
using Nfantom.Contracts.Extensions;
using Nfantom.Hex.HexTypes;
using Nfantom.RPC.TransactionManagers;

namespace Nfantom.Unity
{
    public class EstimateContractTransactionUnityRequest : UnityRequest<HexBigInteger>
    {
        private string _url;
        private readonly EthEstimateGasUnityRequest _ethEstimateGasUnityRequest;

        public EstimateContractTransactionUnityRequest(string url, string privateKey, string account, Dictionary<string, string> requestHeaders = null)
        {
            _url = url;
            _ethEstimateGasUnityRequest = new EthEstimateGasUnityRequest(url)
            {
                RequestHeaders = requestHeaders
            };
        }

        public IEnumerator EstimateContractFunction<TContractFunction>(TContractFunction function, string contractAdress) where TContractFunction : FunctionMessage
        {
            var callInput = function.CreateCallInput(contractAdress);
            yield return _ethEstimateGasUnityRequest.SendRequest(callInput);
        }

        public IEnumerator EstimateContractDeployment<TDeploymentMessage>(TDeploymentMessage deploymentMessage) where TDeploymentMessage : ContractDeploymentMessage
        {
            var callInput = deploymentMessage.CreateCallInput();
            yield return _ethEstimateGasUnityRequest.SendRequest(callInput);
        }
    }
}