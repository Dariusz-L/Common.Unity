using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class IsKeyUp : MonoBehaviour
    {
        [SerializeField] private KeyCode _key;

        public bool Check()
        {
            if (!CustomInput.IsActive)
                return false;

            return Input.GetKeyUp(_key);
        }
    }
}
