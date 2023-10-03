using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class PointsPopupSpawner
{
    public static void Spawn(GameObject target, string text)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/PointsPopup");
        GameObject.Instantiate(prefab, target.transform);
        prefab.GetComponent<TMP_Text>().text = text;
    }
}


public class PointsPopup : MonoBehaviour
{
    
    [SerializeField] private float destroyTime = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

}
