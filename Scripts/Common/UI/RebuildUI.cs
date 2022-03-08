﻿using Common.Unity.Events;
using Common.Unity.UI;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class RebuildUI : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGameObject;
        [SerializeField] private GameObject _gameObject;

        public void Execute()
        {
            if (!_gameObject)
                _gameObject = _getGameObject?.Invoke();

            UILayoutRebuilder.Rebuild(_gameObject);
        }
    }
}
