using SpherumTestTask.Controllers;
using TMPro;
using UnityEngine;

namespace SpherumTestTask.UI
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _distanceValueUI;
        [SerializeField] private Canvas _canvas;

        private CubeObserver _cubeObserver;

        public Canvas Canvas { get => _canvas; }

        public void Init(CubeObserver cubeObserver)
        {
            _cubeObserver = cubeObserver;

            _cubeObserver.onDistanceChanged += ShowDistanceValue;
        }

        private void ShowDistanceValue(float distance)
        {
            _distanceValueUI.text = distance.ToString();
        }

        private void OnDestroy()
        {
            _cubeObserver.onDistanceChanged -= ShowDistanceValue;
        }
    }
}