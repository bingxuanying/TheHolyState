using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Window_WoodResource : MonoBehaviour
    {
        // Start is called before the first frame update
        private void UpdateResourceTextObject()
        {
            transform.Find("WoodAmount").GetComponent<UnityEngine.UI.Text>().text = GlobalVars.Wood.ToString();
        }
    }
}