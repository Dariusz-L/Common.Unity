using UnityEngine;

namespace MLU.Commands
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