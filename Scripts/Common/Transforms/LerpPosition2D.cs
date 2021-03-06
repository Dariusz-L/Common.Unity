using Common.Unity.Components;
using Common.Unity.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Common.Basic.Maths.LerpingFunctions;

namespace Common.Unity.Scripts.Common
{
    public class LerpPosition2D : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getTargetGO;
        [SerializeField] private Transform _target;
        [SerializeField] private Vector2 _targetPosition;
        [SerializeField] private float _durationSeconds;
        [SerializeField] private List<UnityEvent> _onDone;
        [SerializeField] private LerpFunctionType _lerpFunctionType;

        public void Execute()
        {
            if (!_target)
                _target = _getTargetGO?.Invoke().transform;

            LerpFunctions.LerpPosition2D(
                _target, _targetPosition, _durationSeconds, _lerpFunctionType,
                StartCoroutine, _onDone.ToAction());
        }
    }
}
