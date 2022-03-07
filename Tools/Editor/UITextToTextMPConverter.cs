using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Common.Unity.Tools
{
    public class UITextToTextMPConverter : EditorWindow
    {
        private TMP_FontAsset _font;

        [MenuItem("Window/TextMeshPro/UIText Converter")]
        public static void ShowWindow()
        {
            GetWindow(typeof(UITextToTextMPConverter));
        }

        private void OnGUI()
        {
            GUILayout.Label("UIText Converter", EditorStyles.boldLabel);

            _font = EditorGUILayout.ObjectField("New Font", _font, typeof(TMP_FontAsset), false) as TMP_FontAsset;


            if (GUILayout.Button("Convert"))
                Convert();
        }

        private void Convert()
        {
            var rootGOs = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var go in rootGOs)
            {
                if (GUI.changed)
                {
                    EditorUtility.SetDirty(go);
                    EditorSceneManager.MarkSceneDirty(go.gameObject.scene);
                }

                var texts = go.GetComponentsInChildren<Text>();
                foreach (var text in texts)
                {
                    var textGO = text.gameObject;

                    var size = text.fontSize;
                    var alignment = text.alignment;
                    var style = text.fontStyle;
                    var str = text.text;
                    var color = text.color;

                    DestroyImmediate(text, true);

                    var textMP = textGO.AddComponent<TextMeshProUGUI>();
                    textMP.fontSize = size;
                    textMP.alignment = TextAlignmentOptions.MidlineLeft;
                    textMP.fontStyle = FontStyles.Normal;
                    textMP.font = _font;
                    textMP.text = str;
                    textMP.color = color;
                }
            }
        }

       
    }

    public static class Ext
    {
        //public static TextAlignmentOptions ToTextAlignmentOptions(this TextAnchor textAnchor)
        //{
        //    //if (textAnchor == TextAnchor.)
        //}
    }
}