using Assets.Scripts.MLU.Commands;
using UnityEngine;
using UnityEngine.UI;
using static Common.System.Math.LerpingFunctions;

namespace Autonomous
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private float _menuWidthOpen = 500;
        [SerializeField] private float _menuWidthClosed = 2;

        [SerializeField] private RectTransform _target;
        [SerializeField] private Image _fillImage;

        private Coroutine _coroutine;

        private bool _openNow;
       
        public void Switch()
        {
            _openNow = !_openNow;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            var targetValue = _openNow ? _menuWidthOpen : _menuWidthClosed;
            _coroutine = LerpFunctions.LerpRTWidth(
                _target, targetValue, 0.5f, LerpFunctionType.Smoother,
                StartCoroutine, LerpFill);
        }

        private void LerpFill()
        {
            var targetValue = !_openNow ? 0 : 1;
            LerpFunctions.LerpImageFill(
                _fillImage, targetValue, 0.5f, LerpFunctionType.Smoother,
                StartCoroutine, LerpFill);
        }

        //private Action GetUpdateImagesAction() =>
        //    () =>
        //    {
        //        _imageArray.ForEachN(
        //            stepStart: _currentSpacingIndex,
        //            step: _spacing + 1,
        //            onStep: image => image.enabled = true,
        //            onOther: image => image.enabled = false);

        //        _currentSpacingIndex.IncreaseBy(1, 0, _spacing);
        //    };
    }
}
