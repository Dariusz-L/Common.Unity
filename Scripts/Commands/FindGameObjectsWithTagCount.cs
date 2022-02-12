using Common.Unity.Inspector;
using UnityEngine;

namespace MLU.Commands
{
    public class FindGameObjectsWithTagCount : MonoBehaviour
    {
        [TagSelector] [SerializeField] private string _tag;

        public int Execute() => GameObject.FindGameObjectsWithTag(_tag).Length;
    }
}
