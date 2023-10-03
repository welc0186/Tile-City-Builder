using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelID
{
    TITLE,
    MAIN_MENU,
    PLAY,
    PAUSE,
    GAME_OVER
}

public class GamePanel : MonoBehaviour
{
    
    public PanelID PanelID;
    private PanelMenu[] panelMenus;

    void OnEnable()
    {
        panelMenus = GetComponentsInChildren<PanelMenu>(true);
        foreach(PanelMenu menu in panelMenus)
        {
            if(menu.DefaultOn)
            {
                OpenMenu(menu.MenuID);
            }
        }
    }

    public void OpenMenu(MenuID menuID, bool exclusive = false)
    {
        foreach(PanelMenu menu in panelMenus)
        {
            if(menu.MenuID == menuID)
            {
               menu.gameObject.SetActive(true);
            }
            if(menu.MenuID != menuID && exclusive)
            {
                menu.gameObject.SetActive(false);
            }
        }
    }

}
