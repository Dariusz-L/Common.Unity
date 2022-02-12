using System.Linq;
using UnityEngine;

namespace Common.Unity.Search
{
    public static class SearchFunctions
    {
        public static T Find<T>()
            where T : Component
        {
            var entities = GameObject.FindObjectsOfType<T>(includeInactive: false);
            return entities.FirstOrDefault();
        }

        public static T FindByTag<T>(string tag)
            where T : Component
        {
            var component = GameObject.FindGameObjectWithTag(tag);
            return component.GetComponent<T>();
        }
    }
}
