﻿using Assets.Scripts.MLU.Commands;
using Common.Basic.Collections;
using Common.Unity.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using static Common.Basic.Math.LerpingFunctions;
using static MLU.Commands.SerializableCallbacks;

namespace MLU.Commands
{
    public class LerpGraphicAndChildrenList : MonoBehaviour
    {
        [SerializeField] private List<GetGameObject> _getVisibleGOList;
        [SerializeField] private List<GameObject> _visibleGOList;
        [SerializeField] private Color _targetColor;
        [SerializeField] private float _durationSeconds;
        [SerializeField] private LerpFunctionType _lerpFunctionType = LerpFunctionType.Linear;
        [SerializeField] private List<UnityEvent> _onDone;

        public void Execute()
        {
            if (_visibleGOList.IsNullOrEmpty())
                _visibleGOList = _getVisibleGOList.Select(get => get?.Invoke()).ToList();

            LerpFunctions.LerpVisibleAndChildrenM(
                _visibleGOList, _targetColor, _durationSeconds, _lerpFunctionType, StartCoroutine, _onDone.ToInvokeAction());
        }
    }
}
