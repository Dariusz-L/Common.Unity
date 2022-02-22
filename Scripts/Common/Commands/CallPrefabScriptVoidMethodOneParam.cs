using Common.Domain.Collections;
using Common.Unity.Events;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using static MLU.Commands.SerializableCallbacks;

namespace Unity.Common.Scripts
{
    public class CallPrefabScriptVoidMethodOneParam : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGO;
        private GameObject _go;
        [SerializeField] private UnityEvent _methodToCall;

        [SerializeField] private GetGameObject _getParamGO;
        private GameObject _paramGo;

        public void Call()
        {
            if (!_go)
                _go = _getGO?.Invoke();

            var typesAndNames = _methodToCall.GetTargetTypesAndMethodNames();
            if (typesAndNames.IsNullOrEmpty())
                return;

            var typeAndName = typesAndNames.FirstOrDefault();
            var component = _go.GetComponent(typeAndName.Item1);
            if (!component)
                return;

            var methodInfo = component.GetType().GetMethod(typeAndName.Item2);
            if (methodInfo == null)
                return;

            if (!_paramGo)
                _paramGo = _getParamGO?.Invoke();

            methodInfo.Invoke(component, new object[] { _paramGo });
        }
    }
}
