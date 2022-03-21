using System;
using UnityEngine.Events;

namespace Common.Unity.Scripts.Common
{
    public static class UnityEventToUnityThreadActionExtensions
    {
        public static Action<T1> RunOnUnityThread_Action<T1>(this UnityEvent<T1> action)
        {
            return arg1 => UnityThreadActionRunner.Run(() => action.Invoke(arg1));
        }

        public static Action<T1, T2> RunOnUnityThread_Action<T1, T2>(this UnityEvent<T1, T2> action)
        {
            return (arg1, arg2) => UnityThreadActionRunner.Run(() => action.Invoke(arg1, arg2));
        }

        public static Action<T1, T2, T3> RunOnUnityThread_Action<T1, T2, T3>(this UnityEvent<T1, T2, T3> action)
        {
            return (arg1, arg2, arg3) => UnityThreadActionRunner.Run(() => action.Invoke(arg1, arg2, arg3));
        }

        public static Action<T1, T2, T3, T4> RunOnUnityThread_Action<T1, T2, T3, T4>(this UnityEvent<T1, T2, T3, T4> action)
        {
            return (arg1, arg2, arg3, arg4) => UnityThreadActionRunner.Run(() => action.Invoke(arg1, arg2, arg3, arg4));
        }
    }
}
