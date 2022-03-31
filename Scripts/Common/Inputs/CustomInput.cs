using Common.Unity.UI;
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
                GameObject
                    .FindObjectsOfType<Selectable>()
                    .SetInteractable(value);

                _enabled = value;
            }
        }
    }
}
