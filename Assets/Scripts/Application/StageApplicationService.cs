using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Application
{
    public sealed class StageApplicationService
    {
        private const string StartStageEndpoint = "https://talpidae-backend.herokuapp.com/start";

        public StageApplicationService()
        {
        }

        public async UniTask StartStageAsync()
        {
            var webRequest = UnityWebRequest.Get(StartStageEndpoint);

            await webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                //通信失敗
                Debug.Log(webRequest.error);
            }
            else
            {
                var response = webRequest.downloadHandler.text;

                //通信成功
                Debug.Log(webRequest.downloadHandler.text);
            }
        }
    }
}