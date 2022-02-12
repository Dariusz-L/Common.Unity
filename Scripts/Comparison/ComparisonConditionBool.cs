using System;
using UnityEngine;

namespace Common.Unity.Scripts.Comparison
{
    public class ComparisonConditionBool : MonoBehaviour
    {
        [SerializeField] private Operator _operator;
        [SerializeField] private GetBool _getValue;

        public bool IsTrue(bool otherValue)
        {
            var value = _getValue?.Invoke();

            switch (_operator)
            {
                case Operator.Equals:
                    return value == otherValue;

                case Operator.NotEquals:
                    return value != otherValue;
            }

            return false;
        }

        [Serializable] public class GetBool : SerializableCallback<bool> { }

        public enum Operator
        {
            Equals,
            NotEquals,
        }
    }
}
