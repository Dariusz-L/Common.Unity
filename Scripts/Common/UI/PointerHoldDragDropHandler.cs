using Common.Unity.Events;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.UI
{
    public class PointerHoldDragDropHandler : MonoBehaviour
    {
        [SerializeField] private PointerHoldHandler _pointerHoldHandler;
        [SerializeField] private PointerDragDropHandler _pointerDragDropHandler;

        [SerializeField] private OnPointerEventData _onHold;
        [SerializeField] private OnPointerEventData _onDragAfterHoldHandler;
        [SerializeField] private OnPointerEventData _onDrop;

        private bool _isHolding;

        private void Start()
        {
            _pointerHoldHandler.SetOnHold(OnHold);
            _pointerHoldHandler.SetOnUpAfterHold(OnUpAfterHold);
            _pointerDragDropHandler.SetOnDrag(OnDrag);
        }

        private void OnHold(PointerEventData data)
        {
            _isHolding = true;
            _onHold?.Invoke(data);
        }

        private void OnUpAfterHold(PointerEventData data)
        {
            _isHolding = false;
            _onDrop?.Invoke(data);
        }

        private void OnDrag(PointerEventData data)
        {
            if (_isHolding)
                _onDragAfterHoldHandler?.Invoke(data);
        }

        public void SetOnHold(Action<PointerEventData> handler) => _onHold.RemoveAllListenersAndAdd(handler);
        public void SetOnDragAfterHold(Action<PointerEventData> handler) => _onDragAfterHoldHandler.RemoveAllListenersAndAdd(handler);
        public void SetOnDrop(Action<PointerEventData> handler) => _onDrop.RemoveAllListenersAndAdd(handler);
    }
}
