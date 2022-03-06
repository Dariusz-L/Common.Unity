using UnityEngine;

namespace Common.Unity.Components
{
    public static class RectTransformFunctions
    {
        public static int GetCountByHeightIn(Component child, Component parent)
        {
            var childRT = child.GetComponent<RectTransform>();
            var parentRT = parent.GetComponent<RectTransform>();

            return GetCountByHeightIn(childRT, parentRT);
        }

        public static int GetCountByHeightIn(RectTransform child, RectTransform parent)
        {
            float childHeight = child.rect.height;
            float parentHeight = parent.rect.height;

            return (int) (parentHeight / childHeight);
        }

        public static void SetWidth(this RectTransform rt, float value)
        {
            var source = rt.sizeDelta;
            source.x = value;
            rt.sizeDelta = source;
        }
    }
}
