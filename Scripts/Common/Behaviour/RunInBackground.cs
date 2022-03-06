using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class RunInBackground : MonoBehaviour
    {
        [SerializeField] private bool _runInBackground;

        public void Execute()
        {
            Application.runInBackground = _runInBackground;
        }
    }
};