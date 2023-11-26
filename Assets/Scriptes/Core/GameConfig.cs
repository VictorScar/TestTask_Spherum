using SpherumTestTask.Controllers;
using SpherumTestTask.Controllers.Inputs;
using SpherumTestTask.SceneObjects;
using SpherumTestTask.UI;
using UnityEngine;

namespace SpherumTestTask.Configurations
{
    [CreateAssetMenu(menuName = "Game Configuration", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] public SphereVisualizer SphereVisualizerPrefab;
        [SerializeField] public MovableCube CubePrefab;
        [SerializeField] public SphereObject SpherePrefab;

        [SerializeField] public UIManager UIManagerPrefab;
        [SerializeField] public GameScreen GameScreenPrefab;
        [SerializeField] public Curtain CurtainPrefab;

        [SerializeField] public Color[] CubeColors;
        [SerializeField] public InputConfig[] InputConfigs;

        [SerializeField] public int SphereCount = 20;
        [SerializeField] public int CubeCount = 20;

        [SerializeField] public float TimeToRepeatCheckDistance = 0.1f;

        [SerializeField] public float SpherePositionRadius = 20f;
        [SerializeField] public float DrawSphereDistance = 2f;
        [SerializeField] public float TriggerDistanceBetweenCubes = 1f;
        [SerializeField] public float HideCurtainDelay = 2f;

        [SerializeField] public string TriggerSceneName = "Level2";
    }
}