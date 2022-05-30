using UnityEngine;

namespace Common.Unity.Components
{
    public static class TransformSetParentExtensions
    {
        public static void SetParent(this Component component, Component parent, bool worldPositionStays = false) =>
            component.transform.SetParent(parent.transform, worldPositionStays);

    }
}
