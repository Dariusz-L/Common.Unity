using Common.Unity.Inspector;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class DynamicRigidbodyMovement : MonoBehaviour
    {
        [SerializeField] private float _velocityFactor;

        [ReadOnly] [SerializeField] private float _currentVelocity;
        public float CurrentVelocity() => _currentVelocity;

        [ReadOnly] [SerializeField] private float _currentInput;

        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void SetInput(float currentInput)
        {
            _currentInput = currentInput;
        }
        
        private void Update()
        {
            _currentVelocity = _currentInput * _velocityFactor * Time.deltaTime * 1000;
        }
        
        private void LateUpdate()
        {
            _rigidbody2D.AddForce(new Vector2(_currentVelocity, 0), ForceMode2D.Force);
        }
    }
}
