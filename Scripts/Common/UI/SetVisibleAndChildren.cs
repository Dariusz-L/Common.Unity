using Common.Basic.Collections;
using Common.Basic.Unity.GameObjects;
using Common.Unity.Components;
using System;
using UnityEngine;
using UnityEngine.UI;
using static MLU.Commands.SerializableCallbacks;

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
