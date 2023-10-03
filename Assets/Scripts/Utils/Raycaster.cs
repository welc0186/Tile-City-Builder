using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Raycaster
{

    public static GameObject FindObjectAt<T>(Vector3 position)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(position, Vector2.left, (float) 0.0001);
        foreach(RaycastHit2D hit in hits)
        {
            if(hit.transform.gameObject.TryGetComponent(out T component))
                return hit.transform.gameObject;
        }
        return null;
    }

    public static bool IsObjectAt<T>(Vector3 position)
    {
        if(FindObjectAt<T>(position) != null)
            return true;
        return false;
    }

}