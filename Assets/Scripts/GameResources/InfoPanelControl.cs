using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfoPanel
{
    public class InfoPanelControl : MonoBehaviour
    {
        private static InfoPanelControl instance;

        private void Awake()
        {
            instance = this;
        }

        public static void Show()
        {
            instance.gameObject.SetActive(true);
        }

        public static void Hide()
        {
            instance.gameObject.SetActive(false);
        }
    }

}
