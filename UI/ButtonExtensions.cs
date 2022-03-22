using System;
using UnityEngine.UI;

namespace Common.Unity.UI
{
    public static class ButtonExtensions
    {
        public static void RemoveAllAndAddListener(this Button button, Action action)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => action());
        }
    }
}
