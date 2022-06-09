using Common.Unity.Components;
using Common.Unity.Inspector;
using Common.Unity.UI;
using UnityEngine;

namespace Common.Unity.Scripts.Common.UI
{
    public class ScreenPositionDisplay : MonoBehaviour
    {
        [ReadOnly] [SerializeField] private Vector2 _position;

        private void Update()
        {
            var screenRect = this.RT().GetScreenRect();
            _position = screenRect.center;
        }
    }
}
