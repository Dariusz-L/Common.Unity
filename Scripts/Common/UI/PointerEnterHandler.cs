using Common.Unity.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.UI
{
    public class PointerEnterHandler : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] private OnPointerEventData _handler;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _handler.Invoke(eventData);
        }
    }
}
