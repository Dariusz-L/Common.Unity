using System;
using UnityEngine;

namespace Common.Basic.Unity.Behaviour
{
    public static class UnityIOs
    {
        [Serializable] public class TransformIO : InstantiationObject<Transform>, IInstantiationObject<Transform> {}
        [Serializable] public class TransformIOList : InstantiationObjectList<Transform>, IInstantiationObjectList<Transform> {}
    }
}
