using Common.Basic.UMVC.Elements;
using System;

namespace Common.Unity.UI.UMVC
{
    public static class AttachHandlerExtensions
    {
        public static Action<IButtonView> Attach<T1>(this Action<T1> handler, T1 arg)
            => btn => btn.OnUp = () => handler(arg);

        public static Action<IButtonView> Attach<T1, T2>(this Action<T1, T2> handler, T1 arg, T2 arg2)
            => btn => btn.OnUp = () => handler(arg, arg2);
    }
}
