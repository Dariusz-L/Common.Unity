using Common.Basic.Reflection;
using UnityEngine;
using UnityEngine.Events;
using static MLU.Commands.SerializableCallbacks;

namespace Unity.Common.Scripts
{
    public class SetUnityEventCall : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGO;
        [SerializeField] private GameObject _go;
        [SerializeField] private string _componentName;
        [SerializeField] private string _methodName;

        [SerializeField] private GetGameObject _getGO2;
        [SerializeField] private GameObject _go2;
        [SerializeField] private string _methodName2;

        [SerializeField] private UnityEvent _methodToCall;
        [SerializeField] private UnityEvent _methodToCall2;

        public void Set()
        {
            if (!_go)
                _go = _getGO?.Invoke();

            var components = _go.GetComponents<Component>();
            var method = TypeGetMethodExtensions.GetMethod(components, _methodName);


        }
    }
}
