using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Basic.Unity.Behaviour
{
    public class OnAwakeHandler : MonoBehaviour
    {
        [SerializeField] private List<UnityEvent> _onAwake;

        private void Awake()
        {
            _onAwake?.ForEach(h => h.Invoke());
        }
    }
}