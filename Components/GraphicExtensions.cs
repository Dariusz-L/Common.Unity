using Common.Unity.GameObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.Components
{
    public static class GraphicExtensions
    {
        public static void NestedGraphicsToClear(this GameObject gameObject)
        {
            gameObject.ForEachNested<Graphic>(g => g.ToClearSingle());
        }

        public static void NestedGraphicsToTransparent(this GameObject gameObject)
        {
            gameObject.ForEachNested<Graphic>(g => g.ToTransparentSingle());
        }

        public static void ToTransparentSingle(this Graphic graphic)
        {
            graphic.ModifyChannel(3, 0);
        }

        public static void ToClearSingle(this Graphic graphic)
        {
            graphic.ModifyChannel(3, 1);
        }

        public static void ModifyChannel(this Graphic graphic, int index, float value)
        {
            var color = graphic.color;
            color[index] = value;
            graphic.color = color;
        }
    }
}
