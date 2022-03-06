﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common.Unity.Instantiation
{
    public class InstantiationObjectListCast<T> : InstantiationObjectCast<T>, IInstantiationObjectList<T>
    {
        private readonly IInstantiationObjectList<Component> _anyComponentIO;

        public InstantiationObjectListCast(IInstantiationObjectList<Component> anyComponentIO)
            : base(anyComponentIO)
        {
            _anyComponentIO = anyComponentIO;
        }

        public IEnumerable<T> Objects => _anyComponentIO.Objects.Select(c => c.GetComponent<T>());

        public void Destroy(int index) => _anyComponentIO.Destroy(index);

    }
}
