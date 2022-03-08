using Common.Unity.Components;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Unity.UI
{
    public class SetVisibleOnUIEnterExit : MonoBehaviour, 
        IPointerEnterHandler,
        IPointerExitHandler
    {
        [SerializeField] private List<GameObject> _go;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _go.NestedGraphicsToClear();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _go.NestedGraphicsToTransparent();
        }
    }
}
