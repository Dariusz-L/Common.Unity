using Common.Unity.Inspector;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class GetTransformPosition : MonoBehaviour
    {
        [SerializeField] private GameObject _go;
        [ReadOnly] [SerializeField] private Vector3 _position;

        public Vector3 Get()
        {
            _position = _go.transform.position;
            return _position;
        }

        public void UpdateValue() => Get();
    }
}
