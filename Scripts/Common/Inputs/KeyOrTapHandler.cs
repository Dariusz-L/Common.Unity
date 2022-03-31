using System;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Unity.Scripts.Common
{
    public class KeyOrTapHandler : MonoBehaviour
    {
        [SerializeField] private KeyCode _key;

        [SerializeField] private UnityEvent _onUp;
        [SerializeField] private UnityEvent _onDown;

        [SerializeField] private bool _simulateMouseWithTouches;

        private void Start()
        {
            Input.simulateMouseWithTouches = _simulateMouseWithTouches;
        }

        private void Update()
        {
            if (!CustomInput.IsActive)
                return;

            if (Input.GetKeyUp(_key))
                _onUp?.Invoke();

            if (Input.GetMouseButtonUp(0))
                _onUp?.Invoke();

            if (Input.GetKeyDown(_key))
                _onDown?.Invoke();

            if (Input.GetMouseButtonDown(0))
                _onDown?.Invoke();
        }

        public void SetKeyUp(Action action)
        {
            _onUp = _onUp ?? new UnityEvent();

            if (_onUp.GetPersistentEventCount() > 0)
                _onUp.RemoveAllListeners();

            _onUp.AddListener(action.Invoke);
        }

        public void SetKey(KeyCode key)
        {
            _key = key;
        }
    }
}
