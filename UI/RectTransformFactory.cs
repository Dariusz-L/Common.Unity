using Common.Basic.Collections;
using Common.Unity.Components;
using Common.Unity.GameObjects;
using UnityEngine;

namespace Common.Unity.UI
{
    public static class RectTransformFactory
    {
        public static RectTransform CreateRT(this Component parent, string name = null) => CreateRT(parent.RT(), name);
        public static RectTransform CreateRT(this RectTransform parent, string name = null)
        {
            var go = name.IsNullOrEmpty() ? new GameObject() : new GameObject(name);
            go.transform.SetParent(parent, worldPositionStays: true);
            go.GetOrAddComponent<RectTransform>();

            return go.GetComponent<RectTransform>();
        }
    }
}
