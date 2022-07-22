using Common.Basic.Collections;
using Common.Unity.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.Components
{
    public static class LayoutGroupExtensions
    {
        public static float GetLayoutGroupHeightExt(this Component component, int itemsCount)
            => component.GetComponent<HorizontalOrVerticalLayoutGroup>().GetLayoutGroupHeightExt(itemsCount);

        public static float GetLayoutGroupHeightExt(this HorizontalOrVerticalLayoutGroup lg, int itemsCount)
        {
            if (!lg)
                return 0;

            var spacing = lg.spacing * (itemsCount - 1);
            if (spacing < 0)
                spacing = 0;

            if (lg is VerticalLayoutGroup)
                return spacing + lg.padding.top + lg.padding.bottom;

            if (lg is HorizontalLayoutGroup)
                return spacing + lg.padding.right + lg.padding.left;

            return spacing;
        }

        public static float GetLayoutHeight(this Component component)
        {
            var contentChildren = component.GetChildren<RectTransform>();
            var propertiesHeight = contentChildren.GetHeight();
            var verticalLayoutExt = component.GetLayoutGroupHeightExt(contentChildren.Count());

            var totalHeight = propertiesHeight + verticalLayoutExt;

            return totalHeight;
        }

        public static void FitToLayoutGroup(this Component component, IEnumerable<Component> layoutElements)
        {
            var propertiesHeight = layoutElements.GetHeight();
            var verticalLayoutExt = component.GetLayoutGroupHeightExt(layoutElements.Count());

            var totalHeight = propertiesHeight + verticalLayoutExt;
            component.GetComponent<RectTransform>().SetHeight(totalHeight);
        }

        public static void FitParentToItsLayoutGroup<TLayoutItem>(this TLayoutItem layoutGroupParent)
            where TLayoutItem : Component
        {
            var parent = layoutGroupParent.transform.parent;
            parent.FitToLayoutGroup(parent);
        }

        public static void FitToLayoutGroup<TLayoutItem>(this TLayoutItem layoutGroupParent, Component layoutGroup)
            where TLayoutItem : Component
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.RT());

            var items = layoutGroup.GetChildren<TLayoutItem>(includeInactive: false).ToArray();
            var propertiesHeight = items.GetHeight();
            var verticalLayoutExt = layoutGroupParent.GetLayoutGroupHeightExt(0);
            verticalLayoutExt += layoutGroup.GetLayoutGroupHeightExt(items.Count());

            var totalHeight = propertiesHeight + verticalLayoutExt;
            layoutGroupParent.RT().SetHeight(totalHeight + 25);
        }

        public static void FitToLayoutGroup<T>(this T component, Func<T, Transform> getLayout)
            where T : Component
        {
            var rt = component.GetComponent<RectTransform>();

            var layout = getLayout(component);
            rt.FitToLayoutGroup(layout);

            var parentComponent = component.GetComponentInParentButNotThis<T>();
            if (parentComponent != null)
            {
                var parentLayout = getLayout(parentComponent);
                parentComponent.FitToLayoutGroup(parentLayout);
            }
            else
            {
                var parentRT = rt.parent.RT();
                parentRT.FitToLayoutGroup(parentRT);
            }
        }

        public static void FitRectLeftRightToLayoutGroup(this object @object) => ((Component) @object).FitRectLeftRightToLayoutGroup();
        public static void FitRectLeftRightToLayoutGroup(this Component component)
        {
            component.FitRectLeftToLayoutGroup();
            component.FitRectRightToLayoutGroup();
        }

        public static void FitRectLeftToLayoutGroup(this Component c) => c.SetLeft(c.GetGroupLeftPadding());
        public static void FitRectRightToLayoutGroup(this Component c) => c.SetRight(c.GetGroupRightPadding());

        public static void SetChildExpand(this Component component, bool value) => component.GetComponent<HorizontalOrVerticalLayoutGroup>().SetChildExpand(value);
        public static void SetChildExpand(this HorizontalOrVerticalLayoutGroup component, bool value)
        {
            component.childForceExpandHeight = value;
            component.childForceExpandWidth = value;
        }

        public static bool GetChildExpand(this Component component)
        {
            var layout = component.GetComponent<HorizontalOrVerticalLayoutGroup>();
            if (!layout)
                return false;

            if (layout is VerticalLayoutGroup)
                return layout.childForceExpandHeight;

            return layout.childForceExpandWidth;
        }

        public static TextAnchor GetGroupAlignment(this Component component)
        {
            var layout = component.GetComponent<LayoutGroup>();
            if (!layout)
                return TextAnchor.MiddleLeft;

            return layout.childAlignment;
        }

        public static void SetGroupAlignment(this Component component, TextAnchor value) => component.GetComponent<LayoutGroup>().childAlignment = value;

        public static void SetGroupLeftPadding(this Component component, int value) => component.GetComponent<LayoutGroup>().SetGroupLeftPadding(value);

        public static void SetGroupLeftPadding(this LayoutGroup lg, int value) => lg.padding.left = value;

        public static int GetGroupLeftPadding(this Component component) => component.GetComponent<LayoutGroup>().GetGroupLeftPadding();
        public static int GetGroupLeftPadding(this LayoutGroup lg) => lg.padding.left;

        public static void SetGroupRightPadding(this Component component, int value) => component.GetComponent<LayoutGroup>().SetGroupRightPadding(value);

        public static void SetGroupRightPadding(this LayoutGroup lg, int value) => lg.padding.right = value;

        public static int GetGroupRightPadding(this Component component) => component.GetComponent<LayoutGroup>().GetGroupRightPadding();
        public static int GetGroupRightPadding(this LayoutGroup lg) => lg.padding.right;

        public static void SetLayoutElementIgnore(this IEnumerable<object> components, IEnumerable<bool> values)
            => components.Zip(values, (c, v) => new Tuple<object, bool>(c, v)).ForEach(cv => cv.Item1.SetLayoutElementIgnore(cv.Item2));

        public static void SetLayoutElementIgnore(this IEnumerable<object> components, bool value) => components.Cast<Component>().ForEach(c => c.SetLayoutElementIgnore(value));
        public static void SetLayoutElementIgnore(this IEnumerable<Component> components, bool value) => components.ForEach(c => c.SetLayoutElementIgnore(value));
        public static void SetLayoutElementIgnore(this object component, bool value) => (component as Component).SetLayoutElementIgnore(value);
        public static void SetLayoutElementIgnore(this Component component, bool value) => component.GetComponent<LayoutElement>().ignoreLayout = value;

        public static IEnumerable<bool> GetLayoutElementIgnore(this IEnumerable<object> components) => components.Cast<Component>().GetLayoutElementIgnore();
        public static IEnumerable<bool> GetLayoutElementIgnore(this IEnumerable<Component> components) => components.Select(c => c.GetLayoutElementIgnore());
        public static bool GetLayoutElementIgnore(this Component component) => component.GetComponent<LayoutElement>().ignoreLayout;
    }
}
