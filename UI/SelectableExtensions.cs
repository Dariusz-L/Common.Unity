using Common.Basic.Collections;
using Common.Unity.GameObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace Common.Unity.UI
{
    public static class SelectableExtensions
    {
        public static void SetInteractable(this IEnumerable<object> objectsWithSelectables, bool value)
        {
            var items = objectsWithSelectables.GetThisAndNestedChildren<Selectable>().ToList();
            items.SetInteractable(value);
        }

        public static void SetInteractable(this IEnumerable<Selectable> selectables, bool value)
        {
            selectables.ForEach(s => s.interactable = value);
        }
    }
}
