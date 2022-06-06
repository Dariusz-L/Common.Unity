using UnityEngine;

namespace Common.Unity.GameObjects
{
    public abstract class PoolFactory<T> : MonoBehaviour
        where T : Component
    {
        [SerializeField] private T _prefab;
        [SerializeField] private Transform _poolParent;
        [SerializeField] private int _count = 1000;
        private Pool<T> _pool;

        protected virtual void Awake() =>
            _pool = new Pool<T>(_prefab, _poolParent, _count);

        public virtual T Create(Transform parent) =>
            _pool.Spawn(parent);

        public void DestroyAll() => _pool.DestroyAll();

        public Pool<T> Pool => _pool;
    }
}
