using SpherumTestTask.Configurations;
using SpherumTestTask.Controllers;
using SpherumTestTask.Controllers.Inputs;
using SpherumTestTask.SceneObjects;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SpherumTestTask.Factory
{
    public class ObjectFactory
    {
        private GameConfig _config;
        public ObjectFactory(GameConfig config)
        {
            _config = config;
        }

        public SphereVisualizer CreateSphereVisualizer(CubeObserver cubeObserver)
        {
            var prefab = _config.SphereVisualizerPrefab;
            var instance = Object.Instantiate(prefab);
            var spheres = CreateSpheres();
            instance.Init(cubeObserver, _config, spheres);

            return instance;
        }

        private SphereObject[] CreateSpheres()
        {
            if (_config == null)
            {
                return null;
            }

            var sphereInstances = new List<SphereObject>();
            var count = _config.SphereCount;
            var radius = _config.SpherePositionRadius;
            var radiusVector = new Vector3(0, 0, radius);
            var angle = 360f / count;

            var spherePrefab = _config.SpherePrefab;
            var spherePos = Vector3.zero;
            var sphereColor = Color.white;

            for (int i = 0; i < count; i++)
            {
                spherePos = Quaternion.Euler(0, angle * i, 0) * radiusVector;

                var instance = Object.Instantiate(spherePrefab);
                sphereColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1);
                instance.transform.position = spherePos;

                var newMaterial = instance.Material;
                newMaterial.color = sphereColor;

                instance.Material = newMaterial;
                sphereInstances.Add(instance);
            }

            return sphereInstances.ToArray();
        }

        public MovableCube[] CreateCubes()
        {
            if (_config == null)
            {
                return null;
            }

            var cubesCount = _config.CubeCount;
            var cubePrefab = _config.CubePrefab;
            var cubeColors = _config.CubeColors;
            var minDistance = _config.DrawSphereDistance;
            var controllerConfigs = _config.InputConfigs;

            var cubes = new MovableCube[cubesCount];

            var cubeStartPos = Vector3.zero;
            var cubeColor = Color.white;
            var direction = -1;

            for (int i = 0; i < cubesCount; i++)
            {
                cubeStartPos = direction * Vector3.right * (minDistance + 1);
                cubeColor = cubeColors[i];
                var instance = Object.Instantiate(cubePrefab);
                var cubeMaterial = instance.Material;
                cubeMaterial.color = cubeColor;
                instance.Material = cubeMaterial;
                instance.transform.position = cubeStartPos;
                var controller = instance.AddComponent<InputController>();
                controller.Init(controllerConfigs[i]);
                instance.SetController(controller);

                cubes[i] = instance;

                direction = -direction;
            }

            return cubes;
        }
    }
}