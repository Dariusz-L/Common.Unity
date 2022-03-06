using UnityEngine;
using UnityEngine.UI;
using static MLU.Commands.SerializableCallbacks;

namespace StoryPanel
{
    public class TextAndImageSetter : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGO;
        [SerializeField] private Sprite _sprite; 
        [SerializeField] private string _text;

        public void Set()
        {
            var go = _getGO?.Invoke();
            var image = go.GetComponent<Image>();
            if (image)
                image.sprite = _sprite;

            var text = go.GetComponent<Text>();
            if (text)
                text.text = _text;
        }
    }
}