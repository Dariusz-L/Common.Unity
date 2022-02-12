using UnityEngine;
using UnityEngine.UI;
using static MLU.Commands.SerializableCallbacks;

namespace StoryPanel
{
    public class TextAndImageSetter : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getStoryPanelGO;
        [SerializeField] private Sprite _sprite; 
        [SerializeField] private string _text;

        public void Set()
        {
            var storyPanelGO = _getStoryPanelGO?.Invoke();
            var image = storyPanelGO.GetComponent<Image>();
            if (image)
                image.sprite = _sprite;

            var text = storyPanelGO.GetComponent<Text>();
            if (text)
                text.text = _text;
        }
    }
}