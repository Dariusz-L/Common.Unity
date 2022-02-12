using UnityEngine;

namespace Assets.Scripts.Common.Unity.Components
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

    }
}
