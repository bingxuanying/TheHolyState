using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class WaterController : MonoBehaviour
    {
        private bool Polluted { get; set; }
        private int SlimeWaiting { get; set; } = 0;
        private float Timer { get; set; } = 0;
        public float GenerateTime = 10;
        public GameObject SlimePrefab;

        void Start()
        {

        }

        void Update()
        {
            if (SlimeWaiting > 0)
                Timer += Time.deltaTime;
            if (Timer >= GenerateTime)
            {
                Timer -= GenerateTime;
                var target = Instantiate(SlimePrefab, transform);
                target.transform.localPosition = new Vector3(0, 0, 0);
                SlimeWaiting--;
                if (SlimeWaiting == 0)
                    Timer = 0;
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name == SlimePrefab.name)
            {
                // TODO: Add animation
                Destroy(col.gameObject);
                if (!Polluted)
                    Polluted = true;
                if (Polluted)
                    SlimeWaiting += 2;
            }
            else if (col.gameObject.name == "waterElement")
            {
                if (Polluted)
                {
                    Polluted = false;
                    SlimeWaiting = 0;
                    Timer = 0;
                }
            }
        }
    }
}
