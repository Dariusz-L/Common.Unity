using Common.Basic.UMVC.Elements;
using Common.Unity.Components;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.UI
{
    public static class UIInstantiateExtensions
    {
        public static IButtonView InstantiateAndSetSprite(Button prefab, IView parent, Sprite sprite)
        {
            var button = GameObject.Instantiate(prefab, parent.ToTransform());
            button.SetSprite(sprite);

            return button.GetComponent<IButtonView>();
        }

        public static void Instantiate<TView, TViewInterface>(TView prefab, IView parent, Action<TViewInterface> onDone)
            where TView : Component
            where TViewInterface : IView
        {
            var spawned = GameObject.Instantiate(prefab, parent.ToTransform());
            onDone(spawned.GetComponent<TViewInterface>());
        }
    }
}
