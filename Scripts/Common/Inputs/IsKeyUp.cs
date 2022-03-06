using UnityEngine;

namespace Common.Unity.Inputs
{
    public class IsKeyUp : MonoBehaviour
    {
        [SerializeField] private KeyCode _key;

        public bool Check() => Input.GetKeyUp(_key);
    }
}
