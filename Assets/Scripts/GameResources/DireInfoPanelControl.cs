using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfoPanel
{
    public class DireInfoPanelControl : MonoBehaviour
    {
        private static DireInfoPanelControl instance;

        private void Awake()
        {
            instance = this;
        }

        public static void DireShow()
        {
            instance.gameObject.SetActive(true);
        }

        public static void DireHide()
        {
            instance.gameObject.SetActive(false);
        }
    }
}