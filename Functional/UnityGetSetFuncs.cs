using Assets.Scripts.Common.Unity.Components;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.Functional
{
    public static class UnityGetSetFuncs
    {
        public static Action<Vector2> SetTransformPosition2DAction(Transform transform) =>
                pos => transform.SetPosition(pos);

        public static Func<Vector2> GetTransformPosition2DFunc(Transform transform) =>
            () => transform.position;

        public static Action<Color> SetImageColorAction(Image image) =>
            color => image.color = color;

        public static Func<Color> GetImageColorFunc(Image image) =>
            () => image.color;
    }
}
