using Common.Unity.Components;
using UnityEngine;
using static MLU.Commands.SerializableCallbacks;

namespace MLU.Commands
{
    public class SetPosition2D : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getTargetGO;
        [SerializeField] private Transform _target;
        [SerializeField] private Vector2 _position;
        
        public void Execute()
        {
            if (!_target)
                _target = _getTargetGO?.Invoke().transform;
            
            _target.SetPosition(_position);
        }
    }
}
