using Common.Domain.Collections;
using Common.Domain.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common.Infrastructure.Unity.GameObjects
{
    public static class GameObjectExtensions
    {
        public static void Destroy<T>(this T component)
            where T : Component
        {
            if (component != null && component.gameObject != null)
                GameObject.Destroy(component.gameObject);
        }

        public static void Destroy<T>(this IEnumerable<T> components)
            where T : Component
        {
            components.ToList().ForEach(c => c.Destroy());
        }

        public static void Destroy(this UnityEngine.GameObject gameObject)
        {
            gameObject.SetActive(false);
            GameObject.Destroy(gameObject);
        }

        public static T GetOrAddComponent<T>(this GameObject go)
            where T : Component
        {
            var component = go.GetComponent<T>();
            if (component)
                return component;

            return go.AddComponent<T>();
        }

        public static T GetOrAddComponent<T>(this Component component)
            where T : Component
        {
            return component.gameObject.GetOrAddComponent<T>();
        }

        public static void ForEachNested<T>(this GameObject gameObject, Action<T> action)
        {
            var nestedGraphics =
                gameObject.GetThisAndNestedChildren<T>();

            nestedGraphics.ForEach(g => action(g));
        }

        public static IEnumerable<Transform> Instantiate(this IEnumerable<Transform> prefabs, Transform parent)
        {
            var instantiatedList = new List<Transform>();
            foreach (var p in prefabs)
            {
                Transform instantiated;
                if (parent == null)
                    instantiated = UnityEngine.GameObject.Instantiate(p);
                else
                    instantiated = UnityEngine.GameObject.Instantiate(p, parent);

                instantiatedList.Add(instantiated);
            }

            return instantiatedList;
        }

        public static void Destroy(this IEnumerable<Transform> instantiated)
        {
            if (instantiated == null)
                return;

            instantiated.ToList().ForEach(c => UnityEngine.GameObject.Destroy(c.gameObject));
        }

        public static IEnumerable<T> GetThisAndNestedChildren<T>(this UnityEngine.GameObject gameObject)
        {
            List<T> components = gameObject.GetComponents<T>().ToList();
            
            components.AddRange(GetNestedChildren<T>(gameObject));
            
            return components;
        }

        public static IEnumerable<T> GetThisAndNestedChildren<T>(this UnityEngine.Transform transform)
        {
            return transform.gameObject.GetThisAndNestedChildren<T>();
        }

        public static IEnumerable<T> GetThisAndNestedChildren<T>(this object @object)
        {
            if (@object is Component component)
                return component.transform.GetThisAndNestedChildren<T>();
            else if (@object is GameObject gameObject)
                return gameObject.GetThisAndNestedChildren<T>();

            return Array.Empty<T>();
        }

        public static T Get<T>(this object @object)
        {
            return @object.GetThisAndNestedChildren<T>().FirstOrDefault();
        }

        public static T GetOrAdd<T>(this object @object)
        {
            T c = @object.Get<T>();
            if (c == null)
                c = c.Add<T>();

            return c;
        }

        public static T Add<T>(this object @object)
        {
            if (@object is Component component)
                return component.Add<T>();

            return default;
        }

        public static TScript GetIf<TScript>(this object @object, Func<TScript, bool> condition)
        {
            var objects = @object.GetThisAndNestedChildren<TScript>();
            foreach (var obj in objects)
            {
                if (condition(obj))
                    return obj;
            }

            return default;
        }

        public static TScript GetFromParentIf<TScript>(this object @object, Func<TScript, bool> condition)
        {
            var objects = @object.GetComponentsInParent<TScript>();
            foreach (var obj in objects)
            {
                if (condition(obj))
                    return obj;
            }

            return default;
        }

        public static T GetComponent<T>(this object @object)
        {
            if (@object is Component component)
                return component.GetComponent<T>();

            return default;
        }

        public static T GetComponentInParent<T>(this object @object)
        {
            if (@object is Component component)
                return component.GetComponentInParent<T>();

            return default;
        }

        public static IEnumerable<T> GetComponentsInParent<T>(this object @object)
        {
            if (@object is Component component)
                return component.GetComponentsInParent<T>();

            return Array.Empty<T>();
        }

        public static T GetFromThisOrNestedChildren<T>(this object @object)
        {
            return @object.GetThisAndNestedChildren<T>().FirstOrDefault();
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

        public static IEnumerable<T> GetNestedChildren<T>(this UnityEngine.Transform transform)
        {
            return transform.gameObject.GetNestedChildren<T>();
        }
    }
}
