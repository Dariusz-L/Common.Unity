using UnityEngine;

namespace Assets.Scripts.Common.Unity.Scripts
{
    public class Rigidbody2DMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _velocityFactor = 1.0f;

        private float _currentMove;

        private void Start()
        {
            if (!_rigidbody)
                Debug.Log("Missing serialized field!");
        }

        public void Move(float move)
        {
            _currentMove = move;
        }

        private void FixedUpdate()
        {
            if (_currentMove == 0)
                return;

            float moveFactored = _currentMove * _velocityFactor;
            float moveWithDeltaTime = moveFactored * Time.fixedDeltaTime;

            var pos = _rigidbody.position;
            pos.x += moveWithDeltaTime;

            _rigidbody.MovePosition(pos);
        }
    }
}
