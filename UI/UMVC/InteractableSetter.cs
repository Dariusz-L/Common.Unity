using Common.Basic.UMVC.Elements;
using Common.Unity.GameObjects;
using Common.Unity.Scripts.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Unity.UI.MVC
{
    public static class InteractableSetter
    {
        public static Action<IView, bool> SetParentNestedItemsExceptThisInteractableInKeyOrTapHandler_Action<TParent, TChild>()
            where TParent : IView
            where TChild : IView => 
            (view, value) => SetParentNestedItemsExceptThisInteractableInKeyOrTapHandler<TParent, TChild>(view, value);

        public static Action<IView, bool> SetParentNestedItemsExceptThisInteractable_Action<TParent, TChild>()
           where TParent : IView
           where TChild : IView =>
           (view, value) => SetParentNestedItemsExceptThisInteractable<TParent, TChild>(view, value);

        public static void SetParentNestedItemsExceptThisInteractableInKeyOrTapHandler<TParent, TChild>(this IView item, bool value)
            where TParent : IView
            where TChild : IView
        {
            var parent = item.GetParent<TParent>();
            parent.Add<KeyOrTapHandler>().SetKeyUp(() =>
            {
                parent.GetChildren<TChild>().FirstOrDefault().SetParentNestedItemsInteractable<TParent, TChild>(value);
                UnityThreadActionRunner.Run(() =>
                    parent.Remove<KeyOrTapHandler>());
            });
        }

        public static void SetParentNestedItemsExceptThisInteractable<TParent, TChild>(this IView item, bool value)
            where TParent : IView
            where TChild : IView
        {
            if (item == null)
                return;

            var items = item.GetNestedItemsOfParent<TParent, TChild>().ToList();
            items.SetNestedInteractableExcept(item, value);
        }

        private static void SetParentNestedItemsInteractable<TParent, TChild>(this TChild item, bool value)
            where TParent : IView
            where TChild : IView
        {
            if (item == null)
                return;

            var items = item.GetNestedItemsOfParent<TParent, TChild>().ToList();
            items.SetNestedInteractable(value);
        }

        private static IEnumerable<TChild> GetNestedItemsOfParent<TParent, TChild>(this IView item)
            where TParent : IView
            where TChild : IView
        {
            var parent = item.GetParent<TParent>();
            var items = parent.GetChildren<TChild>();
            return items.SelectMany(i => i.GetNestedItems()).Concat(items).ToList();
        }

        private static IEnumerable<TChild> GetNestedItems<TChild>(this TChild item)
            where TChild : IView
        {
            var items = item.GetChildren<TChild>().ToList();
            foreach (var child in items)
            {
                items.Add(child);
                items.AddRange(child.GetNestedItems());
            }

            return items;
        }
    }
}
