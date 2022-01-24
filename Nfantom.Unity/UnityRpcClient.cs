using System;
using System.Text;
using Nfantom.Unity.RpcModel;
using Nfantom.JsonRpc.Client;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using RpcError = Nfantom.JsonRpc.Client.RpcError;
using RpcRequest = Nfantom.JsonRpc.Client.RpcRequest;


namespace Nfantom.Unity
{
    public class UnityRpcClient<TResult> : UnityRequest<TResult>, IClientRequestHeaderSupport
    {
        private readonly string _url;

        public Dictionary<string, string> RequestHeaders { get; set; } = new Dictionary<string, string>();

        protected UnityRpcClient(string url, JsonSerializerSettings? jsonSerializerSettings = null)
        {
            jsonSerializerSettings ??= DefaultJsonSerializerSettingsFactory.BuildDefaultJsonSerializerSettings();
            _url = url;
            this.SetBasicAuthenticationHeaderFromUri(new Uri(url));
            //check for nulls
            JsonSerializerSettings = jsonSerializerSettings;
        }

        private JsonSerializerSettings? JsonSerializerSettings { get; set; }

        private RpcResponseException? HandleRpcError(RpcResponse? response)
        {
            if (response is {HasError: true})
                return new RpcResponseException(new RpcError(response.Error.Code, response.Error.Message,
                    response.Error.Data));
            return null;
        }

        protected IEnumerator SendRequest(RpcRequest request)
        {
            var requestFormatted = new RpcModel.RpcRequest(request.Id, request.Method, request.RawParameters);

            var rpcRequestJson = JsonConvert.SerializeObject(requestFormatted, JsonSerializerSettings);
            var requestBytes = Encoding.UTF8.GetBytes(rpcRequestJson);
            using var unityRequest = new UnityWebRequest(_url, "POST");
            var uploadHandler = new UploadHandlerRaw(requestBytes);
            unityRequest.SetRequestHeader("Content-Type", "application/json");
            uploadHandler.contentType = "application/json";
            unityRequest.uploadHandler = uploadHandler;

            unityRequest.downloadHandler = new DownloadHandlerBuffer();

            foreach (var requestHeader in RequestHeaders)
            {
                unityRequest.SetRequestHeader(requestHeader.Key, requestHeader.Value);
            }

            yield return unityRequest.SendWebRequest();

            if (unityRequest.error != null)
            {
                Exception = new Exception(unityRequest.error);
#if DEBUG
                Debug.Log(unityRequest.error);
#endif
            }
            else
            {
                try
                {
                    byte[] results = unityRequest.downloadHandler.data;
                    var responseJson = Encoding.UTF8.GetString(results);
#if DEBUG
                    Debug.Log(responseJson);
#endif
                    var responseObject = JsonConvert.DeserializeObject<RpcResponse>(responseJson, JsonSerializerSettings);
                    Result = responseObject.GetResult<TResult>(true, JsonSerializerSettings);
                    Exception = HandleRpcError(responseObject);
                }
                catch (Exception ex)
                {
                    Exception = new Exception(ex.Message);
#if DEBUG
                    Debug.Log(ex.Message);
#endif
                }
            }
        }
    }
}
