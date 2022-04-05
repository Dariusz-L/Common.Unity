using Common.Basic.UMVC.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.UI.UMCV
{
    public class ImageView : View, IImageView
    {
        [SerializeField] private Image _image;

        public override void Hide() => _image.enabled = false;
        public override void Show() => _image.enabled = true;

        public void SetColor(float r, float g, float b, float a = 1) => _image.color = new Color(r, g, b, a);
    }
}
