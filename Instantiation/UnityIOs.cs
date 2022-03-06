using System;
using UnityEngine;

namespace Common.Unity.Instantiation
{
    public static class UnityIOs
    {
        [Serializable] public class TransformIO : InstantiationObject<Transform>, IInstantiationObject<Transform> {}
        [Serializable] public class TransformIOList : InstantiationObjectList<Transform>, IInstantiationObjectList<Transform> {}
    }
}
