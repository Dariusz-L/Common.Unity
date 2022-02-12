using Common.Domain.Collections;
using Common.Domain.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Pool<T> 
        where T : Component
    {
        private readonly T _prefab;
        private readonly Transform _parent;

        private readonly Queue<T> _instantiated = new Queue<T>();
        private readonly List<T> _active = new List<T>();
        private T _last;

        public Pool(T prefab, Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public static Pool<T> Create(T prefab, Transform parent = null)
        {
            return new Pool<T>(prefab, parent);
        }

        public void Resize(int count)
        {
            Enumerable.Range(0, count)
                .ForEach(i =>
                {
                    var instantiated = Instantiate();
                    instantiated.gameObject.SetActive(false);
                    _instantiated.Enqueue(instantiated);
                });
        }

        private T Instantiate()
        {
            if (_parent != null)
                return GameObject.Instantiate(_prefab, _parent);
            else
                return GameObject.Instantiate(_prefab);
        }

        public T Spawn(bool active = true)
        {
            return _instantiated
                .DeEnqueue()
                .Then(i => i.gameObject.SetActive(active))
                .Then(i => _last = i)
                .Then(i => _active.Add(i));
        }

        public IEnumerable<T> Spawn(int count, bool active = true) =>
            Enumerable
                .Range(0, count)
                .Select(i => Spawn(active))
                .ToList();

        public IEnumerable<T> SpawnAll(bool active = true) =>
           Spawn(_instantiated.Count());

        public void DestroyLast()
        {
            DestroyAt(_active.Count - 1);
        }

        public void DestroyFirst()
        {
            DestroyAt(0);
        }

        public void DestroyAll()
        {
            _active.ForEach(i => i.gameObject.SetActive(false));
            _active.Clear();
            _last = null;
        }

        public void DestroyAt(int index)
        {
            if (!_active.IsIndexInRange(index))
                return;

            _active[index]
                .Then(i => i.gameObject.SetActive(false))
                .Then(i => i.transform.parent = _parent)
                .Then(i => _active.RemoveAt(index))
                .Then(i => _last = _active.LastOrDefault());
        }

        public void DestroyAt(IEnumerable<int> indexes)
        {
            indexes.ForEach(i => DestroyAt(i));
        }

        public void Destroy(IEnumerable<T> spawnedItems)
        {
            spawnedItems.ForEach(i => Destroy(i));
        }

        public void Destroy(T spawnedItem)
        {
            _active
                .IndexOf(spawnedItem)
                .Then(i => DestroyAt(i));
        }

        public void ForEach(Action<T> action)
        {
            _instantiated.ForEach(i => action(i));
        }

        public T LastSpawned => _last;
        public int ActiveCount => _active.Count;
        public IEnumerable<T> Instantiated => _instantiated;
        public IEnumerable<T> Active => _active;
        public T Prefab => _prefab;
    }

    public static class Pool
    {
        public static Pool<T> CreateResizeSpawnAll<T>(T prefab, Transform parent, int count)
            where T : Component
        {
            var pool = Pool<T>.Create(prefab, parent);

            pool.Resize(count);
            pool.SpawnAll();

            return pool;
        }

        public static Pool<T> CreateResizeSpawnAll<T>(T prefab, Transform parent, int count, out T[] spawnedArray)
            where T : Component
        {
            var pool = CreateResizeSpawnAll(prefab, parent, count);

            spawnedArray = pool.Instantiated.ToArray();

            return pool;
        }
    }
}
