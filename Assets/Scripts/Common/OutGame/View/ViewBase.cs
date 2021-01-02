using Cysharp.Threading.Tasks;
using PrefabGenerator;
using UnityEngine;

namespace Common.OutGame.View
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animation))]
    public abstract class ViewBase : PrefabBase
    {
        [SerializeField] private AnimationClip openClip = default;
        [SerializeField] private AnimationClip closeClip = default;

        private Animation _animation;

        public void PlayOpenAnimation()
        {
            GetAnimation();
            AnimationPlayer.Play(_animation, openClip);
        }

        public void PlayCloseAnimation()
        {
            GetAnimation();
            AnimationPlayer.Play(_animation, closeClip);
        }

        public async UniTask PlayOpenAnimationAsync()
        {
            GetAnimation();
            await AnimationPlayer.PlayAsync(_animation, openClip);
        }
        
        public async UniTask PlayCloseAnimationAsync()
        {
            GetAnimation();
            await AnimationPlayer.PlayAsync(_animation, closeClip);
        }
        
        private void GetAnimation()
        {
            if (_animation == null)
            {
                _animation = GetComponent<Animation>();
            }
        }
    }
}