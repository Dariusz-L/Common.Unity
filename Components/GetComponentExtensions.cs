using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common
{
    public static class GetComponentExtensions
    {
        public static IEnumerable<T> GetThisAndNestedChildren<T>(this UnityEngine.GameObject gameObject)
        {
            List<T> components = gameObject.GetComponents<T>().ToList();

            components.AddRange(GetNestedChildren<T>(gameObject));

            return components;
        }

        public static IEnumerable<TGetType> GetThisAndNestedChildren<TFromType, TGetType>(this TFromType component)
            where TFromType : Component
        {
            return component.gameObject.GetThisAndNestedChildren<TGetType>();
        }

        public static IEnumerable<T> GetNestedChildren<T>(this UnityEngine.GameObject gameObject)
        {
            List<T> children = new List<T>();

            foreach (Transform t in gameObject.transform)
            {
                var components = t.GetComponents<T>();
                var childrenComponents = GetNestedChildren<T>(t.gameObject);

                children.AddRange(components);
                children.AddRange(childrenComponents);
            }

            return children;
        }

        public static IEnumerable<TGetType> GetNestedChildren<TFromType, TGetType>(this TFromType component)
            where TFromType : Component
        {
            return component.gameObject.GetNestedChildren<TGetType>();
        }
    }
}
