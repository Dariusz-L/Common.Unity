using Common.Infrastructure.Unity.UI;
using UnityEngine;

namespace MLU.Commands
{
    public class RebuildAllUI : MonoBehaviour
    {
        public void RebuildAll() => UILayoutRebuilder.RebuildAll();
    }
}
