using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfoPanel;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DireInfoPanelControl.DireHide();
        RadianceInfoPanelControl.RadianceHide();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            DireInfoPanelControl.DireShow();
        }
        else
        {
            DireInfoPanelControl.DireHide();
        }
    }
}
