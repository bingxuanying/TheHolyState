using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class System : MonoBehaviour
    {
        public bool goblin;

        void Start()
        {
            GlobalVars.IsGoblin = goblin;
        }
    }
}
