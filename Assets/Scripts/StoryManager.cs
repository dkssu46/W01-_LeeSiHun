using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStory(int now, bool left)
    {
        Debug.Log("Portal: " + PlayerPrefs.GetInt("Stage"));
        switch (now)
        {
            case 0:
                PlayerPrefs.SetInt("Now", left ? 1 : 2);
                SceneManager.LoadScene(1);
                break;
            case 1:
                PlayerPrefs.SetInt("Now", left ? 3 : 4);
                SceneManager.LoadScene(1);
                break;
            case 2:
                PlayerPrefs.SetInt("Now", left ? 5 : 6);
                SceneManager.LoadScene(1);
                break;
            case 3:
                PlayerPrefs.SetInt("Now", 7);
                SceneManager.LoadScene(1);
                break;
            case 4:
                PlayerPrefs.SetInt("Now", left ? 8 : 9);
                SceneManager.LoadScene(1);
                break;
            case 5:
                PlayerPrefs.SetInt("Now", 7);
                SceneManager.LoadScene(1);
                break;
            case 6:
                PlayerPrefs.SetInt("Now", left ? 8 : 9);
                SceneManager.LoadScene(1);
                break;
            case 7:
                PlayerPrefs.SetInt("Now", left ? 10 : 14);
                PlayerPrefs.SetInt("Stage", left ? 2001 : 2002);
                SceneManager.LoadScene(1);
                break;
            case 8:
                PlayerPrefs.SetInt("Now", left ? 17 : 20);
                PlayerPrefs.SetInt("Stage", left ? 2003 : 2004);
                SceneManager.LoadScene(1);
                break;
            case 9:
                PlayerPrefs.SetInt("Now", left ? 22 : 25);
                PlayerPrefs.SetInt("Stage", left ? 2005 : 2006);
                SceneManager.LoadScene(1);
                break;
            case 10:
                PlayerPrefs.SetInt("Now", left ? 11 : 24);
                SceneManager.LoadScene(1);
                break;
            case 11:
                PlayerPrefs.SetInt("Now", left ? 27 : 31);
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") % 10 + (left ? 3010 : 3020));
                if (PlayerPrefs.GetInt("Stage") > 4000) PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") - 1000);
                Debug.Log("stage: " + PlayerPrefs.GetInt("Stage"));
                SceneManager.LoadScene(1);
                break;
            case 12:
                PlayerPrefs.SetInt("Now", 16);
                SceneManager.LoadScene(1);
                break;
            case 14:
                PlayerPrefs.SetInt("Now", left ? 15 : 12);
                SceneManager.LoadScene(1);
                break;
            case 15:
                PlayerPrefs.SetInt("Now", left ? 28 : 30);
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") % 10 + (left ? 3030 : 3040));
                if (PlayerPrefs.GetInt("Stage") > 4000) PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") - 1000);
                SceneManager.LoadScene(1);
                break;
            case 16:
                PlayerPrefs.SetInt("Now", left ? 19 : 30);
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") % 10 + (left ? 3050 : 3060));
                if (PlayerPrefs.GetInt("Stage") > 4000) PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") - 1000);
                SceneManager.LoadScene(1);
                break;
            case 17:
                PlayerPrefs.SetInt("Now", left ? 18 : 20);
                SceneManager.LoadScene(1);
                break;
            case 18:
                PlayerPrefs.SetInt("Now", left ? 15 : 12);
                SceneManager.LoadScene(1);
                break;
            case 19:
                PlayerPrefs.SetInt("Now", 29);
                SceneManager.LoadScene(1);
                break;
            case 20:
                PlayerPrefs.SetInt("Now", left ? 21 : 12);
                SceneManager.LoadScene(1);
                break;
            case 21:
                PlayerPrefs.SetInt("Now", 15);
                SceneManager.LoadScene(1);
                break;
            case 22:
                PlayerPrefs.SetInt("Now", 23);
                SceneManager.LoadScene(1);
                break;
            case 23:
                PlayerPrefs.SetInt("Now", left ? 24 : 14);
                SceneManager.LoadScene(1);
                break;
            case 24:
                PlayerPrefs.SetInt("Now", left ? 29 : 31);
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") % 10 + (left ? 3070 : 3080));
                if (PlayerPrefs.GetInt("Stage") > 4000) PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") - 1000);
                SceneManager.LoadScene(1);
                break;
            case 25:
                PlayerPrefs.SetInt("Now", left ? 26 : 12);
                SceneManager.LoadScene(1);
                break;
            case 26:
                PlayerPrefs.SetInt("Now", 24);
                SceneManager.LoadScene(1);
                break;
            case 27:
                PlayerPrefs.SetInt("Now", left ? 32 : 36);
                SceneManager.LoadScene(1);
                break;
            case 28:
                PlayerPrefs.SetInt("Now", left ? 35 : 33);
                SceneManager.LoadScene(1);
                break;
            case 29:
                PlayerPrefs.SetInt("Now", left ? 32 : 34);
                SceneManager.LoadScene(1);
                break;
            case 30:
                PlayerPrefs.SetInt("Now", left ? 37 : 38);
                SceneManager.LoadScene(1);
                break;
            case 31:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage")%100 + 3100);
                PlayerPrefs.SetInt("End1", 1);
                SceneManager.LoadScene(2);
                break;
            case 32:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") % 100 + 3200);
                PlayerPrefs.SetInt("End2", 1);
                SceneManager.LoadScene(2);
                break;
            case 33:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") % 100 + 3300);
                PlayerPrefs.SetInt("End3", 1);
                SceneManager.LoadScene(2);
                break;
            case 34:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") % 100 + 3200);
                PlayerPrefs.SetInt("End2", 1);
                SceneManager.LoadScene(2);
                break;
            case 35:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") % 100 + 3400);
                PlayerPrefs.SetInt("End4", 1);
                SceneManager.LoadScene(2);
                break;
            case 36:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") % 100 + 3500);
                PlayerPrefs.SetInt("End5", 1);
                SceneManager.LoadScene(2);
                break;
            case 37:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") % 100 + 3600);
                PlayerPrefs.SetInt("End6", 1);
                SceneManager.LoadScene(2);
                break;
            case 38:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") % 100 + 3100);
                PlayerPrefs.SetInt("End1", 1);
                SceneManager.LoadScene(2);
                break;
        }
    }
}
