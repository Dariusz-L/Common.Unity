using Common.Unity.Events;
using System;
using System.Timers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.UI
{
    public class PointerHoldHandler : MonoBehaviour, 
        IPointerDownHandler,
        IPointerUpHandler
    {
        [SerializeField] private float _holdTimeSeconds = 0.5f;
        [SerializeField] private OnPointerEventData _onHoldHandler;
        [SerializeField] private OnPointerEventData _onUpAfterHoldHandler;

        private Timer _timer = new Timer();
        private PointerEventData _eventData;
        private bool _timerElapsed;

        private void Start()
        {
            _timer.Elapsed += (sender, args) => _timerElapsed = true;
            _timer.AutoReset = true;
            _timer.Interval = _holdTimeSeconds * 1000;
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            _eventData = eventData;
            _timer.Start();
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            if (!_timer.Enabled)
                _onUpAfterHoldHandler?.Invoke(eventData);

            _timer.Stop();
        }

        private void Update()
        {
            if (!_timerElapsed)
                return;

            _timer.Stop();
            _onHoldHandler?.Invoke(_eventData);
            _timerElapsed = false;
        }

        public void SetOnHold(Action<PointerEventData> handler) => _onHoldHandler.RemoveAllListenersAndAdd(handler);
        public void SetOnUpAfterHold(Action<PointerEventData> handler) => _onUpAfterHoldHandler.RemoveAllListenersAndAdd(handler);

        public void AddOnHold(Action<PointerEventData> handler) => _onHoldHandler.AddListener(handler.Invoke);
        public void AddOnUpAfterHold(Action<PointerEventData> handler) => _onUpAfterHoldHandler.AddListener(handler.Invoke);
    }
}
