using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class PanelOpener
{

    public static void OpenPanel(PanelID panelID, bool exclusive = true)
    {
        var panels = GameObject.FindObjectsOfType<GamePanel>();
        
        foreach(GamePanel panel in panels)
        {
            if(panel.PanelID == panelID)
            {
                panel.gameObject.SetActive(true);
            }
            if(panel.PanelID != panelID && exclusive)
            {
                panel.gameObject.SetActive(false);
            }
        }
    }

}
