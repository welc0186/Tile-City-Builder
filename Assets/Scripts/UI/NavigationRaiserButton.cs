using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationRaiserButton : MonoBehaviour
{
    [SerializeField] private GameEvent navigationEvent;
    // public NavigationEventID eventID;

    public void RaiseEvent()
    {
        // navigationEvent.Raise(this, eventID);
    }
}
