using System;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Unity.Scripts.Common
{
    public class KeyHandler : MonoBehaviour
    {
        [SerializeField] private KeyCode _key;
        [SerializeField] private UnityEvent _onKeyUp;
        [SerializeField] private UnityEvent _onKeyDown;

        private void Update()
        {
            if (!CustomInput.IsActive)
                return;

            if (Input.GetKeyUp(_key))
                _onKeyUp?.Invoke();

            if (Input.GetKeyDown(_key))
                _onKeyDown?.Invoke();
        }

        public void OnKeyUp(Action action)
        {
            _onKeyUp = _onKeyUp ?? new UnityEvent();
            _onKeyUp.AddListener(action.Invoke);
        }

        public void SetKey(KeyCode key)
        {
            _key = key;
        }
    }
}
