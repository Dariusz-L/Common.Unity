using Common.Unity.Animating;
using UnityEngine;
using static MLU.Commands.SerializableCallbacks;

namespace MLU.Commands
{
    public class SetPosPlayAnimRbKinematic : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGOWithRb2DAndAnimator;
        [SerializeField] private Vector2 _targetPosition;
        [SerializeField] private string _animationName;

        public void Execute()
        {
            var go = _getGOWithRb2DAndAnimator.Invoke();

            var animator = go.GetComponent<MLUAnimator>();
            var rb = go.GetComponent<Rigidbody2D>();

            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.position = _targetPosition;
            animator.RequestAnimation(_animationName);
        }
    }
}
