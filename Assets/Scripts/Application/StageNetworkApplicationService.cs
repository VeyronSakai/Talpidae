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

        public StageNetworkApplicationService()
        {
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

            return CreateStage(stageInfo);
        }

        private Stage CreateStage(StageInfo stageInfo)
        {
            var stage = new Stage();

            foreach (var position in stageInfo.positions)
            {
                // CellTypeを取得
                var cellType = position.value switch
                {
                    "treasure" => CellType.Treasure,
                    "arrow-up" => CellType.ArrowUp,
                    "arrow-down" => CellType.ArrowDown,
                    "arrow-left" => CellType.ArrowLeft,
                    "arrow-right" => CellType.ArrowRight,
                    _ => throw new ArgumentException()
                };

                var treasureCell = stage.CreateCell(position.w, position.h, cellType);

                if (cellType == CellType.Treasure)
                {
                    stage.CreateRockAroundTreasure(treasureCell);
                }
            }

            return stage;
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