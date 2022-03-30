using Common.Basic.Collections;
using System;
using TMPro;

namespace Common.Unity.UI
{
    public static class InputFieldTMPExtensions
    {
        public static void SpawnInputField(
            Func<TMP_InputField> createInputField,
            Action trashInputField,
            TMP_Text modifiedText,
            Action<string> onSubmit)
        {
            modifiedText.enabled = false;

            var inputField = createInputField();
            inputField.text = modifiedText.text;
            inputField.onFocusSelectAll = true;
            inputField.ActivateInputField();

            inputField.onDeselect.AddListener(text => TrashInputFieldAndEnableText(trashInputField, modifiedText));
            inputField.onSubmit.AddListener(text =>
            {
                if (!inputField.text.IsEmpty() && text != modifiedText.text)
                    onSubmit(text);

                TrashInputFieldAndEnableText(trashInputField, modifiedText);
            });
        }

        public static void TrashInputFieldAndEnableText(
            Action trashInputFieldBase,
            TMP_Text modifiedText)
        {
            trashInputFieldBase();
            modifiedText.enabled = true;
        }
    }
}
