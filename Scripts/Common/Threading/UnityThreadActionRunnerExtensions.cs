using System;
using UnityEngine.Events;

namespace Common.Unity.Scripts.Common
{
    public static class UnityThreadActionRunnerExtensions
    {
        public static Action<T1, T2> RunOnUnityThread_Action<T1, T2>(this UnityEvent<T1, T2> action)
        {
            return (arg1, arg2) => UnityThreadActionRunner.Run(() => action.Invoke(arg1, arg2));
        }
    }
}
