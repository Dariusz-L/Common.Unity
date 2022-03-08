using Common.Unity.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.UI
{
    public class PointerExitHandler : MonoBehaviour, IPointerExitHandler
    {
        [SerializeField] private OnPointerEventData _handler;

        public void OnPointerExit(PointerEventData eventData)
        {
            _handler.Invoke(eventData);
        }
    }
}
