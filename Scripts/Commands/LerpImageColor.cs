using Assets.Scripts.MLU.Commands;
using Common.Unity.Functional;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Common.Algorithms.LerpingFunctions;
using static MLU.Commands.SerializableCallbacks;

namespace MLU.Commands
{
    public class LerpImageColor : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getImageGO;
        [SerializeField] private Image _imageToFade;
        [SerializeField] private Color _targetColor;
        [SerializeField] private float _durationSeconds;
        [SerializeField] private List<UnityEvent> _onDone;
        [SerializeField] private LerpFunctionType _lerpFunctionType = LerpFunctionType.Linear;

        public void Execute()
        {
            if (!_imageToFade)
                _imageToFade = _getImageGO?.Invoke().GetComponent<Image>();

            FadeImageFunctions.LerpColor(
                _imageToFade, _targetColor, _durationSeconds, _lerpFunctionType,
                StartCoroutine, _onDone.ToAction());
        }
    }
}
