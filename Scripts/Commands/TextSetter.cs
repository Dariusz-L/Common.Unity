using UnityEngine;
using UnityEngine.UI;
using static MLU.Commands.SerializableCallbacks;

namespace StoryPanel
{
    public class TextSetter : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGO;
        [SerializeField] private string _text;

        public void Set()
        {
            var go = _getGO?.Invoke();
            var text = go.GetComponent<Text>();
            if (text)
                text.text = _text;
        }
    }
}