using Common.Unity.Components;
using Common.Unity.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Common.Basic.Maths.LerpingFunctions;

namespace Common.Unity.Scripts.Common
{
    public class LerpImagesChildrenColor : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getImagesParent;
        [SerializeField] private GameObject _imagesParent;
        [SerializeField] private Color _targetColor;
        [SerializeField] private float _durationSeconds;
        [SerializeField] private List<UnityEvent> _onDone;
        [SerializeField] private LerpFunctionType _lerpFunctionType = LerpFunctionType.Linear;

        public void Execute()
        {
            if (!_imagesParent)
                _imagesParent = _getImagesParent?.Invoke();

            var images = _imagesParent.GetComponentsInChildren<Image>();

            foreach (var image in images)
                LerpFunctions.LerpColor(
                    image, _targetColor, _durationSeconds, _lerpFunctionType,
                    StartCoroutine, _onDone.ToAction());
        }
    }
}
