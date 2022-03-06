using UnityEngine;

namespace Common.Basic.Unity.Behaviour
{
    public interface IInstantiationObject<out T>
    {
        T Instantiate();

        void Destroy();

        T Object { get; }
        Transform Parent { get; }
        T Prefab { get; }
    }
}
