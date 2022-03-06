using Common.Unity.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Unity.Scripts.Common
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