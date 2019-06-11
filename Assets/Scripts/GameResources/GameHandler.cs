using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
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
            if (GlobalVars.IsGoblin)
            {
                RadianceInfoPanelControl.RadianceShow();
            }
            else
            {
                DireInfoPanelControl.DireShow();
            }
        }
        else
        {
            if (GlobalVars.IsGoblin)
            {
                RadianceInfoPanelControl.RadianceHide();
            }
            else
            {
                DireInfoPanelControl.DireHide();
            }
        }
    }
}
