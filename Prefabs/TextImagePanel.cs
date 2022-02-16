using UnityEngine;
using UnityEngine.UI;

namespace Autonomous
{
    public class TextImagePanel : MonoBehaviour
    {
        [SerializeField] private RectTransform _imageRT;
        [SerializeField] private RectTransform _textRT;

        [SerializeField] private Image _image;
        [SerializeField] private Text _text;

        public void ImageToLeft()
        {
            _imageRT.anchorMin = new Vector2(0, 0);
            _imageRT.anchorMax = new Vector2(0, 0);
            _imageRT.pivot = new Vector2(0, 0);
            _imageRT.anchoredPosition = new Vector2(0, 0);

            _textRT.anchorMin = new Vector2(1, 0);
            _textRT.anchorMax = new Vector2(1, 1);
            _textRT.pivot = new Vector2(1, 0.5f);
            _textRT.anchoredPosition = new Vector2(0, 0);
        }

        public void ImageToRight()
        {
            _imageRT.anchorMin = new Vector2(1, 0);
            _imageRT.anchorMax = new Vector2(1, 0);
            _imageRT.pivot = new Vector2(1, 0);
            _imageRT.anchoredPosition = new Vector2(0, 0);

            _textRT.anchorMin = new Vector2(0, 0);
            _textRT.anchorMax = new Vector2(0, 1);
            _textRT.pivot = new Vector2(0, 0.5f);
            _textRT.anchoredPosition = new Vector2(0, 0);
        }

        public Image Image => _image;
        public Text Text => _text;
    }
}