using Common.Unity.Events;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.UI
{
    public class PointerEnterExitByRectHandler : MonoBehaviour
    {
        [SerializeField] private OnPointerEventData _onPointerEnterHandler;
        [SerializeField] private OnPointerEventData _onPointerExitHandler;

        private bool _wasInsidePreviously;
        private RectTransform _rt;

        private void Start()
        {
            _rt = GetComponent<RectTransform>();
        }

        private void Update()
        {
            var mousePos = Input.mousePosition;
            var screenRect = _rt.GetScreenRect();
            
            var isMouseInsideRect = screenRect.Contains(mousePos);
            if (isMouseInsideRect && !_wasInsidePreviously)
            {
                _wasInsidePreviously = true;
                _onPointerEnterHandler.Invoke(null);
            }
            else
            if (!isMouseInsideRect && _wasInsidePreviously)
            {
                _wasInsidePreviously = false;
                _onPointerExitHandler.Invoke(null);
            }
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
