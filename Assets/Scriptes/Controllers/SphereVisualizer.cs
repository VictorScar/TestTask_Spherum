using SpherumTestTask.Configurations;
using SpherumTestTask.SceneObjects;
using UnityEngine;

namespace SpherumTestTask.Controllers
{
    public class SphereVisualizer : MonoBehaviour
    {
        private SphereObject[] _spheres;
        private float _drawSphereDistance;
        private CubeObserver _cubeObserver;


        public void Init(CubeObserver cubeObserver, GameConfig gameConfig, SphereObject[] spheres)
        {
            _spheres = spheres;
            _drawSphereDistance = gameConfig.DrawSphereDistance;
            _cubeObserver = cubeObserver;

            foreach (var sphere in _spheres)
            {
                sphere.transform.SetParent(transform);
            }

            _cubeObserver.onDistanceChanged += DrawSpheres;
            _cubeObserver.onDeactivated += DetachVisualizer;

            HideSpheres();
        }

        private void DrawSpheres(float distance)
        {
            if (distance < _drawSphereDistance)
            {
                ShowSpheres();
            }
            else
            {
                HideSpheres();
            }
        }

        private void ShowSpheres()
        {
            SetSpharesVisibility(true);
        }

        private void HideSpheres()
        {
            SetSpharesVisibility(false);
        }

        private void SetSpharesVisibility(bool isVisibility)
        {
            if (_spheres == null)
            {
                return;
            }

            foreach (var sphere in _spheres)
            {
                sphere.gameObject.SetActive(isVisibility);
            }
        }

        private void DetachVisualizer()
        {
            _cubeObserver.onDistanceChanged -= DrawSpheres;
            _cubeObserver.onDeactivated -= DetachVisualizer;
        }

        private void OnDestroy()
        {
            if (_cubeObserver != null)
            {
                DetachVisualizer();
            }
        }
    }
}