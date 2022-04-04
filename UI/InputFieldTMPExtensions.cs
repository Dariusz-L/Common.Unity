using Common.Basic.Collections;
using System;
using TMPro;

namespace Common.Unity.UI
{
    public static class InputFieldTMPExtensions
    {
        public static void SpawnInputField(
           Func<TMP_InputField> createInputField,
           Action destroyInputField,
           TMP_Text modifiedText,
           Action<string> onSubmit,
           Action<string> onDiscard)
        {
            modifiedText.enabled = false;

            var inputField = createInputField();
            inputField.text = modifiedText.text;
            inputField.onFocusSelectAll = true;
            inputField.ActivateInputField();

            inputField.onDeselect.AddListener(text =>
            {
                DiscardInputFieldAndEnableText(text, destroyInputField, modifiedText);
                onDiscard(text);
            });

            inputField.onSubmit.AddListener(text =>
            {
                if (!inputField.text.IsEmpty() && text != modifiedText.text)
                {
                    modifiedText.text = text;
                    onSubmit(text);
                }

                DiscardInputFieldAndEnableText(text, destroyInputField, modifiedText);
            });
        }

        public static void DiscardInputFieldAndEnableText(
            string newText,
            Action trashInputFieldBase,
            TMP_Text modifiedText)
        {
            trashInputFieldBase();
            modifiedText.enabled = true;
        }
    }
}
