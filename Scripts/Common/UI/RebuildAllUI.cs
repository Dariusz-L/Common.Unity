using Common.Unity.UI;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class RebuildAllUI : MonoBehaviour
    {
        public void RebuildAll() => UILayoutRebuilder.RebuildAll();
    }
}
