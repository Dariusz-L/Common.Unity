using Common.Unity.Animating;
using UnityEngine;
using static MLU.Commands.SerializableCallbacks;

namespace MLU.Commands
{
    public class SetPosPlayAnimRbType : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGOWithRb2DAndAnimator;
        [SerializeField] private Vector2 _targetPosition;
        [SerializeField] private RigidbodyType2D _rigidbodyType;
        [SerializeField] private bool _abandonRequestedAnimation;
        [SerializeField] private string _animationName;

        public void Execute()
        {
            var go = _getGOWithRb2DAndAnimator.Invoke();

            var rb = go.GetComponent<Rigidbody2D>();
            rb.bodyType = _rigidbodyType;
            rb.position = _targetPosition;

            var animator = go.GetComponent<Platform2DCharacterAnimator>();
            if (_abandonRequestedAnimation)
                animator.AbandonRequestedAnimation();
            else
                animator.RequestAnimation(_animationName);
        }
    }
}
