﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Common.Unity.Components
{
    public static class TransformTranslationExtensions
    {
        public static Vector2 TranslateX(this Vector3 point, float translationX)
        {
            point.x += translationX;
            return new Vector2(point.x, point.y);
        }

        public static void TranslateX(this IEnumerable<Transform> transforms, float value)
        {
            foreach (var transform in transforms)
                transform.TranslateX(value);
        }

        public static void TranslateX(this Transform transform, float value)
        {
            var position = transform.position;
            position.x += value;
            transform.position = position;
        }

        public static void SetPosition(this Transform transform, Vector2 value)
        {
            var position = transform.position;
            position.x = value.x;
            position.y = value.y;
            transform.position = position;
        }

        public static void SetX(this Transform transform, float value)
        {
            var position = transform.position;
            position.x = value;
            transform.position = position;
        }

        public static void SetY(this Transform transform, float value)
        {
            var position = transform.position;
            position.y = value;
            transform.position = position;
        }

        public static void TranslateY(this IEnumerable<Transform> transforms, float value)
        {
            foreach (var transform in transforms)
                transform.TranslateY(value);
        }

        public static void TranslateY(this Transform transform, float value)
        {
            var position = transform.position;
            position.y += value;
            transform.position = position;
        }
    }
}
