using System;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Unity.Scripts
{
    public class ConditionCastActionElse : MonoBehaviour
    {
        [SerializeField] private Condition _condition;
        [SerializeField] private UnityEvent _action;
        [SerializeField] private UnityEvent _else;

        private Type _targetType;
        private string _methodType;

        private void Start()
        {
            _targetType = _condition.target.GetType();
            _methodType = _condition.methodName;

            _condition.dynamic = false;
        }

        public void Invoke(object @object)
        {
            var objectComponent = @object as Component;
            if (!objectComponent)
                return;

            var targetComponent = objectComponent.GetComponent(_targetType);
            if (!targetComponent)
                return;

            var method = _targetType.GetMethod(_methodType);
            if (method == null)
                return;

            object result = method.Invoke(targetComponent, null);
            if (!(result is bool boolResult))
                return;

            if (!boolResult)
            {
                _else.Invoke();
                return;
            }

            _action.Invoke();
        }
    }
}
