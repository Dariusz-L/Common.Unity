using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.UI
{
    public static class ContentSizeFitterExtensions
    {
        public static void FitToLayoutChildren(this GameObject go) => go.GetComponent<ContentSizeFitter>().FitToLayoutChildren();

        public static void FitToLayoutChildren(this ContentSizeFitter csf)
        {
            if (!csf)
                return;

            csf.SetLayoutHorizontal();
            csf.SetLayoutVertical();
        }
    }
}
