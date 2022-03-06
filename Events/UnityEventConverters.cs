using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Common.Unity.Events
{
    public static class UnityEventConverters
    {
        public static Action ToAction(this List<UnityEvent> actions) =>
            () => actions.ForEach(h => h?.Invoke());
    }
}
