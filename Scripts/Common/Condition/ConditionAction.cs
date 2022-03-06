using UnityEngine;
using UnityEngine.Events;

namespace Common.Unity.Scripts.Common
{
    public class ConditionAction : MonoBehaviour
    {
        [SerializeField] private Condition _condition;
        [SerializeField] private UnityEvent _action;

        private void Start()
        {
            _condition.dynamic = false;
        }

        public void Invoke()
        {
            if (!_condition.Invoke(0))
                return;

            _action.Invoke();
        }
    }
}
