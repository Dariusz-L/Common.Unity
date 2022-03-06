using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class SpawnIfNotAlready : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private GameObject _object;

        public void Execute()
        {
            var objs = GameObject.FindGameObjectsWithTag(_object.tag);
            if (objs.Length < 1)
                Instantiate(_object, _parent);
        }
    }
}
