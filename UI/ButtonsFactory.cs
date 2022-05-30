using Common.Basic.Collections;
using Common.Unity.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.UI
{
    public static class ButtonsFactory
    {
        public static Button Create(Transform parent, string name = null)
        {
            var go = name.IsNullOrEmpty() ? new GameObject() : new GameObject(name);
            go.transform.SetParent(parent, worldPositionStays: true);
            go.AddComponent<RectTransform>();
            go.AddComponent<Image>().ToTransparentSingle();

            return go.AddComponent<Button>();
        }
    }
}
