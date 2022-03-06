using Common.Unity.Events;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class SetParent : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGO;
        [SerializeField] private GameObject _gameObject;

        [SerializeField] private GetGameObject _getParentToSet;
        [SerializeField] private GameObject _parentToSet;

        public void Execute()
        {
            if (!_gameObject)
                _gameObject = _getGO?.Invoke();

            if (!_parentToSet)
                _parentToSet = _getParentToSet?.Invoke();

            if (!_parentToSet)
                _gameObject.transform.parent = null;
            else
                _gameObject.transform.parent = _parentToSet.transform;
        }
    }
}
