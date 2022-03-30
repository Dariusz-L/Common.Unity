using Common.Basic.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.Scripts.Common
{
    public static class CustomInput
    {
        private static bool _enabled = true;

        public static void SetActive(bool value) => IsActive = value;

        public static bool IsActive 
        {
            get => _enabled;

            set
            {
                var selectables =  GameObject.FindObjectsOfType<Selectable>();
                selectables.ForEach(s => s.interactable = value);

                _enabled = value;
            }
        }
    }
}
