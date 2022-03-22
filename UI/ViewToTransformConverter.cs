using Common.Basic.UMVC;
using UnityEngine;

namespace Common.Unity.UI
{
    public static class ViewToTransformConverter
    {
        public static Transform ToTransform(this IView view)
        {
            if (view is Component component)
                return component.transform;

            return null;
        }
    }
}
