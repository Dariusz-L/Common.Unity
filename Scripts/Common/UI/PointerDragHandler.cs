using Common.Unity.Events;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.UI
{
    public class PointerDragHandler : MonoBehaviour, IDragHandler
    {
        [SerializeField] private OnPointerEventData _onDragHandler;

        void IDragHandler.OnDrag(PointerEventData eventData) => _onDragHandler.Invoke(eventData);
        public void SetOnDrag(Action<PointerEventData> handler) => _onDragHandler.RemoveAllListenersAndAdd(handler);
        public void AddOnDrag(Action<PointerEventData> handler) => _onDragHandler.AddListener(handler.Invoke);
    }
}
