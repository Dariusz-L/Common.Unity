using Common.Unity.Components;
using Common.Unity.Inspector;
using System;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class Facing : MonoBehaviour
    {
        [SerializeField] private GetFacingDirectionSign _getFacingDirectionSign;

        [ReadOnly] [SerializeField] private float _facingDirectionSign;

        public void SetFacingDirectionSign(float facingDirectionSign)
        {
            _facingDirectionSign = facingDirectionSign;
        }

        private void Update()
        {
            if (_getFacingDirectionSign.target != null)
                _facingDirectionSign = (float) _getFacingDirectionSign?.Invoke();

            if (_facingDirectionSign == 0)
                return;

            var sign = Mathf.Sign(_facingDirectionSign);
            if (sign == 1)
                transform.ScalePositiveX();

            if (sign == -1)
                transform.ScaleNegativeX();
        }

        [Serializable] public class GetFacingDirectionSign : SerializableCallback<float> { }
    }
}
