using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.Prefabs
{
    public class StoryPanelUI : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _text;

        public void Set(Sprite sprite, string text)
        {
            _image.sprite = sprite;
            _text.text = text;
        }
    }
}