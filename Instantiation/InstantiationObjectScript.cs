using UnityEngine;
using static Common.Basic.Unity.Behaviour.UnityIOs;

namespace Common.Basic.Unity.Behaviour
{
    public class InstantiationObjectScript : MonoBehaviour, IInstantiationObject<Transform>
    {
        [SerializeField] private TransformIO _data;

        public Transform Object => _data.Object;

        public Transform Parent => _data.Parent;

        public Transform Prefab => _data.Prefab;

        public Transform Instantiate()
        {
            return _data.Instantiate();
        }

        public void Destroy()
        {
            _data.Destroy();
        }
    }
}
