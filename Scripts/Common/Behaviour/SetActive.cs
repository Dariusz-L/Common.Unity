using Common.Unity.Events;
using UnityEngine;

namespace MLU.Commands
{
    public class SetActive : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGameObject;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private bool _active = true;

        public void Execute()
        {
            if (!_gameObject)
                _gameObject = _getGameObject?.Invoke();

            _gameObject.SetActive(_active);
        }
    }
}
