using Common.Unity.Events;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class SpawnPrefabInParentTransform : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getParentGO;
        [SerializeField] private Transform _parent;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private bool _enabled = true;

        private GameObject _spawned;

        public void Spawn() => Get();

        public GameObject Get()
        {
            if (_spawned)
                return _spawned;

            if (!_parent)
                _parent = _getParentGO?.Invoke()?.transform;

            if (!_parent)
                _spawned = Instantiate(_prefab);
            else
                _spawned = Instantiate(_prefab, _parent);

            _spawned.SetActive(_enabled);

            return _spawned;
        }
    }
}
