using UnityEngine;

namespace Main
{
    /// <summary>
    /// 各シーンのMainクラスの基底クラス
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class MainBase : MonoBehaviour
    {
        protected abstract void Inject();
        protected abstract void OnAwake();
        protected abstract void OnStart();
        protected abstract void OnUpdate();

        private void Awake()
        {
            Inject();
            OnAwake();
        }

        private void Start()
        {
            OnStart();
        }

        private void Update()
        {
            OnUpdate();
        }
    }
}