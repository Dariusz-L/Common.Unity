using Common.Unity.Components;
using Common.Unity.Events;
using UnityEngine;

namespace MLU.Commands
{
    public class SetVisibleAndChildren : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getVisibleGO;
        [SerializeField] private GameObject _visibleGO;

        public void Execute(bool visible)
        {
            if (!_visibleGO)
                _visibleGO = _getVisibleGO?.Invoke();

            if (visible)
                _visibleGO.NestedGraphicsToClear();
            else
                _visibleGO.NestedGraphicsToTransparent();
        }
    }
}
