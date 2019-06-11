using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Window_WI : MonoBehaviour
    {
        private void Update()
        {
            UpdateResourceTextObject();
        }
        // Start is called before the first frame update
        private void UpdateResourceTextObject()
        {
            transform.Find("Amount").GetComponent<UnityEngine.UI.Text>().text = GlobalVars.WI.ToString();
        }
    }
}