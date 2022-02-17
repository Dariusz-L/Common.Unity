using UnityEngine;
using UnityEngine.Events;

namespace Common.Unity.Inputs
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
            if (Input.GetKeyUp(_key))
                _onUp?.Invoke();

            if (Input.GetMouseButtonUp(0))
                _onUp?.Invoke();

            if (Input.GetKeyDown(_key))
                _onDown?.Invoke();

            if (Input.GetMouseButtonDown(0))
                _onDown?.Invoke();
        }
    }
}
