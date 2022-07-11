﻿using UnityEngine;

namespace Common.Unity.GameObjects
{
    public abstract class NotAPoolFactory<T> : MonoBehaviour
        where T : Component
    {
        [SerializeField] private T _prefab;
        [SerializeField] private Transform _poolParent;
        [SerializeField] private int _count = 1000;
        private IPool<T> _pool;

        protected virtual void Awake() =>
            _pool = new NotAPool<T>(_prefab);
            
        public virtual T Create(Transform parent) =>
            _pool.Spawn(parent);

        public void DestroyAll() => _pool.DestroyAll();

        public IPool<T> Pool => _pool;
    }
}
