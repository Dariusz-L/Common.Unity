using Common.Unity.Components;
using Common.Unity.Math;
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

        public static Rect WorldToScreenRect(this Rect rect, Vector2? scale = null, Vector2? pivot = null)
        {
            return ConvertWorldRectToScreenSpace(rect.position, rect.size, scale, pivot);
        }

        public static Rect ConvertWorldRectToScreenSpace(RectTransform rt)
        {
            var pos = new Vector2(rt.position.x, rt.position.y);
            var size = rt.rect.size;

            return ConvertWorldRectToScreenSpace(pos, size, rt.lossyScale, rt.pivot);
        }

        public static Rect GetWorldRect(this RectTransform rt, Vector2? newSize = null, Vector2? shrinkSize = null)
        {
            var pos = rt.position.ToVector2();
            var rectSize = newSize ?? rt.rect.size;
            var shrinkedSize = shrinkSize == null ? rectSize : rectSize - shrinkSize.Value * 2;

            pos.x = rt.GetWorldTopCenter().x;
            pos.y = rt.GetWorldTopCenter().y;

            pos.y -= rectSize.y * rt.lossyScale.y / 2;

            rectSize = Vector2.Scale(shrinkedSize, rt.lossyScale);

            return new Rect(pos, rectSize);
        }

        public static Rect GetWorldRectResizedX(this RectTransform rt, float newSizeX)
        {
            return rt.GetWorldRect(new Vector2(newSizeX, rt.rect.size.y));
        }

        public static Rect GetWorldRectResizedY(this RectTransform rt, float newSizeY)
        {
            return rt.GetWorldRect(new Vector2(rt.rect.size.x, newSizeY));
        }

        public static Rect GetWorldRectResizedAndShrinkedY(this RectTransform rt, float newSizeY, float shrinkSizeY)
        {
            return rt.GetWorldRect(new Vector2(rt.rect.size.x, newSizeY), new Vector2(0, shrinkSizeY));
        }

        public static Rect GetScreenRect(this RectTransform rt)
        {
            var worldRect = rt.GetWorldRect();
            return worldRect.WorldToScreenRect();
        }

        public static Rect GetScreenRectResizedAndShrinkedY(this RectTransform rt, float newBaseSizeY, float shrinkSizeY)
        {
            var worldRect = rt.GetWorldRectResizedAndShrinkedY(newBaseSizeY, shrinkSizeY);
            return worldRect.WorldToScreenRect();
        }
    }
}
