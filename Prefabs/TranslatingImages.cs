using Common.Basic.Collections;
using Common.Unity.Components;
using Common.Unity.Coroutines;
using Common.Unity.GameObjects;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Autonomous
{
    public class TranslatingImages : MonoBehaviour
    {
        [SerializeField] private int _spacing;
        [SerializeField] private float _timeSeconds;
        [SerializeField] private Image _imageTemplate;
        [SerializeField] private Transform _imageParent;

        private Image[] _imageArray;
        private int _currentSpacingIndex;

        private void Start()
        {
            _imageTemplate.gameObject.SetActive(false);
 
            int imageCount = RectTransformFunctions.GetCountByHeightIn(_imageTemplate, _imageParent);
            Pool.CreateResizeSpawnAll(_imageTemplate, _imageParent, imageCount, out _imageArray);

            GetUpdateImagesAction()
                .RunAsCoroutineRepeated(() => _timeSeconds, StartCoroutine);
        }

        private Action GetUpdateImagesAction() =>
            () =>
            {
                _imageArray.ForEachN(
                    stepStart: _currentSpacingIndex,
                    step: _spacing + 1,
                    onStep: image => image.enabled = true,
                    onOther: image => image.enabled = false);

                _currentSpacingIndex.IncreaseBy(1, 0, _spacing);
            };
    }
}
