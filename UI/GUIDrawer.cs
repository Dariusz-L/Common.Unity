using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Unity.UI
{
    public class GUIDrawer : MonoBehaviour
    {
        private static GUIDrawer _instance;

        private readonly List<Action> _actions = new List<Action>();

        public static void Run(Action action)
        {
            if (_instance == null)
                _instance = new GameObject().AddComponent<GUIDrawer>();

            _instance.AddAction(action);
        }

        public void AddAction(Action action)
        {
            _actions.Add(action);
        }

        private void OnGUI()
        {
            if (_actions.Count == 0)
                return;

            foreach (var action in _actions)
            {
                action();
            }
        }

        public static void DrawQuad(Rect position) => Run(() => DrawQuadImpl(position, Color.green));
        public static void DrawQuad(Rect position, Color color) => Run(() => DrawQuadImpl(position, color));

        private static void DrawQuadImpl(Rect position, Color color)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, color);
            texture.Apply();
            GUI.skin.box.normal.background = texture;
            GUI.Box(position, GUIContent.none);

            DestroyImmediate(texture);
        }
    }
}
