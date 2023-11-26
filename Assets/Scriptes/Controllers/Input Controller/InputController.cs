using System;
using System.Collections;
using UnityEngine;

namespace SpherumTestTask.Controllers.Inputs
{
    public class InputController : MonoBehaviour
    {
        private KeyCode upKey;
        private KeyCode downKey;
        private KeyCode rightKey;
        private KeyCode leftKey;

        private bool isBlocked = false;

        public bool IsBlocked { get => isBlocked; set => isBlocked = value; }

        public event Action<Vector2> onMoveInput;

        public void Init(InputConfig inputConfig)
        {
            upKey = inputConfig.UpInput;
            downKey = inputConfig.DownInput;
            rightKey = inputConfig.RightInput;
            leftKey = inputConfig.LeftInput;
        }

        public void Activate()
        {
            StartCoroutine(ReadMoveInputs());
        }

        private IEnumerator ReadMoveInputs()
        {
            while (!isBlocked)
            {
                var xAxis = Convert.ToInt32(Input.GetKey(rightKey)) - Convert.ToInt32(Input.GetKey(leftKey));
                var zAxis = Convert.ToInt32(Input.GetKey(upKey)) - Convert.ToInt32(Input.GetKey(downKey));

                var inputDirection = new Vector2(xAxis, zAxis);

                onMoveInput?.Invoke(inputDirection);

                yield return null;
            }
        }
    }
}