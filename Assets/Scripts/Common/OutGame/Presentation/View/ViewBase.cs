using Common.Animations;
using Cysharp.Threading.Tasks;
using PrefabGenerator;
using UnityEngine;

namespace Common.OutGame.Presentation.View
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(UnityEngine.Animation))]
    public abstract class ViewBase : PrefabBase
    {
        [SerializeField] private AnimationClip openClip = default;
        [SerializeField] private AnimationClip closeClip = default;

        private UnityEngine.Animation _animation;

        public void PlayOpenAnimation()
        {
            SetAnimation();
            AnimationPlayer.Play(_animation, openClip);
        }

        public void PlayCloseAnimation()
        {
            SetAnimation();
            AnimationPlayer.Play(_animation, closeClip);
        }

        public async UniTask PlayOpenAnimationAsync()
        {
            SetAnimation();
            await AnimationPlayer.PlayAsync(_animation, openClip);
        }

        public async UniTask PlayCloseAnimationAsync()
        {
            SetAnimation();
            await AnimationPlayer.PlayAsync(_animation, closeClip);
        }

        private void SetAnimation()
        {
            if (_animation == null)
            {
                _animation = GetComponent<UnityEngine.Animation>();
            }
        }
    }
}