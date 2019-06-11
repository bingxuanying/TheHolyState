using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonClick
{
    [RequireComponent(typeof(Button))]
    public class GhostButton : MonoBehaviour
    {
        public Button mybutton;
        public Sprite blockB;
        public Sprite blockB_disable;
        private int Ghostcounter = 0;
        void Start()
        {
            mybutton = GetComponent<Button>();
        }

        // Update is called once per frame
        public void changeButton()
        {
            Ghostcounter++;
            if (Ghostcounter % 2 == 0)
            {
                mybutton.image.overrideSprite = blockB;
            }
            else
            {
                mybutton.image.overrideSprite = blockB_disable;
            }
        }
    }
}