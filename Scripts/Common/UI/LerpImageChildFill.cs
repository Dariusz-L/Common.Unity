using Common.Unity.Components;
using Common.Unity.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Common.Basic.Math.LerpingFunctions;

namespace MLU.Commands
{
    public class LerpImageChildFill : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getImageParent;
        [SerializeField] private GameObject _imageParent;
        [SerializeField] private float _targetValue;
        [SerializeField] private float _durationSeconds;
        [SerializeField] private List<UnityEvent> _onDone;
        [SerializeField] private LerpFunctionType _lerpFunctionType = LerpFunctionType.Linear;

        public void Execute()
        {
            if (!_imageParent)
                _imageParent = _getImageParent?.Invoke();

            var image = _imageParent
                .GetComponentsInChildren<Image>()
                .Where(i => i.type == Image.Type.Filled)
                .FirstOrDefault();

            LerpFunctions.LerpImageFill(
                image, _targetValue, _durationSeconds, _lerpFunctionType,
                StartCoroutine, _onDone.ToAction());
        }
    }
}
