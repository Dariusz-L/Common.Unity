using Common.Unity.Components;
using Common.Unity.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Common.Basic.Math.LerpingFunctions;
using static UnityEngine.UI.ContentSizeFitter;

namespace Common.Unity.Scripts.Common
{
    public class LerpRTHeight : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getImageGO;
        [SerializeField] private GameObject _go;
        [SerializeField] private float _targetValue;
        [SerializeField] private float _durationSeconds;
        [SerializeField] private List<UnityEvent> _onDone;
        [SerializeField] private LerpFunctionType _lerpFunctionType = LerpFunctionType.Linear;

        public void Execute()
        {
            if (!_go)
                _go = _getImageGO?.Invoke();

            var csf = _go.SetFitModeIfExist(FitMode.Unconstrained, out var previous);

            LerpFunctions.LerpRTHeight(
                _go.GetComponent<RectTransform>(), _targetValue, _durationSeconds, _lerpFunctionType,
                StartCoroutine, onDone: () =>
                {
                    _onDone.ToAction()();
                    _go.SetFitModeIfExist(previous);
                });
        }
    }

    public static class ss
    {
        public static bool SetFitModeIfExist(this GameObject go, FitMode newValue)
        {
            return go.SetFitModeIfExist(newValue, out var previous);
        }

        public static bool SetFitModeIfExist(this GameObject go, FitMode newValue, out FitMode previous)
        {
            previous = FitMode.Unconstrained;

            var component = go.GetComponent<ContentSizeFitter>();
            if (!component)
                return false;

            previous = component.verticalFit;
            component.verticalFit = newValue;

            return true;
        }
    }
}
