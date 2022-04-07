using Common.Basic.Collections;
using Common.Unity.GameObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace Common.Unity.UI
{
    public static class SelectableExtensions
    {
        public static void SetNestedInteractableExcept(this IEnumerable<object> objectsWithNestedSelectables, object exceptNestedSelectable, bool value)
        {
            var exceptSelectables = exceptNestedSelectable.GetThisAndNestedChildren<Selectable>().ToList();
            objectsWithNestedSelectables.SetNestedInteractableExcept(exceptSelectables, value);
        }

        public static void SetNestedInteractableExcept(this IEnumerable<object> objectsWithNestedSelectables, IEnumerable<Selectable> exceptSelectables, bool value)
        {
            var items = objectsWithNestedSelectables.GetThisAndNestedChildren<Selectable>().ToList();
            var exceptItems = items.Except(exceptSelectables);
            exceptItems.SetInteractable(value);
        }

        public static void SetNestedInteractable(this IEnumerable<object> objectsWithNestedSelectables, bool value)
        {
            var items = objectsWithNestedSelectables.GetThisAndNestedChildren<Selectable>().ToList();
            items.SetInteractable(value);
        }

        public static void SetInteractable(this IEnumerable<Selectable> selectables, bool value)
        {
            selectables.ForEach(s => s.interactable = value);
        }
    }
}
