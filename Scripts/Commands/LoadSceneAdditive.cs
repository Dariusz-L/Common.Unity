using UnityEngine;
using UnityEngine.SceneManagement;

namespace MLU.Commands
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
