using System;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Unity.Scripts.Common
{
    internal class AxisHandler : MonoBehaviour
    {
        [SerializeField] private AxisHandler_OnInput OnInput;

        [SerializeField] private bool _smooth = true;
        [SerializeField] private AxisType _axisType = AxisType.Horizontal;

        public void SetInput(AxisHandler_OnInput onInput)
        {

        }

        private void Update()
        {
            if (!CustomInput.IsActive)
                return;

            string axisName = GetAxisName(_axisType);
            var axis = _smooth ? Input.GetAxis(axisName) : Input.GetAxisRaw(axisName);
            OnInput?.Invoke(axis);
        }

        private string GetAxisName(AxisType axisType)
        {
            if (axisType == AxisType.Horizontal)
                return "Horizontal";

            if (axisType == AxisType.Vertical)
                return "Vertical";

            return string.Empty;
        }
    }

    [Serializable]
    public class AxisHandler_OnInput : UnityEvent<float> {}

    public enum AxisType
    {
        Horizontal,
        Vertical
    }
}
