using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonClick
{
    [RequireComponent(typeof(Button))]
    public class SpiritButton : MonoBehaviour
    {
        public Button mybutton;
        public Sprite blockA;
        public Sprite blockA_disable;
        private int Spiritcounter = 0;
        void Start()
        {
            mybutton = GetComponent<Button>();
        }

        // Update is called once per frame
        public void changeButton()
        {
            Spiritcounter++;
            if (Spiritcounter % 2 == 0)
            {
                mybutton.image.overrideSprite = blockA;
            }
            else
            {
                mybutton.image.overrideSprite = blockA_disable;
            }
        }
    }
}