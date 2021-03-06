using Common.Unity.Inspector;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class ExistsGameObjectWithTag : MonoBehaviour
    {
        [TagSelector] [SerializeField] private string _tag;

        private GameObject _gameObject;

        public bool Execute()
        {
            if (_gameObject || string.IsNullOrEmpty(_tag))
                return _gameObject;

            _gameObject = GameObject.FindGameObjectWithTag(_tag);

            return _gameObject;
        }
    }
}
