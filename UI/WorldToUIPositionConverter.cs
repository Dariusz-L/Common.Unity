using UnityEngine;

namespace Common.Unity.UI
{
    public static class WorldToUIPositionConverter
    {
        public static float ConvertWorldPosYTOScreenSpace(float y, Vector2 size, Vector2? scale = null, Vector2? pivot = null)
        {
            return ConvertWorldRectToScreenSpace(new Vector2(0, y), size, scale, pivot).y;
        }

        public static Rect ConvertWorldRectToScreenSpace(Vector2 position, Vector2 size, Vector2? scale = null, Vector2? pivot = null)
        {
            if (pivot == null)
                pivot = new Vector2(0.5f, 0.5f);

            if (scale == null)
                scale = new Vector2(1f, 1f);

            Vector2 sizeScaled = Vector2.Scale(size, scale.Value);
            Rect rect = new Rect(position.x, Screen.height - position.y, sizeScaled.x, sizeScaled.y);

            rect.x -= (pivot.Value.x * sizeScaled.x);
            rect.y -= ((1.0f - pivot.Value.y) * sizeScaled.y);

            return rect;
        }

        public static Rect ConvertWorldRectToScreenSpace(Rect rect, Vector2? scale = null, Vector2? pivot = null)
        {
            return ConvertWorldRectToScreenSpace(rect.position, rect.size, scale, pivot);
        }

        public static Rect ConvertWorldRectToScreenSpace(RectTransform rt)
        {
            var pos = new Vector2(rt.position.x, rt.position.y);
            var size = rt.rect.size;

            return ConvertWorldRectToScreenSpace(pos, size, rt.lossyScale, rt.pivot);
        }
    }
}
