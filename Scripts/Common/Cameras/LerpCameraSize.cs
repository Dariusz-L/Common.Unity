using Common.Unity.Components;
using Common.Unity.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Common.Basic.Maths.LerpingFunctions;

namespace Common.Unity.Scripts.Common
{
    public class LerpCameraSize : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getTargetGO;
        [SerializeField] private Camera _target;
        [SerializeField] private float _targetValue;
        [SerializeField] private float _durationSeconds;
        [SerializeField] private LerpFunctionType _lerpFunctionType;
        [SerializeField] private List<UnityEvent> _onDone;

        public void Execute()
        {
            if (!_target)
                _target = _getTargetGO?.Invoke().GetComponent<Camera>();

            LerpFunctions.LerpCameraSize(
                _target, _targetValue, _durationSeconds, _lerpFunctionType,
                StartCoroutine, _onDone.ToAction());
        }
    }
}
