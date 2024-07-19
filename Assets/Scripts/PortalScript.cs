using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public bool isOne;
    StoryManager sm;
    private void Start()
    {
        sm = GetComponent<StoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sm.NextStory(PlayerPrefs.GetInt("Now", 0), isOne);
        }
    }
}