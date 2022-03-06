using System.Collections.Generic;

namespace Common.Unity.Instantiation
{
    public interface IInstantiationObjectList<out T> : IInstantiationObject<T>
    {
        IEnumerable<T> Objects { get; }
        void Destroy(int index);
    }
}
