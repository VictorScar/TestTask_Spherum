using System.Collections;
using UnityEngine;

namespace SpherumTestTask.UI
{
    public class Curtain : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;

        public Canvas Canvas { get => _canvas; }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}