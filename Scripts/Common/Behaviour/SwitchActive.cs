using Common.Unity.Events;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class SwitchActive : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGameObject;
        [SerializeField] private GameObject _gameObject;

        public void Execute()
        {
            if (!_gameObject)
                _gameObject = _getGameObject?.Invoke();

            _gameObject.SetActive(!_gameObject.activeSelf);
        }
    }
}
