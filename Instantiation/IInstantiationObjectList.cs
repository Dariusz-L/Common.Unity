﻿using System.Collections.Generic;

namespace Common.Basic.Unity.Behaviour
{
    public interface IInstantiationObjectList<out T> : IInstantiationObject<T>
    {
        IEnumerable<T> Objects { get; }
        void Destroy(int index);
    }
}
