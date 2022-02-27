using UnityEngine;

namespace Common.Unity.Camera
{
    public class SmoothCamera2DFollow : MonoBehaviour
    {
        [Header("Camera Follow")]
        [SerializeField] private GameObject _target;
        [SerializeField] private int _xOffset = 0;
        [SerializeField] private int _yOffset = 0;
        [SerializeField] private float _dampTime = .4f;

        [Header("Camera Limits/Bounds")]
        [SerializeField] private bool _enableBounds;
        [SerializeField] private int _minY, _maxY, _minX, _maxX;

        private Vector2 _position;
        
        private void Update()
        {
            if (!_target)
                return;

            LerpCameraPositionToTarget();
            PositionCameraInBounds();
        }

        private void LateUpdate()
        {
            transform.position = new Vector3(_position.x, _position.y, -10f);
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        private void LerpCameraPositionToTarget()
        {
            float deltaTime = Time.deltaTime;

            _position.x = Lerp(_position.x, _target.transform.position.x, _xOffset, _dampTime, deltaTime);
            _position.y = Lerp(_position.y, _target.transform.position.y, _yOffset, _dampTime, deltaTime);
        }

        private void PositionCameraInBounds()
        {
            if (!_enableBounds)
                return;

            _position.x = Mathf.Clamp(_position.x, _minX, _maxX);
            _position.y = Mathf.Clamp(_position.y, _minY, _maxY);
        }

        public static float Lerp(float current, float target, float targetOffset, float dampTime, float deltaTime)
        {
            float targetOffseted = target + targetOffset;
            if (current == targetOffseted)
                return current;

            return Mathf.Lerp(current, targetOffseted, 1 / dampTime * deltaTime);
        }
    }
}