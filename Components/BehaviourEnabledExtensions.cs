using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Unity.Components
{
    public static class BehaviourEnabledExtensions
    {
        public static void SetEnabled(this IEnumerable<Behaviour> behaviours, bool value)
        {
            foreach (var behaviour in behaviours)
                behaviour.enabled = value;
        }

        public static void SetEnabledIf(this Behaviour behaviour, Func<bool> predicate)
        {
            if (predicate())
                behaviour.enabled = true;
            else
                behaviour.enabled = false;
        }
    }
}
