using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Window_WindSpirit : MonoBehaviour
    {
        private void Awake()
        {
            UpdateResourceTextObject();
        }
        // Start is called before the first frame update
        private void UpdateResourceTextObject()
        {
            transform.Find("Amount").GetComponent<UnityEngine.UI.Text>().text = GlobalVars.WindSpirit.ToString();
        }
    }
}