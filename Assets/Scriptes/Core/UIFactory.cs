using SpherumTestTask.Configurations;
using SpherumTestTask.Controllers;
using SpherumTestTask.Core;
using UnityEngine;

namespace SpherumTestTask.UI
{
    internal class UIFactory
    {
        private GameConfig _gameConfig;

        public UIFactory(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }

        public UIManager CreateUIManger(Bootstrapper bootstrapper, CubeObserver cubeObserver)
        {
            var prefab = _gameConfig.UIManagerPrefab;
            var instance = Object.Instantiate(prefab);
            var gameScreen = CreateGameScreen(cubeObserver);
            var curtain = CreateCurtain();
            instance.Init(bootstrapper, gameScreen, curtain);

            return instance;
        }

        private Curtain CreateCurtain()
        {
            var prefab = _gameConfig.CurtainPrefab;
            var instance = Object.Instantiate(prefab);

            return instance;
        }

        private GameScreen CreateGameScreen(CubeObserver cubeObserver)
        {
            var screenPrefab = _gameConfig.GameScreenPrefab;

            var screen = Object.Instantiate(screenPrefab);
            screen.Init(cubeObserver);

            return screen;
        }
    }
}