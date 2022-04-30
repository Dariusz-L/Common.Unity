using Common.Basic.Collections;
using Common.Unity.Components;
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
            modifiedText.ModifyChannel(3, 0);

            var inputField = createInputField();
            inputField.text = modifiedText.text;
            inputField.onFocusSelectAll = true;
            inputField.ActivateInputField();

            inputField.onDeselect.AddListener(text =>
            {
                DiscardInputFieldAndEnableText(destroyInputField, modifiedText);
                onDiscard(text);
            });

            inputField.onSubmit.AddListener(text =>
            {
                if (!inputField.text.IsEmpty() && text != modifiedText.text)
                {
                    modifiedText.text = text;
                    onSubmit(text);
                }

                DiscardInputFieldAndEnableText(destroyInputField, modifiedText);
            });
        }

        public static void DiscardInputFieldAndEnableText(
            Action trashInputFieldBase,
            TMP_Text modifiedText)
        {
            trashInputFieldBase();
            modifiedText.ModifyChannel(3, 1);
        }
    }
}
