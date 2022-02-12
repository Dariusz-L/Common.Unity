using UnityEngine;
using UnityEngine.Events;

namespace Common.Unity.Scripts
{
    public class ConditionActionElse : MonoBehaviour
    {
        [SerializeField] private Condition _condition;
        [SerializeField] private UnityEvent _action;
        [SerializeField] private UnityEvent _else;

        private void Start()
        {
            _condition.dynamic = false;
        }

        public void Invoke()
        {
            if (!_condition.Invoke(0))
            {
                _else.Invoke();
                return;
            }

            _action.Invoke();
        }
    }
}
