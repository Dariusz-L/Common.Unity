using Autonomous;
using Common.Basic.Collections;
using Common.Basic.Unity.GameObjects;
using UnityEngine;
using UnityEngine.Localization.Components;
using static MLU.Commands.SerializableCallbacks;

namespace MLU.Commands
{
    public class DisplayConversation : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGO;
        [SerializeField] private Conversation _conversation;

        private GameObject _gameObject;
        private TextImagePanel _panel;
        private LocalizeStringEvent _lse;

        private int _index;

        public void StartConversation()
        {
            _index = 0;

            if (!_gameObject)
                _gameObject = _getGO?.Invoke();

            _panel = _gameObject.GetComponent<TextImagePanel>();

            _lse = _panel.Text.GetOrAddComponent<LocalizeStringEvent>();
            if (_lse.OnUpdateString.GetPersistentEventCount() == 0)
                _lse.OnUpdateString.AddListener(str => _panel.Text.text = str);
            
            SetStringRef();
        }

        public void Next()
        {
            _index.IncreaseBy(1, 0, _conversation.Phrases.Count - 1, loop: false);
            SetStringRef();
        }

        public bool IsEnd() => _index == _conversation.Phrases.Count - 1;

        private void SetStringRef()
        {
            var currentPhrase = _conversation.Phrases[_index];

            if (currentPhrase.Side == Side.Left)
            {
                _panel.ImageToLeft();
                _panel.Image.sprite = _conversation.LeftSprite;
            }
            else
            {
                _panel.ImageToRight();
                _panel.Image.sprite = _conversation.RightSprite;
            }

            _lse.StringReference = currentPhrase.LocalizedString;
        }
    }
}
