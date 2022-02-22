using System;
using UnityEditor;
using UnityEngine;
using static MLU.Commands.SerializableCallbacks;

namespace Unity.Common.Scripts
{
    public class EnableBehaviour : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGO;
        [SerializeField] private GameObject _go;
        [SerializeField] private MonoScript _script;
        [SerializeField] private bool _enabled = true;

        public void Call()
        {
            if (!_go)
                _go = _getGO?.Invoke();

            Type type = _script.GetClass();
            var behaviour =_go.GetComponent(type) as Behaviour;
            behaviour.enabled = _enabled;
        }
    }
}
