using Common.Basic.Counters;
using Common.Unity.Events;
using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Unity.Prefabs
{
    public class SpamInteractor : MonoBehaviour
    {
        [SerializeField] private float _blowTimeResetMilliseconds;
        [SerializeField] private int _blowSpamInteractCount;

        [SerializeField] private GetBool _isCloseEnough;
        [SerializeField] private GetBool _isInteractInput;
        [SerializeField] private UnityEvent _onCountReached;
        [SerializeField] private UnityEvent _onInteract;

        private SpamInteractorImpl _interactorImpl;

        private void Start() =>
            _interactorImpl = new SpamInteractorImpl(
                _blowTimeResetMilliseconds, _blowSpamInteractCount, 
                _isCloseEnough.Invoke, _isInteractInput.Invoke, 
                _onCountReached.Invoke, _onInteract.Invoke);

        private void Update() => _interactorImpl.Interact();
    }

    public class InteractorImplD
    {
        private readonly Func<bool> _isCloseEnough;
        private readonly Func<bool> _isInteractInput;
        private readonly Action _onInteract;

        public InteractorImplD(
            Func<bool> isCloseEnough,
            Func<bool> isInteractInput,
            Action onInteract)
        {
            _isCloseEnough = isCloseEnough;
            _isInteractInput = isInteractInput;
            _onInteract = onInteract;
        }

        public bool Interact()
        {
            if (!_isCloseEnough() || !_isInteractInput())
                return false;

            _onInteract();

            return true;
        }
    }

    public class SpamInteractorImpl
    {
        private readonly TimedCounter _interactAndTimeCounter;
        private InteractorImplD _interactorImplD;

        public SpamInteractorImpl(
            float interactSpamTimeResetMS, 
            int spamInteractCount, 
            Func<bool> isCloseEnough, 
            Func<bool> isInteractInput, 
            Action onCountReached,
            Action onInteract)
        {
            _interactorImplD = new InteractorImplD(isCloseEnough, isInteractInput, onInteract);
            _interactAndTimeCounter = new TimedCounter(spamInteractCount, interactSpamTimeResetMS, onCountReached, TimerFunctions.FromStopwatch());
        }

        public bool Interact()
        {
            if (!_interactorImplD.Interact())
                return false;

            _interactAndTimeCounter.Increase();

            return true;
        }
    }
}
