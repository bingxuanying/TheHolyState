using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        /// <summary>
        /// Pixels. The width border at the edge in which the movement work
        /// </summary>
        public int Delta = 10;

        /// <summary>
        /// Scale. Speed of the movement
        /// </summary>
        public float Speed = 20.0f;

        public float LerpTime = 0.5f;

        private float _timer = 0;
        
        private Vector3 _lastSpeed = Vector3.zero;
        private Vector3 _lastMove = Vector3.zero;

        void Update()
        {
            if (_timer < LerpTime)
            {
                _timer += Time.deltaTime;
            }
            else
            {
                _timer = LerpTime;
            }

            var noMove = true;
            var move = Vector3.zero;

            // Check if on the right edge
            if (Input.mousePosition.x >= Screen.width - Delta)
            {
                noMove = false;
                move += Vector3.right;
            }

            // Check if on the left edge
            if (Input.mousePosition.x <= Delta)
            {
                noMove = false;
                move += Vector3.left;
            }

            // Check if on the top edge
            if (Input.mousePosition.y <= Delta)
            {
                noMove = false;
                move += Vector3.down;
            }

            // Check if on the bottom edge
            if (Input.mousePosition.y >= Screen.height - Delta)
            {
                noMove = false;
                move += Vector3.up;
            }

            // Stop moving
            if (noMove)
            {
                if (_lastSpeed != Vector3.zero)
                    _timer = 0;
                // Move the camera
                transform.position += Vector3.Lerp(_lastMove, Vector3.zero, _timer / LerpTime) * Time.deltaTime *
                                      Speed;
                _lastSpeed = Vector3.zero;
            }
            else
            {
                if (_lastSpeed == Vector3.zero)
                    _timer = 0;
                // Move the camera
                transform.position += Vector3.Lerp(Vector3.zero, move, _timer / LerpTime) * Time.deltaTime *
                                      Speed;
                _lastMove = move;
                _lastSpeed = move;
            }

        }
    }
}
