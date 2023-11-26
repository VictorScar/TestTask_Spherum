using SpherumTestTask.Controllers.Inputs;
using UnityEngine;

namespace SpherumTestTask.SceneObjects
{
    public class MovableCube : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private MeshRenderer _meshRenderer;

        private InputController _controller;
        public Material Material { get => _meshRenderer.material; set => _meshRenderer.sharedMaterial = value; }
        public InputController Controller { get => _controller; }

        public void SetController(InputController controller)
        {
            _controller = controller;

            if (_controller == null)
            {
                _controller.onMoveInput -= Move;
                return;
            }

            _controller.onMoveInput += Move;

        }

        private void Move(Vector2 inputDirection)
        {
            transform.position += (inputDirection.x * transform.right + inputDirection.y * transform.forward) * _speed * Time.deltaTime;
        }

        private void OnDestroy()
        {
            _controller.onMoveInput -= Move;
        }
    }
}