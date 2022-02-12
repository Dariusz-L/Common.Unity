using Common.Unity.Functional;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MLU.Commands
{
    public class Wait : MonoBehaviour
    {
        [SerializeField] private float _durationSeconds;
        [SerializeField] List<UnityEvent> _onDone;

        private Coroutine _coroutine;

        public void Execute()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            var enumerator = WaitForSeconds(_durationSeconds, _onDone.ToAction());
            _coroutine = StartCoroutine(enumerator);
        }

        private IEnumerator WaitForSeconds(float durationSeconds, Action onDone)
        {
            yield return new WaitForSeconds(durationSeconds);
            onDone?.Invoke();
        }
    }
}
;