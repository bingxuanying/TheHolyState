using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfoPanel
{
    public class RadianceInfoPanelControl : MonoBehaviour
    {
        private static RadianceInfoPanelControl instance;

        private void Awake()
        {
            instance = this;
        }

        public static void RadianceShow()
        {
            instance.gameObject.SetActive(true);
        }

        public static void RadianceHide()
        {
            instance.gameObject.SetActive(false);
        }
    }
}