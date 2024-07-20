using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    GameObject[] onOffWall;

    public static GameObject[] FindObjectsWithTag(string tag)
    {
        List<GameObject> objectsWithTag = new List<GameObject>();
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag(tag))
            {
                objectsWithTag.Add(obj);
            }
        }

        return objectsWithTag.ToArray();
    }

    void Start()
    {
        onOffWall = FindObjectsWithTag("OnOffWall");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Dust"))
        {
            foreach (GameObject obj in onOffWall)
            {
                obj.SetActive(!obj.activeInHierarchy);
            }
        }
    }
}
