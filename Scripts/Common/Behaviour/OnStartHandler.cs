using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Basic.Unity.Behaviour
{
    public class OnStartHandler : MonoBehaviour
    {
        [SerializeField] private List<UnityEvent> _onStart;

        private void Start()
        {
            _onStart?.ForEach(h => h.Invoke());
        }
    }
}