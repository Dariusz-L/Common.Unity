using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Common.Unity.Events
{
    [Serializable] public class GetGameObject : SerializableCallback<GameObject> { }
    [Serializable] public class GetBool : SerializableCallback<bool> { }
    [Serializable] public class OnPointerEventData : UnityEvent<PointerEventData> { }
}
