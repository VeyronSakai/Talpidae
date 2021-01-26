using System;
using Cysharp.Threading.Tasks;
using Domain.Model;
using UnityEngine;
using UnityEngine.Networking;

namespace Application
{
    public class StageNetworkApplicationService
    {
        // private const string StartStageEndpoint = "https://talpidae-backend.herokuapp.com/start";
        private const string StartStageEndpoint = "http://localhost:8080/start";
        private readonly IStageFactory _stageFactory;

        public StageNetworkApplicationService(IStageFactory stageFactory)
        {
            _stageFactory = stageFactory;
        }

        public async UniTask<Stage> GetStageStartAsync()
        {
            var webRequest = UnityWebRequest.Get(StartStageEndpoint);

            await webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                throw new UnityWebRequestException(webRequest);
            }

            var response = webRequest.downloadHandler.text;

            var stageInfo = JsonUtility.FromJson<StageInfo>(response);

            return _stageFactory.Create(stageInfo);
        }
    }

    [Serializable]
    public class StageInfo
    {
        public Position[] positions;
    }

    [Serializable]
    public class Position
    {
        public int w;
        public int h;
        public string value;
    }
}