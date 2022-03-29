using Common.Unity.Events;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.UI
{
    public class PointerEnterHandler : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] private OnPointerEventData _handler;

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            _handler.Invoke(eventData);
        }

        public void Add(Action<PointerEventData> handler)
        {
            _handler.AddListener(handler.Invoke);
        }

        public void Set(Action<PointerEventData> handler)
        {
            _handler.RemoveAllListeners();
            Add(handler.Invoke);
        }
    }
}
