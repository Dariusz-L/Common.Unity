using Common.Unity.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.Scripts.Common
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