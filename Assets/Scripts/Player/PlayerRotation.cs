using System;
using Globals;
using UnityEngine;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
    
        private const float _xSensitivity = 20;
        private const float _ySensitivity = 20;

        private float _xRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Look(Vector2 input)
        {
            var mouseX = input.x;
            var mouseY = input.y;

            _xRotation -= (mouseY * Time.deltaTime) * _ySensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
    
            transform.Rotate(Vector3.up * (mouseX*Time.deltaTime) * _xSensitivity);
        }
    }
}
