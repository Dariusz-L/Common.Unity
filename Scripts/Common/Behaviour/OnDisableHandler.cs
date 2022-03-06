using Common.Unity.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Basic.Unity.Behaviour
{
    public class OnDisableHandler : MonoBehaviour
    {
        [SerializeField] private List<UnityEvent> _onDisable;

        private void OnEnable()
        {
            _onDisable
                .ToAction()
                .Invoke();
        }
    }
}