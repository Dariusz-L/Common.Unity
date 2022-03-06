﻿using Common.Unity.Events;
using UnityEngine;

namespace MLU.Commands
{
    public class Destroy : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getTargetGO;
        [SerializeField] private GameObject _target;

        public void Execute()
        {
            if (!_target)
                _target = _getTargetGO?.Invoke();

            Destroy(_target);
        }
    }
};