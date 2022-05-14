using System;
using UnityEngine;

namespace Common.Unity.Components
{
    public static class BehaviourEnabledExtensions
    {
        public static void SetEnabledIf(this Behaviour behaviour, Func<bool> predicate)
        {
            if (predicate())
                behaviour.enabled = true;
            else
                behaviour.enabled = false;
        }
    }
}
