using UnityEngine;

namespace Common.Unity.Math
{
    public static class VectorTranslationExtensions
    {
        public static Vector2 TranslateX(this Vector3 point, float translationX)
        {
            point.x += translationX;
            return new Vector2(point.x, point.y);
        }
    }
}
