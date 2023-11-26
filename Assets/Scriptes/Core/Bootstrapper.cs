using SpherumTestTask.Configurations;
using SpherumTestTask.Controllers;
using SpherumTestTask.Factory;
using SpherumTestTask.UI;
using System;
using System.Collections;
using UnityEngine;

namespace SpherumTestTask.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;

        private ObjectFactory _objectFactory;
        private UIFactory _uiFactory;

        private SphereVisualizer _visualizer;
        private CubeObserver _cubeObserver;
        private SceneLoader _sceneLoader;
        private ScenesController _scenesController;

        private UIManager _uiManager;
        private Curtain _curtain;

        public ObjectFactory ObjectFactory { get => _objectFactory; }
        public GameConfig GameConfig { get => _gameConfig; }

        public event Action onInitializationEnded;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            _sceneLoader = new SceneLoader(this);
            _objectFactory = new ObjectFactory(_gameConfig);
            _uiFactory = new UIFactory(_gameConfig);

            _cubeObserver = new CubeObserver(this);
            _uiManager = _uiFactory.CreateUIManger(this, _cubeObserver);
            _scenesController = new ScenesController(_sceneLoader, _cubeObserver, _gameConfig);

            _visualizer = _objectFactory.CreateSphereVisualizer(_cubeObserver);
            
            StartCoroutine(ForceDelayForInitialization(_gameConfig.HideCurtainDelay));

        }

        private IEnumerator ForceDelayForInitialization(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            onInitializationEnded?.Invoke();
        }
    }
}