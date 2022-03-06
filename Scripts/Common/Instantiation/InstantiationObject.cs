using UnityEngine;
using static Common.Unity.Instantiation.UnityIOs;

namespace Common.Unity.Scripts.Common
{
    internal class InstantiationObject : MonoBehaviour
    {
        [SerializeField] private TransformIO _prefabData;

        public void Instantiate()
        {
            _prefabData.Instantiate();
        }

        public void Destroy()
        {
            _prefabData.Destroy();
        }

        public TransformIO PrefabData => _prefabData;
    }
}
