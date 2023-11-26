using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpherumTestTask.Core
{
    public class SceneLoader
    {
        private Bootstrapper _bootstrapper;
        private AsyncOperation _loadLevelOperation;

        public SceneLoader(Bootstrapper bootstrapper)
        {
            _bootstrapper = bootstrapper;
        }

        public void LoadNextScene(string sceneName)
        {
            LoadSceneMode mode = new LoadSceneMode();
            mode = LoadSceneMode.Single;

            _loadLevelOperation = SceneManager.LoadSceneAsync(sceneName, mode);
            _loadLevelOperation.allowSceneActivation = false;
        }

        public void EnableLoadedScene()
        {
            if (_loadLevelOperation == null)
            {
                return;
            }

            _loadLevelOperation.allowSceneActivation = true;
        }
    }
}