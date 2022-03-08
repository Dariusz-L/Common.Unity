using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.UI
{
    public class SetActiveOnUIEnterExit : MonoBehaviour, 
        IPointerEnterHandler,
        IPointerExitHandler
    {
        [SerializeField] private GameObject _go;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _go.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _go.SetActive(false);
        }
    }
}
