using Common.Unity.Components;
using UnityEngine;
using static Common.Basic.Maths.LerpingFunctions;

namespace Common.Unity.Scripts.Common
{
    public class LerpScale : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private float _sourceValue = 1;
        [SerializeField] private float _targetValue = 0.9f;
        [SerializeField] private float _durationSeconds;
        [SerializeField] private LerpFunctionType _lerpFunctionType;

        private bool _switch;

        public void Execute()
        {
            var targetValue = _switch ? _sourceValue : _targetValue;
            LerpFunctions.LerpScale2D(
                _target.transform, targetValue, _durationSeconds, _lerpFunctionType,
                StartCoroutine, onDone: () =>
                {
                    _switch = !_switch;
                    Execute();
                }
            );
        }
    }
}
