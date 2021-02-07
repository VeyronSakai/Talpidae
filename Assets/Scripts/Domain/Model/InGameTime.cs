using UnityEngine;

namespace Domain.Model
{
    /// <summary>
    /// インゲームでの時間を表すEntity
    /// </summary>
    public sealed class InGameTime
    {
        public uint LeftTimeSeconds;
        private float _interval = 1f;

        public InGameTime(uint initialLimitTime)
        {
            LeftTimeSeconds = initialLimitTime;
        }

        public void OnUpdate()
        {
            _interval -= Time.deltaTime;

            if (_interval >= 0f) return;
            
            _interval = 1f;
            
            if(LeftTimeSeconds == 0) return;

            LeftTimeSeconds -= 1;
        }
    }
}