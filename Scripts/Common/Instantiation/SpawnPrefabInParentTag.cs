using Common.Unity.Inspector;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class SpawnPrefabInParentTag : MonoBehaviour
    {
        [TagSelector] [SerializeField] private string _parentTag;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private bool _enabled = true;

        private GameObject _parent;
        private GameObject _spawned;

        public void Spawn() => Get();

        public GameObject Get()
        {
            if (!_spawned)
            {
                _parent = GameObject.FindGameObjectWithTag(_parentTag);
                if (!_parent)
                    _spawned = Instantiate(_prefab);
                else
                    _spawned = Instantiate(_prefab, _parent.transform);
            }

            _spawned.SetActive(_enabled);

            return _spawned;
        }
    }
}
