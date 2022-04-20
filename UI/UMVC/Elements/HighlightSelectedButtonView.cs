using Common.Basic.UMVC.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.UI.UMCV
{
    public class HighlightSelectedButtonView : ButtonView, IHighlightedButtonView
    {
        [SerializeField] private Image _highlightImage;

        public void Highlight() => _highlightImage.enabled = true; 
    }
}
