using SpherumTestTask.Configurations;
using SpherumTestTask.Core;

namespace SpherumTestTask.Controllers
{
    public class ScenesController
    {
        private SceneLoader _sceneLoader;
        private CubeObserver _cubeObserver;
        private float _triggerDistance;
        private string _triggerSceneName;

        public ScenesController(SceneLoader sceneLoader, CubeObserver cubeObserver, GameConfig config)
        {
            _sceneLoader = sceneLoader;
            _cubeObserver = cubeObserver;
            _triggerDistance = config.TriggerDistanceBetweenCubes;
            _triggerSceneName = config.TriggerSceneName;
            _cubeObserver.onDistanceChanged += CheckDistanceBetweenCubes;
            _cubeObserver.onDeactivated += DetachObserver;

            _sceneLoader.LoadNextScene(_triggerSceneName);
        }

        private void CheckDistanceBetweenCubes(float distance)
        {
            if (distance <= _triggerDistance)
            {
                _sceneLoader.EnableLoadedScene();
            }
        }

        private void DetachObserver()
        {
            _cubeObserver.onDistanceChanged -= CheckDistanceBetweenCubes;
            _cubeObserver.onDeactivated -= DetachObserver;
        }

    }
}