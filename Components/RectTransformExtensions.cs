using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common.Unity.Components
{
    public static class RectTransformExtensions
    {
        public static RectTransform RT(this object @object) => (@object as Component).GetComponent<RectTransform>();
        public static RectTransform RT(this Component component) => component.GetComponent<RectTransform>();
        public static IEnumerable<RectTransform> RTs(this IEnumerable<object> components) => components.Cast<Component>().RTs();
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

        public static void AddWidth(this RectTransform rt, float value)
        {
            var source = rt.sizeDelta;
            source.x += value;
            rt.sizeDelta = source;
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

        public static void AddAnchoredPositionX(this RectTransform transform, float value)
        {
            var position = transform.anchoredPosition;
            position.x += value;
            transform.anchoredPosition = position;
        }

        public static void AddAnchoredPositionY(this RectTransform transform, float value)
        {
            var position = transform.anchoredPosition;
            position.y += value;
            transform.anchoredPosition = position;
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

        public static Vector2 GetWorldLeftCenter(this RectTransform transform)
        {
            var worldRect = transform.GetWorldRect();
            return new Vector2(worldRect.min.x, worldRect.center.y);
        }

        public static Vector2 GetWorldRightCenter(this RectTransform transform)
        {
            var worldRect = transform.GetWorldRect();
            return new Vector2(worldRect.max.x, worldRect.center.y);
        }

        public static Vector2 GetWorldTopCenter(this RectTransform transform)
        {
            var worldRect = transform.GetWorldRect();
            return new Vector2(worldRect.center.x, worldRect.max.y);
        }

        public static Vector2 GetWorldBottomCenter(this RectTransform transform)
        {
            var worldRect = transform.GetWorldRect();
            return new Vector2(worldRect.center.x, worldRect.min.y);
        }

        public static Rect GetWorldRect(this RectTransform rectTransform)
        {
            Vector3[] corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);
            
            Vector3 position = corners[0]; // Get the bottom left corner

            Vector2 size = new Vector2(
                rectTransform.lossyScale.x * rectTransform.rect.size.x,
                rectTransform.lossyScale.y * rectTransform.rect.size.y);

            return new Rect(position, size);
        }
    }
}
