using Common.Unity.Inspector;
using UnityEngine;

namespace MLU.Commands
{
    public class FindGameObjectWithTag : MonoBehaviour
    {
        [TagSelector] [SerializeField] private string _tag;

        private GameObject _gameObject;

        public GameObject Find()
        {
            if (_gameObject || string.IsNullOrEmpty(_tag))
                return _gameObject;

            _gameObject = GameObject.FindGameObjectWithTag(_tag);

            return _gameObject;
        }
    }
}
