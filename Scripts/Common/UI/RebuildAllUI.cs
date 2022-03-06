using Common.Unity.UI;
using UnityEngine;

namespace MLU.Commands
{
    public class RebuildAllUI : MonoBehaviour
    {
        public void RebuildAll() => UILayoutRebuilder.RebuildAll();
    }
}
