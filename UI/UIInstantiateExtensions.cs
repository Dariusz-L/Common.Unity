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

        public static void Instantiate(Button prefab, IView parent, Action<IButtonView> onDone)
        {
            var button = GameObject.Instantiate(prefab, parent.ToTransform());
            onDone(button.GetComponent<IButtonView>());
        }
    }
}
