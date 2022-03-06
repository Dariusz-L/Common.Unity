using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class SpawnPrefab : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private bool _enabled = true;

        private GameObject _spawned;

        public void Spawn() => Get();

        public GameObject Get()
        {
            if (!_spawned)
                _spawned = Instantiate(_prefab);
            
            _spawned.SetActive(_enabled);

            return _spawned;
        }
    }
}
