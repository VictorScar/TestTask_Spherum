using UnityEngine;

namespace SpherumTestTask.SceneObjects
{
    public class SphereObject : MonoBehaviour
    {
        [SerializeField] MeshRenderer _meshRenderer;

        public Material Material { get => _meshRenderer.material; set => _meshRenderer.sharedMaterial = value; }
    }
}