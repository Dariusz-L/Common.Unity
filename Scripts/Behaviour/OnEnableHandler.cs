using Common.Unity.Functional;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Infrastructure.Unity.Behaviour
{
    public class OnEnableHandler : MonoBehaviour
    {
        [SerializeField] private List<UnityEvent> _onEnable;

        private void OnEnable()
        {
            _onEnable
                .ToAction()
                .Invoke();
        }
    }
}