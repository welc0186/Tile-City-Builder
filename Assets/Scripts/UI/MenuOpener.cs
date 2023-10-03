using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    private GamePanel parentPanel;

    void OnEnable()
    {
        parentPanel = GetComponentInParent<GamePanel>();
    }
    
    public void OpenMenu(MenuID menuID)
    {
        parentPanel?.OpenMenu(menuID);
    }
}
