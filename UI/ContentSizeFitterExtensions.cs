using Common.Unity.GameObjects;
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

        public static ContentSizeFitter AddContentSizeFitter_Vertical(this Component component)
        {
            var csf = component.GetOrAddComponent<ContentSizeFitter>();
            csf.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            return csf;
        }
    }
}
