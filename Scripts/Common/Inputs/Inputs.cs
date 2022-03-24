using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.Scripts.Common
{
    public static class Inputs
    {
        private static bool _enabled = true;
        private static EventSystem _eventSystem;

        public static void SetActive(bool value) => IsActive = value;

        public static bool IsActive 
        {
            get => _enabled;

            set
            {
                _eventSystem = _eventSystem ?? GameObject.FindObjectOfType<EventSystem>();
                if (_eventSystem != null)
                    _eventSystem.gameObject.SetActive(value);

                _enabled = value;
            }
        }
    }
}
