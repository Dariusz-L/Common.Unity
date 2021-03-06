using Common.Unity.Components;
using Common.Unity.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Common.Basic.Maths.LerpingFunctions;

namespace Common.Unity.Scripts.Common
{
    public class LerpVisibleAndChildren : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getVisibleGO;
        [SerializeField] private GameObject _visibleGO;
        [SerializeField] private Color _targetColor;
        [SerializeField] private float _durationSeconds;
        [SerializeField] private LerpFunctionType _lerpFunctionType = LerpFunctionType.Linear;
        [SerializeField] private List<UnityEvent> _onDone;

        public void Execute()
        {
            if (!_visibleGO)
                _visibleGO = _getVisibleGO?.Invoke();

            LerpFunctions.LerpVisibleAndChildrenM(
                _visibleGO, _targetColor, _durationSeconds, _lerpFunctionType, StartCoroutine, _onDone.ToInvokeAction());
        }
    }
}
