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

        void Update()
        {
            // Check if on the right edge
            if (Input.mousePosition.x >= Screen.width - Delta)
            {
                // Move the camera
                transform.position += Vector3.right * Time.deltaTime * Speed;
            }

            // Check if on the left edge
            if (Input.mousePosition.x <= Delta)
            {
                // Move the camera
                transform.position += Vector3.left * Time.deltaTime * Speed;
            }

            // Check if on the top edge
            if (Input.mousePosition.y <= Delta)
            {
                // Move the camera
                transform.position += Vector3.down * Time.deltaTime * Speed;
            }

            // Check if on the bottom edge
            if (Input.mousePosition.y >= Screen.height - Delta)
            {
                // Move the camera
                transform.position += Vector3.up * Time.deltaTime * Speed;
            }
        }
    }
}
