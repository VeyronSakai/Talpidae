using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Animations
{
    public static class AnimationPlayer
    {
        public static void Play(UnityEngine.Animation animation, AnimationClip clip)
        {
            ThrowIfAnimationIsNull(animation);

            if (clip == null)
            {
                return;
            }

            animation.Play(clip.name);
        }

        public static async UniTask PlayAsync(UnityEngine.Animation animation, AnimationClip clip,
            CancellationToken cancellationToken = default)
        {
            ThrowIfAnimationIsNull(animation);

            if (clip == null)
            {
                return;
            }
            
            animation.Play(clip.name);

            await UniTask.WaitWhile(() => animation.IsPlaying(clip.name), PlayerLoopTiming.Update, cancellationToken);
        }

        private static void ThrowIfAnimationIsNull(UnityEngine.Animation animation)
        {
            if (animation == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}