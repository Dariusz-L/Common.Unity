using Common.Unity.GameObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common.Unity.Components
{
    public static class TransformSiblingsExtensions
    {
        public static IEnumerable<T> GetSiblingsAfter<T>(this T component)
            where T : Component
        {
            var parent = component.transform.parent;
            var parentChildren = parent.GetChildren<T>().ToList();
            var childrenBeforeAndThis = parentChildren.SkipWhile(c => !ReferenceEquals(c, component)).ToList();

            var childrenBefore = childrenBeforeAndThis.Skip(1).ToList();

            return childrenBefore;
        }

        public static IEnumerable<T> GetSiblingsAfter<T>(this IEnumerable<T> components) where T : Component
            => components.SelectMany(c => c.GetSiblingsAfter()).ToList();

        public static int GetSiblingsCount(this GameObject go) => go.transform.GetSiblingsCount();
        public static int GetSiblingsCount(this Component component) => component.transform.parent.GetChildren<Transform>().Count() - 1;

        public static int GetSiblingIndexAndCount(this GameObject go, out int index) => go.transform.GetSiblingIndexAndCount(out index);
        public static int GetSiblingIndexAndCount(this Component component, out int index)
        {
            index = component.transform.GetSiblingIndex();
            return component.GetSiblingsCount();
        }

        public static int GetSiblingsAndThisCount(this Component component) => component.GetSiblingsCount() + 1;

        public static void IncreaseSiblingIndexAndReactivateParent(this Transform transform)
        {
            transform.IncreaseSiblingIndexByOne();
            transform.ReactivateParent();
        }

        public static void DecreaseSiblingIndexAndReactivateParent(this Transform transform)
        {
            transform.DecreaseSiblingIndexByOne();
            transform.ReactivateParent();
        }

        public static void IncreaseSiblingIndexByOne(this Transform transform) =>
            transform.IncreaseSiblingIndexBy(1);

        public static void DecreaseSiblingIndexByOne(this Transform transform) =>
            transform.IncreaseSiblingIndexBy(-1);

        public static void IncreaseSiblingIndexBy(this Transform transform, int value)
        {
            int siblingIndex = transform.GetSiblingIndex();
            transform.SetSiblingIndex(siblingIndex + value);
        }

        public static bool IsFirstSibling(this GameObject go) => go.transform.IsFirstSibling();
        public static bool IsFirstSibling(this Transform transform)
        {
            int siblingsCount = transform.GetSiblingIndexAndCount(out int index);
            if (siblingsCount == 0)
                return true;

            return index == 0;
        }

        public static bool IsLastSibling(this GameObject go) => go.transform.IsLastSibling();
        public static bool IsLastSibling(this Transform transform)
        {
            int siblingsCount = transform.GetSiblingIndexAndCount(out int index);
            if (siblingsCount == 0)
                return true;

            return index == siblingsCount;
        }
    }
}
