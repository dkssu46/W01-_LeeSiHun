using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public bool isOne;
    GameObject map;
    StoryManager sm;
    private void Start()
    {
        sm = GetComponent<StoryManager>();
        map = GameObject.FindWithTag("map");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sm.NextStory(PlayerPrefs.GetInt("Now", 0), isOne);
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -map.transform.rotation.z));
    }
}
