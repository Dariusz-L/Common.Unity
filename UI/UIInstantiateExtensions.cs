using Common.Basic.UMVC.Elements;
using Common.Unity.Components;
using Common.Unity.UI.UMCV;
using System;
using UnityEngine;

namespace Common.Unity.UI
{
    public static class UIInstantiateExtensions
    {
        public static void Instantiate<TView>(TView prefab, IView parent, Action<IView> onDone)
            where TView : Component
        {
            var spawned = GameObject.Instantiate(prefab, parent.ToTransform());

            var viewInterface = spawned.GetComponent<IView>();
            if (viewInterface == null)
                viewInterface = spawned.gameObject.AddComponent<View>();

            onDone(viewInterface);
        }

        public static bool Instantiate<TView, TViewInterface>(TView prefab, IView parent, Action<TViewInterface> onDone)
            where TView : Component
            where TViewInterface : IView
        {
            var spawned = GameObject.Instantiate(prefab, parent.ToTransform());
            onDone(spawned.GetComponent<TViewInterface>());

            return true;
        }
    }
}
