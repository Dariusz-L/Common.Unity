using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class TransformMover : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _velocityFactor = 1.0f;

        private float _currentMove;

        private void Start()
        {
            if (!_target)
                Debug.Log("Missing serialized field!");
        }

        public void Move(float move)
        {
            _currentMove = move;
        }

        private void LateUpdate()
        {
            if (_currentMove == 0)
                return;

            float moveFactored = _currentMove * _velocityFactor;
            float moveWithDeltaTime = moveFactored * Time.deltaTime;

            var pos = _target.position;
            pos.x += moveWithDeltaTime;

            _target.transform.position = pos;
        }
    }
}
