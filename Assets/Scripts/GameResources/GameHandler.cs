﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfoPanel;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            InfoPanelControl.Show();
        }
        else
        {
            InfoPanelControl.Hide();
        }
    }
}