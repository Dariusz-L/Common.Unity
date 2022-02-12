using UnityEngine;

namespace Assets.Scripts.Common.Unity.Components
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
