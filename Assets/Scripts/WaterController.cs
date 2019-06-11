using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts
{
    public class WaterController : MonoBehaviour
    {
        private bool Polluted { get; set; }
        private int SlimeWaiting { get; set; } = 0;
        private float Timer { get; set; } = 0;
        public float GenerateTime = 10;
        public GameObject SlimePrefab;
        public Vector2 GeneratePoint;
        private Tilemap _tilemap;

        void Start()
        {
            _tilemap = GetComponent<Tilemap>();
        }

        void Update()
        {
            _tilemap.color = Polluted ? Color.red : Color.white;

            if (SlimeWaiting > 0)
                Timer += Time.deltaTime;
            if (Timer >= GenerateTime)
            {
                Timer -= GenerateTime;
                Instantiate(SlimePrefab, new Vector3(GeneratePoint.x, GeneratePoint.y, 0), new Quaternion());
                SlimeWaiting--;
                if (SlimeWaiting == 0)
                    Timer = 0;
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Pollute"))
            {
                // TODO: Add animation
                Destroy(col.gameObject);
                if (!Polluted)
                    Polluted = true;
                if (Polluted)
                    SlimeWaiting += 2;
            }
            else if (col.gameObject.CompareTag("Purify"))
            {
                if (Polluted)
                {
                    Destroy(col.gameObject);
                    Polluted = false;
                    SlimeWaiting = 0;
                    Timer = 0;
                }
            }
        }
    }
}
