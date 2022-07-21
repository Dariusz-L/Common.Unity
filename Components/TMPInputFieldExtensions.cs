using Common.Unity.GameObjects;
using TMPro;
using UnityEngine;

namespace Common.Unity.Components
{
    public static class TMPInputFieldExtensions
    {
        public static string GetTMPInputFieldText(this Component component)
        {
            var inputField = component.Get<TMP_InputField>();
            return inputField.text;
        }
    }
}
