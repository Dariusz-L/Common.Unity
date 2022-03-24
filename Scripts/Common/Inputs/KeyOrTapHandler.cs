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
            if (!Inputs.IsActive)
                return;

            if (Input.GetKeyUp(_key))
                _onUp?.Invoke();

            if (Input.GetMouseButtonUp(0) && Input.touchSupported)
                _onUp?.Invoke();

            if (Input.GetKeyDown(_key))
                _onDown?.Invoke();

            if (Input.GetMouseButtonDown(0) && Input.touchSupported)
                _onDown?.Invoke();
        }
    }
}
