using Common.Unity.Events;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class GetRotationZ : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getTargetGO;
        [SerializeField] private Transform _target;
        
        public float Get()
        {
            if (!_target)
                _target = _getTargetGO?.Invoke().transform;

            return _target.rotation.eulerAngles.z;
        }
    }
}
