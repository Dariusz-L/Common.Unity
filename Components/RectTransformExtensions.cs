using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.Components
{
    public static class RectTransformExtensions
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

        public static void SetHeight(this RectTransform rt, float value)
        {
            var source = rt.sizeDelta;
            source.y = value;
            rt.sizeDelta = source;
        }

        public static float GetHeight(this IEnumerable<Component> uiComponents) => uiComponents.Select(c => c.GetComponent<RectTransform>()).GetHeight();

        public static float GetHeight(this IEnumerable<RectTransform> rts)
            => rts
                .Select(rt => rt.rect.height)
                .Aggregate((x, y) => x + y);

        public static float GetVerticalLayoutGroupHeightExt(this Component component, int itemsCount)
            => component.GetComponent<VerticalLayoutGroup>().GetVerticalLayoutGroupHeightExt(itemsCount);

        public static float GetVerticalLayoutGroupHeightExt(this VerticalLayoutGroup lg, int itemsCount)
        {
            if (!lg)
                return 0;

            var spacing = lg.spacing * (itemsCount - 1);
            if (spacing < 0)
                spacing = 0;

            return spacing + lg.padding.top + lg.padding.bottom;
        }

        public static void FitToVerticalLayoutGroup(this Component component)
        {
            var visibleChildren = component.GetVisibleChildren().ToList();

            var propertiesHeight = visibleChildren.GetHeight();
            var verticalLayoutExt = component.GetVerticalLayoutGroupHeightExt(visibleChildren.Count);

            var totalHeight = propertiesHeight + verticalLayoutExt;
            component.GetComponent<RectTransform>().SetHeight(totalHeight);
        }
    }
}
