using System;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class ComparisonConditionFloat : MonoBehaviour
    {
        [SerializeField] private Operator _operator;
        [SerializeField] private GetFloat _getValue;

        public bool IsTrue(float otherValue)
        {
            var value = _getValue?.Invoke();

            switch (_operator)
            {
                case Operator.Equals:
                    return value == otherValue;

                case Operator.NotEquals:
                    return value != otherValue;

                case Operator.Greater:
                    return value > otherValue;

                case Operator.GreaterOrEquals:
                    return value >= otherValue;

                case Operator.Lower:
                    return value < otherValue;

                case Operator.LowerOrEquals:
                    return value <= otherValue;
            }

            return false;
        }

        [Serializable] public class GetFloat : SerializableCallback<float> { }

        public enum Operator
        {
            Equals,
            NotEquals,

            Greater,
            GreaterOrEquals,

            Lower,
            LowerOrEquals,
        }
    }
}
