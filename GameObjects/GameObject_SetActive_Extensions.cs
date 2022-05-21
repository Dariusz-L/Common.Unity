using Common.Basic.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Unity.GameObjects
{
    public static class Component_SetActive_Extensions
    {
        public static IEnumerable<Component> SetActive(this IEnumerable<Component> components, bool value)
        {
            components.ForEach(c => c.SetActive(value));
            return components;
        }

        public static Component SetActive(this Component component, bool value)
        {
            component.gameObject.SetActive(value);
            return component;
        }

        public static bool IsActiveSelf(this Component component) => component.gameObject.activeSelf;

        public static Component SetThisAndParentActive(this Component component, bool value)
        {
            component.gameObject.SetActive(value);
            component.transform.parent.gameObject.SetActive(value);
            return component;
        }

        public static Component SetParentActive(this Component component, bool value)
        {
            component.transform.parent.gameObject.SetActive(value);
            return component;
        }
    }
}
