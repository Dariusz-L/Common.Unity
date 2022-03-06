using UnityEngine;

namespace Common.Unity.Scripts.Colliders
{
    [RequireComponent(typeof(Collider2D))]
    public class IsInsideCollider : MonoBehaviour
    {
        private bool _flag;

        public bool Check() => _flag;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _flag = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _flag = false;
        }
    }
}
