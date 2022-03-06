using System;
using UnityEngine;

namespace Common.Unity.Events
{
    [Serializable] public class GetGameObject : SerializableCallback<GameObject> { }
    [Serializable] public class GetBool : SerializableCallback<bool> { }
}
