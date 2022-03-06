using Common.Basic.Collections;
using UnityEngine;

namespace MLU.Commands
{
    public class FindGameObjectWithName : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private Object _object;

        private GameObject _gameObject;

        public GameObject Execute()
        {
            if (_gameObject)
                return _gameObject;

            if (_name.IsNullOrEmpty())
                _name = _object.name;

            _gameObject = GameObject.Find(_name);

            return _gameObject;
        }
    }
}
