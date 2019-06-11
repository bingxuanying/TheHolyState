using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class MonsterGenData
    {
        public float Weights;
        public GameObject Prefab;
        public int waterResource;
        public int woodResource;
    }

    public class MonsterGenController : MonoBehaviour
    {
        private float Timer { get; set; } = 0;
        public List<MonsterGenData> Monsters;
        public float GenerateTime = 10;
        public bool Generating = true;
        private SpriteRenderer _spriteRenderer;

        // Start is called before the first frame update
        void Start()
        {
            Timer = 0;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Generating)
            {
                _spriteRenderer.color = Color.white;
                Timer += Time.deltaTime;
                if (Timer >= GenerateTime)
                {
                    Timer -= GenerateTime;
                    var monData = Monsters.RandomElementByWeight(t => t.Weights);
                    if (monData.waterResource <= GlobalVars.Water && monData.woodResource <= GlobalVars.Wood)
                    {
                        GlobalVars.Water -= monData.waterResource;
                        GlobalVars.Wood -= monData.woodResource;

                        var monster = Instantiate(monData.Prefab, transform.position, Quaternion.identity);
                        monster.GetComponent<HPController>().isEnemy = GetComponent<HPController>().isEnemy;
                    }
                }
            }
            else
            {
                Timer = 0;
                _spriteRenderer.color = Color.gray;
            }
        }
    }
}
