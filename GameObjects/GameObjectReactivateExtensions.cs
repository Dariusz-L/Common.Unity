using UnityEngine;

namespace Common.Unity.GameObjects
{
    public static class GameObjectReactivateExtensions
    {
        public static void Reactivate(this Component component) => component.gameObject.Reactivate();

        public static void Reactivate(this GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }

        public static void ReactivateParent(this Component component) => component.transform.parent.Reactivate();
    }
}
