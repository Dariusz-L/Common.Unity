using Common.Unity.Components;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class TransformTranslator : MonoBehaviour
    {
        public void TranslateX(float value)
        {
            transform.TranslateX(value);
        }

        public void TranslateY(float value)
        {
            transform.TranslateY(value);
        }
    }
}
