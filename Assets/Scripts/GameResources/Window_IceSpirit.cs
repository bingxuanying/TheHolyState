using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Window_IceSpirit : MonoBehaviour
    {
        private void Awake()
        {
            UpdateResourceTextObject();
        }
        // Start is called before the first frame update
        private void UpdateResourceTextObject()
        {
            transform.Find("Amount").GetComponent<UnityEngine.UI.Text>().text = GlobalVars.IceSpirit.ToString();
        }
    }
}