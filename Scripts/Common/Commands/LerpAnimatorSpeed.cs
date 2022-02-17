﻿using Assets.Scripts.MLU.Commands;
using Common.Unity.Functional;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Common.System.Math.LerpingFunctions;
using static MLU.Commands.SerializableCallbacks;

namespace MLU.Commands
{
    public class LerpAnimatorSpeed : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getTargetGO;
        [SerializeField] private GameObject _target;
        [SerializeField] private float _targetValue;
        [SerializeField] private float _durationSeconds;
        [SerializeField] private LerpFunctionType _lerpFunctionType;
        [SerializeField] private List<UnityEvent> _onDone;

        public void Execute()
        {
            if (!_target)
                _target = _getTargetGO?.Invoke();

            LerpFunctions.LerpNestedAnimatorSpeed(
                _target, _targetValue, _durationSeconds, _lerpFunctionType,
                StartCoroutine, _onDone.ToAction());
        }
    }
}
