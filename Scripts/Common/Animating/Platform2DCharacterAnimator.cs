using Common.Unity.Components;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class Platform2DCharacterAnimator : MonoBehaviour
    {
        [SerializeField] private List<Animator> _animators;
        [SerializeField] private GetVelocity _getVelocity;

        private string _animationRequested;

        public void RequestAnimation(string animationName)
        {
            _animators.Play(animationName);
            _animationRequested = animationName;
        }

        public void AbandonRequestedAnimation()
        {
            _animationRequested = null;
        }

        private void Update()
        {
            if (_animationRequested != null)
                return;

            float velocity = (float) _getVelocity?.Invoke();

            if (velocity == 0)
                _animators.Play("Idle");

            if (velocity != 0)
                _animators.Play("Run");
        }

        [Serializable] public class GetVelocity : SerializableCallback<float> { }
    }
}
