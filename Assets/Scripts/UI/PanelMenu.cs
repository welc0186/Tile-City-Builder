using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuID
{
    MAIN,
    OPTIONS,
}

public class PanelMenu : MonoBehaviour
{
    public MenuID MenuID { get; [SerializeField] private set; }
    public bool DefaultOn = false;

}
