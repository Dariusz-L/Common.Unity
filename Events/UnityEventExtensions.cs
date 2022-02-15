using Common.Domain.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Common.Unity.Events
{
    public static class UnityEventExtensions
    {
        public static void Invoke(this IEnumerable<UnityEvent> eventsEnumerable)
        {
            eventsEnumerable.ToInvokeAction()();
        }

        public static Action ToInvokeAction(this IEnumerable<UnityEvent> eventsEnumerable)
        {
            return () =>
            {
                if (eventsEnumerable.IsNullOrEmpty())
                    return;

                eventsEnumerable.ForEach(e => e?.Invoke());
            };
        }

        public static IEnumerable<(Type, string)> GetTargetTypesAndMethodNames(this UnityEvent ev)
        {
            var eventCount = ev.GetPersistentEventCount();

            for (int i = 0; i < eventCount; i++)
            {
                var target = ev.GetPersistentTarget(i);
                if (!target)
                    continue;

                string methodName = ev.GetPersistentMethodName(i);
                if (methodName.IsNullOrEmpty())
                    continue;

                yield return (target.GetType(), methodName);
            }
        }
    }
}
