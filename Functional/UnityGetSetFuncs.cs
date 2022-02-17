using Assets.Scripts.Common.Unity.Components;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.Functional
{
    public static class UnityGetSetFuncs
    {
        public static Action<Vector2> SetTransformPosition2DAction(Transform transform) =>
                value => transform.SetPosition(value);

        public static Func<Vector2> GetTransformPosition2DFunc(Transform transform) =>
            () => transform.position;

        public static Action<Color> SetGraphicColorAction(Graphic graphic) =>
            value => graphic.color = value;

        public static Func<Color> GetGraphicColorFunc(Graphic graphic) =>
            () => graphic.color;

        public static Action<float> SetImageFillAction(Image image) =>
            value => image.fillAmount = value;

        public static Func<float> GetImageFillFunc(Image image) =>
            () => image.fillAmount;

        public static Action<float> SetCameraSizeAction(UnityEngine.Camera camera) =>
            value => camera.orthographicSize = value;

        public static Func<float> GetCameraSizeFunc(UnityEngine.Camera camera) =>
            () => camera.orthographicSize;
    }
}
