using SpherumTestTask.Core;
using SpherumTestTask.SceneObjects;
using System;
using System.Collections;
using UnityEngine;

namespace SpherumTestTask.Controllers
{
    public class CubeObserver
    {
        private Bootstrapper _bootstrapper;
        private MovableCube[] _cubes;

        private float timeToRepeatCheck = 0.1f;

        public event Action<float> onDistanceChanged;
        public event Action onDeactivated;

        public CubeObserver(Bootstrapper bootstrapper)
        {
            _bootstrapper = bootstrapper;
            var repeatTime = bootstrapper.GameConfig.TimeToRepeatCheckDistance;

            if (repeatTime > 0f)
            {
                timeToRepeatCheck = repeatTime;
            }

            _cubes = bootstrapper.ObjectFactory.CreateCubes();
            _bootstrapper.StartCoroutine(CheckDistanceBetwennCubes());
            _bootstrapper.onInitializationEnded += ActivateCubesControllers;
        }

        private void ActivateCubesControllers()
        {
            foreach (var cube in _cubes)
            {
                cube.Controller?.Activate();
            }

            _bootstrapper.onInitializationEnded -= ActivateCubesControllers;
        }

        private IEnumerator CheckDistanceBetwennCubes()
        {
            var firstCubeTransform = _cubes[0].transform;
            var secondCubeTransform = _cubes[1].transform;
            var distance = 0f;

            while (firstCubeTransform != null && secondCubeTransform != null)
            {
                distance = Vector3.Distance(firstCubeTransform.position, secondCubeTransform.position);
                onDistanceChanged?.Invoke(distance);

                yield return new WaitForSeconds(timeToRepeatCheck);
            }

            onDeactivated?.Invoke();
        }
    }
}