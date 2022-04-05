using Common.Basic.UMVC.Elements;
using System.Linq;
using UnityEngine;

namespace Common.Unity.UI.UMVC
{
    public static class ViewFinder
    {
        public static T Find<T>()
            => GameObject.FindObjectsOfType<MonoBehaviour>().OfType<T>().FirstOrDefault();

        public static T Find<T>(string id) where T : IView
            => GameObject.FindObjectsOfType<MonoBehaviour>().OfType<T>().FirstOrDefault(v => v.ID == id);
    }
}
