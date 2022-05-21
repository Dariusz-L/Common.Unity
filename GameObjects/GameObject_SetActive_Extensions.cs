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
    }
}
