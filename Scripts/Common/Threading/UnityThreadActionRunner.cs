using System;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class UnityThreadActionRunner : MonoBehaviour
    {
        [SerializeField] private bool _setupOnStart;

        private static UnityThreadQueue _mainThreadQueue;

        private void Start()
        {
            if (_setupOnStart)
                Setup();
        }


        public void Setup()
        {
            _mainThreadQueue = new UnityThreadQueue();
        }

        private void Update()
        {
            if (_mainThreadQueue != null)
                _mainThreadQueue.Execute(int.MaxValue, Time.deltaTime);
        }

        public static void Run(Action action, float delayTimeSeconds = 0)
        {
            _mainThreadQueue.SetAction(action, delayTimeSeconds);
        }
    }
}
