using Common.Unity.Components;
using Common.Unity.GameObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.UI
{
    public static class CanvasFactory
    {
        public static Canvas CreateCanvas(this Component parent) => CreateCanvas(parent.RT());
        public static Canvas CreateCanvas(this RectTransform parent)
        {
            var rt = RectTransformFactory.CreateRT(parent, "Canvas");
            return rt.AddCanvasComponents();
        }

        public static Canvas AddCanvasComponents(this RectTransform rt)
        {
            rt.gameObject.GetOrAddComponent<CanvasScaler>();
            rt.gameObject.GetOrAddComponent<GraphicRaycaster>();
            return rt.gameObject.GetOrAddComponent<Canvas>();
        }
    }
}
