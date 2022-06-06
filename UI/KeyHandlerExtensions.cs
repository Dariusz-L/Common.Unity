using Common.Unity.Components;
using Common.Unity.Scripts.Common;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.UI
{
    public static class KeyHandlerExtensions
    {
        public static void AddSubmitAndDiscardHandler(this Component component, Action onSubmit, Action onDiscard)
        {
            int siblingIndex = component.transform.GetSiblingIndex();

            var originalParent = component.transform.parent;
            var newParent = RectTransformFactory.CreateRT(component, "Submit-Discard Handler Parent");
            newParent.SetParent(originalParent, worldPositionStays: true);
            newParent.SetRectTo(component);
            newParent.SetSiblingIndex(siblingIndex);
            component.SetParent(newParent, worldPositionStays: true);
            component.StretchToExtents();

            var globalCanvas = newParent.GetComponentInParent<Canvas>();

            var canvas = newParent.CreateCanvas();
            canvas.overrideSorting = true;
            canvas.sortingOrder = 100;

            Canvas.ForceUpdateCanvases();

            var outsideButton = ButtonsFactory.Create(globalCanvas.transform, "Submit-Discard Outside Button");
            outsideButton.StretchToExtents();
            outsideButton.SetParent(canvas, worldPositionStays: true);

            component.SetParent(canvas, worldPositionStays: true);

            outsideButton.RemoveAllAndAddListener(OnDiscard);
            AddKeyUpHandler(component, KeyCode.Return, OnSubmit);
            AddKeyUpHandler(component, KeyCode.Escape, OnDiscard);

            void OnSubmit()
            {
                SetOriginalParentAndDestroy();
                onSubmit();
            }

            void OnDiscard()
            {
                SetOriginalParentAndDestroy();
                onDiscard();
            }

            void SetOriginalParentAndDestroy()
            {
                component.SetParent(originalParent);
                newParent.parent = null;
                GameObject.Destroy(newParent.gameObject);
            }
        }

        public static void AddKeyUpHandler(this Component component, KeyCode key, Action onUp)
        {
            var backNavHandler = component.gameObject.AddComponent<KeyHandler>();
            backNavHandler.SetKey(key);
            backNavHandler.OnKeyUp(onUp);
        }
    }
}
