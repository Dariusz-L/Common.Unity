using Common.Unity.Inspector;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class FindGameObjectsWithTagCount : MonoBehaviour
    {
        [TagSelector] [SerializeField] private string _tag;

        public int Execute() => GameObject.FindGameObjectsWithTag(_tag).Length;
    }
}
