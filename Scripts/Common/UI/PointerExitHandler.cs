using Common.Unity.Events;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.UI
{
    public class PointerExitHandler : MonoBehaviour, IPointerExitHandler
    {
        [SerializeField] private OnPointerEventData _handler;

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
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
