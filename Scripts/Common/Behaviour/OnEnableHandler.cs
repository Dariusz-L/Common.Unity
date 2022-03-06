using Common.Unity.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Unity.Scripts.Common
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