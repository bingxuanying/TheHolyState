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
    }

    public class MonsterGenController : MonoBehaviour
    {
        private float Timer { get; set; } = 0;
        public List<MonsterGenData> Monsters;
        public float GenerateTime = 10;

        // Start is called before the first frame update
        void Start()
        {
            Timer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            Timer += Time.deltaTime;
            if (Timer >= GenerateTime)
            {
                Timer -= GenerateTime;
                var monster = Instantiate(Monsters.RandomElementByWeight(t => t.Weights).Prefab,
                    transform.position, Quaternion.identity);
            }
        }
    }
}
