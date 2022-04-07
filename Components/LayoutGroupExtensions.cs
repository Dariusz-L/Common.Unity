using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.Components
{
    public static class LayoutGroupExtensions
    {
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

        public static void FitRectLeftRightToLayoutGroup(this object @object) => ((Component) @object).FitRectLeftRightToLayoutGroup();
        public static void FitRectLeftRightToLayoutGroup(this Component component)
        {
            component.FitRectLeftToLayoutGroup();
            component.FitRectRightToLayoutGroup();
        }

        public static void FitRectLeftToLayoutGroup(this Component c) => c.SetLeft(c.GetGroupLeftPadding());
        public static void FitRectRightToLayoutGroup(this Component c) => c.SetRight(c.GetGroupRightPadding());

        public static void SetGroupLeftPadding(this Component component, int value) => component.GetComponent<LayoutGroup>().SetGroupLeftPadding(value);

        public static void SetGroupLeftPadding(this LayoutGroup lg, int value) => lg.padding.left = value;

        public static int GetGroupLeftPadding(this Component component) => component.GetComponent<LayoutGroup>().GetGroupLeftPadding();
        public static int GetGroupLeftPadding(this LayoutGroup lg) => lg.padding.left;

        public static void SetGroupRightPadding(this Component component, int value) => component.GetComponent<LayoutGroup>().SetGroupRightPadding(value);

        public static void SetGroupRightPadding(this LayoutGroup lg, int value) => lg.padding.right = value;

        public static int GetGroupRightPadding(this Component component) => component.GetComponent<LayoutGroup>().GetGroupRightPadding();
        public static int GetGroupRightPadding(this LayoutGroup lg) => lg.padding.right;

        public static void SetLayoutElementIgnore(this Component component, bool value) => component.GetComponent<LayoutElement>().ignoreLayout = value;
    }
}
