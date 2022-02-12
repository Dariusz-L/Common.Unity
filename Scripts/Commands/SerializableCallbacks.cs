using System;
using UnityEngine;

namespace MLU.Commands
{
    class SerializableCallbacks
    {
        [Serializable] public class GetGameObject : SerializableCallback<GameObject> { }
        [Serializable] public class GetBool : SerializableCallback<bool> { }
    }
}
