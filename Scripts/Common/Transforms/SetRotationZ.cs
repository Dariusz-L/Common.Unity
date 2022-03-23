using Common.Unity.Components;
using Common.Unity.Events;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class SetRotationZ : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getTargetGO;
        [SerializeField] private Transform _target;
        [SerializeField] private float _value;
        
        public void Execute()
        {
            if (!_target)
                _target = _getTargetGO?.Invoke().transform;

            _target.SetRotationZ(_value);
        }
    }
}
