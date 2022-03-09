using Common.Basic.Collections;
using Common.Unity.Components;
using Common.Unity.Events;
using Common.Unity.GameObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Common.Basic.Math.LerpingFunctions;
using static UnityEngine.UI.ContentSizeFitter;

namespace Common.Unity.Scripts.Common
{
    public class LerpRTHeight : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getImageGO;
        [SerializeField] private GameObject _goListItem;
        [SerializeField] private GameObject _go;
        [SerializeField] private float _targetValue;
        [SerializeField] private float _durationSeconds;
        [SerializeField] private List<UnityEvent> _onDone;
        [SerializeField] private LerpFunctionType _lerpFunctionType = LerpFunctionType.Linear;

        public void Execute()
        {
            if (!_go)
                _go = _getImageGO?.Invoke();

            var rt = _go.GetComponent<RectTransform>();
            var h = rt.sizeDelta.y;

            var upperCSFs = _go.GetComponentsInParentUntil<ContentSizeFitter>(_goListItem);
            var upperRTs = upperCSFs.Select(c => c.GetComponent<RectTransform>()).ToArray();

            upperCSFs.SetFitModeIfExist(FitMode.Unconstrained, out var previous);

            LerpFunctions.LerpRTHeight(
                _go.GetComponent<RectTransform>(), _targetValue, _durationSeconds, _lerpFunctionType,
                StartCoroutine, onDone: () =>
                {
                    _onDone.ToAction()();
                    //upperCSFs.SetFitModeIfExist(previous);
                });

            var upperRT = upperRTs.Skip(1);
            foreach (var u in upperRT)
                LerpFunctions.LerpRTHeight(
                    u, u.sizeDelta.y - h, _durationSeconds, _lerpFunctionType,
                    StartCoroutine, _onDone.ToAction());
        }
    }

    public static class ss
    {
        public static bool SetFitModeIfExist(this ContentSizeFitter csf, FitMode newValue)
        {
            return csf.gameObject.SetFitModeIfExist(newValue, out var previous);
        }

        public static bool SetFitModeIfExist(this GameObject go, FitMode newValue)
        {
            return go.SetFitModeIfExist(newValue, out var previous);
        }

        public static bool SetFitModeIfExist(this GameObject go, FitMode newValue, out FitMode previous)
        {
            previous = FitMode.Unconstrained;

            var component = go.GetComponent<ContentSizeFitter>();
            if (!component)
                return false;

            previous = component.verticalFit;
            component.verticalFit = newValue;

            return true;
        }

        public static void SetFitModeIfExist(
            this IEnumerable<ContentSizeFitter> csfs, FitMode newValue, out FitMode[] previous)
        {
            csfs.Select(go => go.gameObject).SetFitModeIfExist(newValue, out previous);
        }

        public static void SetFitModeIfExist(
            this IEnumerable<GameObject> gos, FitMode newValue, out FitMode[] previous)
        {
            var previousList = new List<FitMode>();
            foreach (var go in gos)
            {
                go.SetFitModeIfExist(newValue, out var previousSingle);
                previousList.Add(previousSingle);
            }

            previous = previousList.ToArray();
        }

        public static void SetFitModeIfExist(
            this IEnumerable<GameObject> gos, FitMode[] newValue)
        {
            var gosArray = gos.ToArray();

            for (int i = 0; i < gosArray.Length; i++)
                gosArray[i].SetFitModeIfExist(newValue[i], out var previousSingle);
        }

        public static void SetFitModeIfExist(
            this IEnumerable<ContentSizeFitter> csfs, FitMode[] newValue)
        {
            var csfsArray = csfs.ToArray();

            for (int i = 0; i < csfsArray.Length; i++)
                csfsArray[i].gameObject.SetFitModeIfExist(newValue[i], out var previousSingle);
        }

        public static void SetFitModeIfExist(
            this IEnumerable<GameObject> gos, FitMode newValue)
        {
            gos.SetFitModeIfExist(newValue, out var previousSingle);
        }
    }
}
