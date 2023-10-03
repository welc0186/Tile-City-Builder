using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputAction
{
    NONE,
    PLACE,
    ROTATE_CW,
    ROTATE_CCW
}

public class InputMB : MonoBehaviour
{
    
    public Vector3 MousePosition { get; private set; }
    public InputAction InputAction { get; private set; }

    void Update()
    {
        UpdateMousePosition();
        UpdateInputAction();
    }

    void UpdateMousePosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePosition = new Vector3(pos.x, pos.y, 0);
    }

    private void UpdateInputAction()
    {
        if(Input.GetMouseButtonUp(0))
        {
            InputAction = InputAction.PLACE;
            return;
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            InputAction = InputAction.ROTATE_CW;
            return;
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            InputAction = InputAction.ROTATE_CCW;
            return;
        }
        InputAction = InputAction.NONE;
        return;
    }
}
