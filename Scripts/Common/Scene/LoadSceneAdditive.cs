using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Unity.Scripts.Common
{
    public class LoadSceneAdditive : MonoBehaviour
    {
        [SerializeField] private Object _scene;
        [SerializeField] private LoadSceneMode _mode;

        public void Execute()
        {
            SceneManager.LoadScene(_scene.name, _mode);
        }
    }
}
