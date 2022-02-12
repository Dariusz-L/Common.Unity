using Assets.Scripts.Common.Unity.Components;
using UnityEngine;

namespace Common.Unity.Scripts.Transforms
{
    public class TransformScaler : MonoBehaviour
    {
        public void ScalePositiveX()
        {
            transform.ScalePositiveX();
        }

        public void ScaleNegativeX()
        {
            transform.ScaleNegativeX();
        }

        public void ScaleReverseX()
        {
            transform.ScaleReverseX();
        }

        public void ScaleSetX(float value)
        {
            transform.ScaleSetX(value);
        }

        public void ScaleX(float value)
        {
            transform.ScaleX(value);
        }

        public void ScaleY(float value)
        {
            transform.ScaleY(value);
        }
    }
}
