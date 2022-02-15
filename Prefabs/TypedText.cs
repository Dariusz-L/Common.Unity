using Common;
using Common.Domain.Functional;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Autonomous
{
    public class TypedText : MonoBehaviour
    {
        [SerializeField] private Text _textComponent;
        [SerializeField] private string _text;
        [SerializeField] private float _typeDurationSeconds;
        [SerializeField] private bool _looped = true;

        private Coroutine _coroutine;
        private int _currentTextIndex;

        public void StartTyping()
        {
            if (!_coroutine.IsNull())
                StopCoroutine(_coroutine);

            _currentTextIndex = 1;
            _coroutine = GetTypeTextAction()
                .RunAsCoroutineRepeated(() => _typeDurationSeconds, StartCoroutine);
        }

        public void StopTyping()
        {
            if (!_coroutine.IsNull())
                StopCoroutine(_coroutine);

            _coroutine = null;
        }

        private Action GetTypeTextAction() =>
            () =>
            {
                _textComponent.text = _text.Substring(0, _currentTextIndex);
                _currentTextIndex++;
                if (_currentTextIndex > _text.Length)
                {
                    if (_looped)
                        _currentTextIndex = 1;
                    else
                    {
                        StopCoroutine(_coroutine);
                        _coroutine = null;
                    }
                }
            };
    }
}
