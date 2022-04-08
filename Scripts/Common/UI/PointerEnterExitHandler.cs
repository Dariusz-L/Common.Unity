using Common.Unity.Events;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.UI
{
    public class PointerEnterExitHandler : MonoBehaviour, 
        IPointerEnterHandler,
        IPointerExitHandler
    {
        [SerializeField] private OnPointerEventData _onPointerEnterHandler;
        [SerializeField] private OnPointerEventData _onPointerExitHandler;

        private bool _isInside;

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (_isInside)
                return;

            _onPointerEnterHandler.Invoke(eventData);
            _isInside = true;
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (!_isInside)
                return;

            _onPointerExitHandler.Invoke(eventData);
            _isInside = false;
        }


        public void SetOnPointerEnter(Action<PointerEventData> handler)
        {
            _onPointerEnterHandler.RemoveAllListeners();
            AddOnPointerEnter(handler.Invoke);
        }


        public void SetOnPointerExit(Action<PointerEventData> handler)
        {
            _onPointerExitHandler.RemoveAllListeners();
            AddOnPointerExit(handler.Invoke);
        }

        public void AddOnPointerEnter(Action<PointerEventData> handler) => _onPointerEnterHandler.AddListener(handler.Invoke);
        public void AddOnPointerExit(Action<PointerEventData> handler) => _onPointerExitHandler.AddListener(handler.Invoke);
    }
}
