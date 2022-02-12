﻿using UnityEngine;
using static Common.Infrastructure.Unity.Behaviour.UnityIOs;

namespace Common.Unity.Scripts.Instantiation
{
    internal class InstantiationObject : MonoBehaviour
    {
        [SerializeField] private TransformIO _prefabData;

        public void Instantiate()
        {
            _prefabData.Instantiate();
        }

        public void Destroy()
        {
            _prefabData.Destroy();
        }

        public TransformIO PrefabData => _prefabData;
    }
}
