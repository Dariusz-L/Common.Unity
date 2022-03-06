using UnityEngine;
using static MLU.Commands.SerializableCallbacks;

namespace Unity.Common.Scripts
{
    public class EnableComponent : MonoBehaviour
    {
        [SerializeField] private GetGameObject _getGO;
        [SerializeField] private GameObject _go;
        [SerializeField] private string _componentType;
        [SerializeField] private bool _enabled = true;

        public void Call()
        {
            if (!_go)
                _go = _getGO?.Invoke();

            var behaviour =_go.GetComponent(_componentType) as Behaviour;
            behaviour.enabled = _enabled;
        }
    }
}
