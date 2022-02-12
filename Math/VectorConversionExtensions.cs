using UnityEngine;

namespace Common.Unity.Math
{
    public static class VectorConversionExtensions
    {
        public static Vector2 ToVector2(this Vector3 vector) => vector;
        public static Vector3 ToVector3(this Vector2 vector) => vector;
        public static Vector3 ToVector3(this Vector2Int vector) => new Vector3(vector.x, vector.y);
    }
}
