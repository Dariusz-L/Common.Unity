using Common.Basic.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Unity.Components
{
    public static class AnimatorPlayExtensions
    {
        public static void Play(this IEnumerable<Animator> animators, string animatorStateName)
        {
            animators.ForEach(a => a?.Play(animatorStateName));
        }
    }
}
