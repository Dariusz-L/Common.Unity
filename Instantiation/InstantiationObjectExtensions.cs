using Common.Infrastructure.Unity.GameObjects;
using UnityEngine;

namespace Common.Infrastructure.Unity.Behaviour
{
    public static class InstantiationObjectExtensions
    {
        public static IInstantiationObject<T> GetIO<T>(this object @object)
        {
            var script = @object.GetIf<IInstantiationObject<T>>(script => script.Prefab.GetComponent<T>() != null);
            if (script != null)
                return script;

            var parentScript = @object.GetFromParentIf<IInstantiationObject<T>>(script => script.Prefab.GetComponent<T>() != null);
            if (parentScript != null)
                return parentScript;

            var transformScript = @object.GetIf<IInstantiationObject<Transform>>(script => script.Prefab.GetComponent<T>() != null);
            if (transformScript != null)
                return new InstantiationObjectCast<T>(transformScript);

            var parentTransformScript = @object.GetFromParentIf<IInstantiationObject<Transform>>(script => script.Prefab.GetComponent<T>() != null);
            if (parentTransformScript != null)
                return new InstantiationObjectCast<T>(parentTransformScript);

            return null;
        }

        public static IInstantiationObjectList<T> GetIOList<T>(this object @object)
        {
            var script = @object.GetIf<IInstantiationObjectList<T>>(script => script.Prefab.GetComponent<T>() != null);
            if (script != null)
                return script;

            var parentScript = @object.GetFromParentIf<IInstantiationObjectList<T>>(script => script.Prefab.GetComponent<T>() != null);
            if (parentScript != null)
                return parentScript;

            var transformScript = @object.GetIf<IInstantiationObjectList<Transform>>(script => script.Prefab.GetComponent<T>() != null);
            if (transformScript != null)
                return new InstantiationObjectListCast<T>(transformScript);

            var parentTransformScript = @object.GetFromParentIf<IInstantiationObjectList<Transform>>(script => script.Prefab.GetComponent<T>() != null);
            if (parentTransformScript != null)
                return new InstantiationObjectListCast<T>(parentTransformScript);

            return null;
        }
    }
}
