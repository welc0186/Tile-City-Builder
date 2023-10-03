using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Raycaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject testObject = Raycaster.FindObjectAt<OpenTile>(Vector3.zero);
        if(testObject != null)
        {
            Debug.Log("Found object: " + gameObject);
            Debug.Log("True/false check: " + 
                Raycaster.IsObjectAt<OpenTile>(Vector3.zero));
        }

        
    }


}
