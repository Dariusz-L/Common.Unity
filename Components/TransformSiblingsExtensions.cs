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

        public static int GetSiblingsCount(this Component component) => component.transform.parent.GetChildren<Transform>().Count() - 1;
        public static int GetSiblingIndexAndCount(this Component component, out int index)
        {
            index = component.transform.GetSiblingIndex();
            return component.GetSiblingsCount();
        }

        public static int GetSiblingsAndThisCount(this Component component) => component.GetSiblingsCount() + 1;
    }
}
