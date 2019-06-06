using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class WorkerController : MonoBehaviour
    {
        private bool CutTree { get; set; }
        private GameObject CurrentTree { get; set; }
        private bool GetWater { get; set; }
        private float Timer { get; set; } = 0;
        public float TreeCutTime { get; set; } = 10;
        public float WaterGetTime { get; set; } = 10;

        void Update()
        {
            // Action updated, call clean work
            if (CutTree || GetWater)
            {
                Stop();
                Timer += Time.deltaTime;
            }

            if (CutTree && Timer >= TreeCutTime)
            {
                Timer = 0;
                //TODO: Animation
                Destroy(CurrentTree);
                FindNextTree();
            }

            if (GetWater && Timer >= WaterGetTime)
            {
                Timer -= WaterGetTime;
                //TODO: Animation
            }

        }

        private void FindNextTree()
        {
            //TODO
            CutTree = false;
        }

        private void Stop()
        {
            //TODO
        }

        private void CleanWork()
        {
            CutTree = false;
            GetWater = false;
            Timer = 0;
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name == "tree")
            {
                CutTree = true;
                GetWater = false;
                CurrentTree = col.gameObject;
            }
            else if (col.gameObject.name == "water")
            {
                GetWater = true;
            }
            else
            {
                CutTree = false;
                GetWater = false;
            }
        }
    }
}
