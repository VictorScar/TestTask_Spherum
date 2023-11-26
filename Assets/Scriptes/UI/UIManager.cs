using SpherumTestTask.Core;
using UnityEngine;

namespace SpherumTestTask.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Camera _uiCamera;

        private Bootstrapper _bootstrapper;

        private GameScreen _gameScreen;
        private Curtain _curtain;

        public GameScreen GameScreen { get => _gameScreen; }

        public void Init(Bootstrapper bootstrapper, GameScreen gameScreen, Curtain curtain)
        {
            _bootstrapper = bootstrapper;
            _gameScreen = gameScreen;
            _gameScreen.transform.SetParent(transform);
            _gameScreen.Canvas.worldCamera = _uiCamera;

            _curtain = curtain;
            _curtain.transform.SetParent(transform);
            _curtain.Canvas.worldCamera = _uiCamera;

            _curtain.Show();
            _bootstrapper.onInitializationEnded += HideCurtain;
        }

        private void HideCurtain()
        {
            _curtain?.Hide();
            _bootstrapper.onInitializationEnded -= HideCurtain;
        }
    }
}