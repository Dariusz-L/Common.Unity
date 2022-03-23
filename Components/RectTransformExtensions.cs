using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.Components
{
    public static class RectTransformExtensions
    {
        public static RectTransform RT(this object @object) => (@object as Component).GetComponent<RectTransform>();
        public static RectTransform RT(this Component component) => component.GetComponent<RectTransform>();
        public static IEnumerable<RectTransform> RTs(this IEnumerable<Component> components) => components.Select(c => c.RT()).ToList();

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
        {
            var heights = rts.Select(rt => rt.rect.height);
            if (!heights.Any())
                return default;

            return heights.Aggregate((x, y) => x + y);
        }

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

        public static void FitToVerticalLayoutGroup(this Component component, IEnumerable<Component> layoutElements)
        {
            var propertiesHeight = layoutElements.GetHeight();
            var verticalLayoutExt = component.GetVerticalLayoutGroupHeightExt(layoutElements.Count());

            var totalHeight = propertiesHeight + verticalLayoutExt;
            component.GetComponent<RectTransform>().SetHeight(totalHeight);
        }

        public static void SetLeft(this Component rt, float left)
        {
            SetLeft(rt.GetComponent<RectTransform>(), left);
        }

        public static void SetRight(this Component rt, float right)
        {
            SetRight(rt.GetComponent<RectTransform>(), right);
        }

        public static void SetTop(this Component rt, float top)
        {
            SetTop(rt.GetComponent<RectTransform>(), top);
        }

        public static void SetBottom(this Component rt, float bottom)
        {
            SetBottom(rt.GetComponent<RectTransform>(), bottom);
        }

        public static void SetLeft(this RectTransform rt, float left)
        {
            rt.offsetMin = new Vector2(left, rt.offsetMin.y);
        }

        public static void SetRight(this RectTransform rt, float right)
        {
            rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
        }

        public static void SetTop(this RectTransform rt, float top)
        {
            rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
        }

        public static void SetBottom(this RectTransform rt, float bottom)
        {
            rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
        }

        public static void SetAnchoredPositionX(this RectTransform transform, float value)
        {
            var position = transform.anchoredPosition;
            position.x = value;
            transform.anchoredPosition = position;
        }

        public static void SetAnchoredPositionY(this RectTransform transform, float value)
        {
            var position = transform.anchoredPosition;
            position.y = value;
            transform.anchoredPosition = position;
        }

        public static void SetGroupLeftPadding(this Component component, int value) => component.GetComponent<LayoutGroup>().SetGroupLeftPadding(value);

        public static void SetGroupLeftPadding(this LayoutGroup lg, int value) => lg.padding.left = value;

        public static int GetGroupLeftPadding(this Component component) => component.GetComponent<LayoutGroup>().GetGroupLeftPadding();
        public static int GetGroupLeftPadding(this LayoutGroup lg) => lg.padding.left;
    }
}
