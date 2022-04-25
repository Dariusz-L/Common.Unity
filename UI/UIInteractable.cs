using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.UI
{
    public static class UIInteractable
    {
        private static readonly string Name = "Interactable";

        public static void Set(bool value)
        {
            if (value)
                SetInteractableTrue();
            else
                SetInteractableFalse();
        }

        private static void SetInteractableTrue()
        {
            var go = GameObject.Find(Name);
            if (go)
                GameObject.Destroy(go);
        }

        private static void SetInteractableFalse()
        {
            var canvas = GameObject.FindObjectOfType<Canvas>();

            var imageGO = new GameObject(Name);
            imageGO.transform.parent = canvas.transform;

            var image = imageGO.AddComponent<Image>();
            image.StretchToExtents();
            image.color = Color.clear;
        }
    }
}
