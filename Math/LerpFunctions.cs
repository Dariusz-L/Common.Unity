using Common.Domain.Collections;
using Common.Infrastructure.Unity.GameObjects;
using Common.System.Math;
using Common.Unity.Functional;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static Common.System.Math.LerpingFunctions;

namespace Assets.Scripts.MLU.Commands
{
    public class LerpFunctions
    {
        public static void LerpAnimatorSpeed(
           Animator animator,
           float targetValue,
           float durationSeconds,
           LerpFunctionType type,
           Func<IEnumerator, Coroutine> startCoroutine,
           Action onDone)
        {
            LerpingFunctions.Lerp(
                Mathf.Lerp,
                UnityGetSetFuncs.GetAnimatorSpeedFunc(animator),
                UnityGetSetFuncs.SetAnimatorSpeedAction(animator),
                targetValue,
                durationSeconds,
                startCoroutine,
                UnityGlobalStateFuncs.GetDeltaTime,
                LerpingFunctions.GetLerpFunction(type),
                onDone);
        }

        public static void LerpNestedAnimatorSpeed(
           GameObject animator,
           float targetValue,
           float durationSeconds,
           LerpFunctionType type,
           Func<IEnumerator, Coroutine> startCoroutine,
           Action onDone)
        {
            var nestedComponents =
                animator.GetThisAndNestedChildren<Animator>();

            foreach (var child in nestedComponents)
                LerpingFunctions.Lerp(
                    Mathf.Lerp,
                    UnityGetSetFuncs.GetAnimatorSpeedFunc(child),
                    UnityGetSetFuncs.SetAnimatorSpeedAction(child),
                    targetValue,
                    durationSeconds,
                    startCoroutine,
                    UnityGlobalStateFuncs.GetDeltaTime,
                    LerpingFunctions.GetLerpFunction(type),
                    onDone);
        }

        public static void LerpNestedAnimatorTime(
           GameObject animator,
           float targetValue,
           float durationSeconds,
           LerpFunctionType type,
           Func<IEnumerator, Coroutine> startCoroutine,
           Action onDone)
        {
            var nestedComponents =
                animator.GetThisAndNestedChildren<Animator>();

            nestedComponents.ForEach((a, i) => a.speed = 0);

            foreach (var child in nestedComponents)
                LerpingFunctions.Lerp(
                    Mathf.Lerp,
                    UnityGetSetFuncs.GetCurrentAnimationTimeFunc(child),
                    UnityGetSetFuncs.SetCurrentAnimationTimeAction(child),
                    targetValue,
                    durationSeconds,
                    startCoroutine,
                    UnityGlobalStateFuncs.GetDeltaTime,
                    LerpingFunctions.GetLerpFunction(type),
                    onDone);
        }

        public static void LerpCameraSize(
            Camera camera,
            float targetValue,
            float durationSeconds,
            LerpFunctionType type,
            Func<IEnumerator, Coroutine> startCoroutine,
            Action onDone)
        {
            LerpingFunctions.Lerp(
                Mathf.Lerp,
                UnityGetSetFuncs.GetCameraSizeFunc(camera),
                UnityGetSetFuncs.SetCameraSizeAction(camera),
                targetValue,
                durationSeconds,
                startCoroutine,
                UnityGlobalStateFuncs.GetDeltaTime,
                LerpingFunctions.GetLerpFunction(type),
                onDone);
        }

        public static void LerpImageFill(
            Image image,
            float targetValue,
            float durationSeconds,
            LerpFunctionType type,
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
            LerpFunctionType type,
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
            Graphic image,
            Color targetColor,
            float durationSeconds,
            LerpFunctionType type,
            Func<IEnumerator, Coroutine> startCoroutine,
            Action onDone)
        {
            LerpingFunctions.Lerp(
                Color.Lerp,
                UnityGetSetFuncs.GetGraphicColorFunc(image),
                UnityGetSetFuncs.SetGraphicColorAction(image),
                targetColor,
                durationSeconds,
                startCoroutine,
                UnityGlobalStateFuncs.GetDeltaTime,
                LerpingFunctions.GetLerpFunction(type),
                onDone);
        }

        public static void LerpVisibleAndChildrenM(
            IEnumerable<GameObject> goWithVisibleOrChildrenEnumerable,
            Color targetColor,
            float durationSeconds,
            LerpFunctionType type,
            Func<IEnumerator, Coroutine> startCoroutine,
            Action onDone)
        {
            goWithVisibleOrChildrenEnumerable
                .ForEach(go => LerpVisibleAndChildrenM(go, targetColor, durationSeconds, type, startCoroutine, onDone));
        }

        public static void LerpVisibleAndChildrenM(
            GameObject goWithVisibleOrChildren,
            Color targetColor,
            float durationSeconds,
            LerpFunctionType type,
            Func<IEnumerator, Coroutine> startCoroutine,
            Action onDone)
        {
            var visibleComponents =
                goWithVisibleOrChildren.GetThisAndNestedChildren<Graphic>();

            foreach (var visible in visibleComponents)
                LerpFunctions.LerpColor(
                    visible, targetColor, durationSeconds, type,
                    startCoroutine, onDone);
        }

        public static void ToBlack(Image image)
        {
            image.color = Color.black;
        }
    }
}
