using Common.Algorithms;
using Common.Unity.Functional;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MLU.Commands
{
    public class LerpFunctions
    {
        public static void LerpFill(
            Image image,
            float targetValue,
            float durationSeconds,
            LerpingFunctions.LerpFunctionType type,
            Func<IEnumerator, Coroutine> startCoroutine,
            Action onDone)
        {
            LerpingFunctions.Lerp(
                Mathf.Lerp,
                UnityGetSetFuncs.GetImageFillFunc(image),
                UnityGetSetFuncs.SetImageFillAction(image),
                targetValue,
                durationSeconds,
                startCoroutine,
                UnityGlobalStateFuncs.GetDeltaTime,
                LerpingFunctions.GetLerpFunction(type),
                onDone);
        }

        public static void LerpPosition2D(
            Transform transform,
            Vector2 targetPosition,
            float durationSeconds,
            LerpingFunctions.LerpFunctionType type,
            Func<IEnumerator, Coroutine> startCoroutine,
            Action onDone)
        {
            LerpingFunctions.Lerp(
                Vector2.Lerp,
                UnityGetSetFuncs.GetTransformPosition2DFunc(transform),
                UnityGetSetFuncs.SetTransformPosition2DAction(transform),
                targetPosition,
                durationSeconds,
                startCoroutine,
                UnityGlobalStateFuncs.GetDeltaTime,
                LerpingFunctions.GetLerpFunction(type),
                onDone);
        }

        public static void LerpColor(
            Image image,
            Color targetColor,
            float durationSeconds,
            LerpingFunctions.LerpFunctionType type,
            Func<IEnumerator, Coroutine> startCoroutine,
            Action onDone)
        {
            LerpingFunctions.Lerp(
                Color.Lerp,
                UnityGetSetFuncs.GetImageColorFunc(image),
                UnityGetSetFuncs.SetImageColorAction(image),
                targetColor,
                durationSeconds,
                startCoroutine,
                UnityGlobalStateFuncs.GetDeltaTime,
                LerpingFunctions.GetLerpFunction(type),
                onDone);
        }

        public static void ToBlack(Image image)
        {
            image.color = Color.black;
        }
    }
}
