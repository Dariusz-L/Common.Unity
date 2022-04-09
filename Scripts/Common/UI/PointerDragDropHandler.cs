using Common.Unity.Events;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.UI
{
    [Serializable]
    public class PointerDragDropHandler : MonoBehaviour, 
        IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private OnPointerEventData _onBeginDragHandler;
        [SerializeField] private OnPointerEventData _onDragHandler;
        [SerializeField] private OnPointerEventData _onEndDragHandler;

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) => _onBeginDragHandler.Invoke(eventData);
        void IDragHandler.OnDrag(PointerEventData eventData) => _onDragHandler.Invoke(eventData);
        void IEndDragHandler.OnEndDrag(PointerEventData eventData) => _onEndDragHandler.Invoke(eventData);

        public void SetOnBeginDrag(Action<PointerEventData> handler) => _onBeginDragHandler.RemoveAllListenersAndAdd(handler);
        public void SetOnDrag(Action<PointerEventData> handler) => _onDragHandler.RemoveAllListenersAndAdd(handler);
        public void SetOnEndDrag(Action<PointerEventData> handler) => _onEndDragHandler.RemoveAllListenersAndAdd(handler);

        public void AddOnBeginDrag(Action<PointerEventData> handler) => _onBeginDragHandler.AddListener(handler.Invoke);
        public void AddOnDrag(Action<PointerEventData> handler) => _onDragHandler.AddListener(handler.Invoke);
        public void AddOnEndDrag(Action<PointerEventData> handler) => _onEndDragHandler.AddListener(handler.Invoke);
    }
}
