using Assets.Scripts;
using Assets.Scripts.Common.Unity.Components;
using Common.Basic.Collections;
using Common.Unity.Math;
using System;
using UnityEngine;

namespace MLU
{
    public class HookChain : MonoBehaviour
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private GetExtents _getExtents;
        [SerializeField] private Transform _parent;
        [SerializeField] private Transform _movingTransform;
        [SerializeField] private Vector2 _initialSpawnPosition;

        private float _diffExtent;
        private Vector2 _initialMovingPosition;

        private Pool<Transform> _objectPool;

        private void Start()
        {
            _diffExtent = _getExtents.Invoke();
            _initialMovingPosition = _movingTransform.position;

            _objectPool = new Pool<Transform>(_prefab, _parent);
            _objectPool.Resize(100);

            var spawned = _objectPool.Spawn(active: true); //
            spawned.transform.SetLocalPosition(_initialSpawnPosition);
        }

        private void Update()
        {
            var pos = _movingTransform.position.ToVector2();
            var distance = Vector2.Distance(pos, _initialMovingPosition);
            var distanceRest = distance % _diffExtent;

            int count = (int) (distance / _diffExtent) + 1;
            int countDiff = count - _objectPool.ActiveCount;
            if (countDiff < 0)
                countDiff.ForEach(() => _objectPool.DestroyLast());

            if (countDiff > 0)
                countDiff.ForEach(() => 
                {
                    var _lastPos = _objectPool.LastSpawned.transform.localPosition;

                    var spawned = _objectPool.Spawn(active: true);
                    spawned.transform.SetLocalPosition(_lastPos);
                    spawned.transform.TranslateY(_diffExtent * Math.Sign(distance));
                });
        }

        [Serializable] public class GetExtents : SerializableCallback<float> {}
    }
}
