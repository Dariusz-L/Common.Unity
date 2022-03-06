using Common.Unity.GameObjects;
using Common.Unity.Inspector;
using UnityEngine;

namespace Common.Basic.Unity.Behaviour
{
    public class InstantiationObjectParentTag<T> : IInstantiationObject<T>
        where T : Component
    {
        [TagSelector] [SerializeField] private string _parentTag;
        [SerializeField] private T _prefab;
        private T _instantiated;

        public T Instantiate()
        {
            Parent = GameObject.FindGameObjectWithTag(_parentTag).transform;
            if (Parent && Parent.gameObject)
            {
                if (!Parent.gameObject.activeSelf)
                    Parent.gameObject.SetActive(true);
            }

            _instantiated = GameObject.Instantiate(_prefab, Parent);
            return _instantiated;
        }

        public void Destroy()
        {
            _instantiated.Destroy();
            _instantiated = null;
        }

        public T Object => _instantiated;
        public Transform Parent { get; private set; }
        public T Prefab => _prefab;
    }
}
