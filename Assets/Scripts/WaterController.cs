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
        private bool EnemyPolluted { get; set; }
        private bool SelfPolluted { get; set; }
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
            if (SelfPolluted)
                _tilemap.color = Color.yellow;
            else if(EnemyPolluted)
                _tilemap.color = Color.red;
            else
                _tilemap.color = Color.white;

            if (SlimeWaiting > 0)
                Timer += Time.deltaTime;
            if (Timer >= GenerateTime)
            {
                Timer -= GenerateTime;
                var slime = Instantiate(SlimePrefab, new Vector3(GeneratePoint.x, GeneratePoint.y, 0), new Quaternion());
                if (SelfPolluted)
                    slime.GetComponent<HPController>().isEnemy = false;
                else if (EnemyPolluted)
                    slime.GetComponent<HPController>().isEnemy = true;
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
                var isEnemy = col.gameObject.GetComponent<HPController>().isEnemy;
                if (!isEnemy)
                {
                    if(SelfPolluted)
                        SlimeWaiting += 2;
                    else
                    {
                        EnemyPolluted = false;
                        SelfPolluted = true;
                        SlimeWaiting = 0;
                        Timer = 0;
                    }
                }
                else
                {
                    if (EnemyPolluted)
                        SlimeWaiting += 2;
                    else
                    {
                        SelfPolluted = false;
                        EnemyPolluted = true;
                        SlimeWaiting = 0;
                        Timer = 0;
                    }
                }
                Destroy(col.gameObject);
            }
            else if (col.gameObject.CompareTag("Purify"))
            {
                if (EnemyPolluted)
                {
                    Destroy(col.gameObject);
                    EnemyPolluted = false;
                    SlimeWaiting = 0;
                    Timer = 0;
                }
            }
        }
    }
}
