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

        private Vector3 _lastMove = Vector3.zero;
        private Vector3 _lastRealMove = Vector3.zero;

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

            // Check if on the right edge
            if (Input.mousePosition.x >= Screen.width - Delta)
            {
                _lastMove = Vector3.right;
                // reset timer if direction changes
                if (_lastRealMove != _lastMove)
                    _timer = 0;
                _lastRealMove = _lastMove;
                // Move the camera
                transform.position += Vector3.Lerp(Vector3.zero, _lastMove, _timer / LerpTime) * Time.deltaTime *
                                      Speed;
            }

            // Check if on the left edge
            else if (Input.mousePosition.x <= Delta)
            {
                _lastMove = Vector3.left;
                // reset timer if direction changes
                if (_lastRealMove != _lastMove)
                    _timer = 0;
                _lastRealMove = _lastMove;
                // Move the camera
                transform.position += Vector3.Lerp(Vector3.zero, _lastMove, _timer / LerpTime) * Time.deltaTime *
                                      Speed;
            }

            // Check if on the top edge
            else if (Input.mousePosition.y <= Delta)
            {
                _lastMove = Vector3.down;
                // reset timer if direction changes
                if (_lastRealMove != _lastMove)
                    _timer = 0;
                _lastRealMove = _lastMove;
                // Move the camera
                transform.position += Vector3.Lerp(Vector3.zero, _lastMove, _timer / LerpTime) * Time.deltaTime *
                                      Speed;
            }

            // Check if on the bottom edge
            else if (Input.mousePosition.y >= Screen.height - Delta)
            {
                _lastMove = Vector3.up;
                // reset timer if direction changes
                if (_lastRealMove != _lastMove)
                    _timer = 0;
                _lastRealMove = _lastMove;
                // Move the camera
                transform.position += Vector3.Lerp(Vector3.zero, _lastMove, _timer / LerpTime) * Time.deltaTime *
                                      Speed;
            }

            // Stop moving
            else
            {
                // reset timer if direction changes
                if (_lastRealMove != Vector3.zero)
                    _timer = 0;
                // Move the camera
                transform.position += Vector3.Lerp(_lastMove, Vector3.zero, _timer / LerpTime) * Time.deltaTime *
                                      Speed;
                _lastRealMove = Vector3.zero;
            }
        }
    }
}
