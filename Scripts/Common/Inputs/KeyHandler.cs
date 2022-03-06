using UnityEngine;
using UnityEngine.Events;

namespace Common.Unity.Inputs
{
    public class KeyHandler : MonoBehaviour
    {
        [SerializeField] private KeyCode _key;
        [SerializeField] private UnityEvent _onKeyUp;
        [SerializeField] private UnityEvent _onKeyDown;

        private void Update()
        {
            if (Input.GetKeyUp(_key))
                _onKeyUp?.Invoke();

            if (Input.GetKeyDown(_key))
                _onKeyDown?.Invoke();
        }
    }
}
