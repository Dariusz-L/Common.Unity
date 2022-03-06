using Common.Basic.Collections;
using Common.Unity.Events;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Unity.Scripts.Common
{
    public class CallPrefabScriptVoidMethod : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGO;
        [SerializeField] private UnityEvent _methodToCall;

        private GameObject _go;

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

            methodInfo.Invoke(component, new object[] {});
        }
    }
}
