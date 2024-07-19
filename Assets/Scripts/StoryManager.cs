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
                SceneManager.LoadScene(2);
                break;
            case 8:
                PlayerPrefs.SetInt("Now", left ? 17 : 20);
                PlayerPrefs.SetInt("Stage", left ? 2003 : 2004);
                SceneManager.LoadScene(2);
                break;
            case 9:
                PlayerPrefs.SetInt("Now", left ? 22 : 25);
                PlayerPrefs.SetInt("Stage", left ? 2005 : 2006);
                SceneManager.LoadScene(2);
                break;
            case 10:
                PlayerPrefs.SetInt("Now", left ? 11 : 24);
                SceneManager.LoadScene(2);
                break;
            case 11:
                PlayerPrefs.SetInt("Now", left ? 27 : 31);
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + (left ? 1010 : 1020));
                Debug.Log("stage: " + PlayerPrefs.GetInt("Stage"));
                SceneManager.LoadScene(3);
                break;
            case 14:
                PlayerPrefs.SetInt("Now", left ? 15 : 16);
                SceneManager.LoadScene(2);
                break;
            case 15:
                PlayerPrefs.SetInt("Now", left ? 28 : 30);
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + (left ? 1030 : 1040));
                SceneManager.LoadScene(3);
                break;
            case 16:
                PlayerPrefs.SetInt("Now", left ? 29 : 30);
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + (left ? 1050 : 1040));
                SceneManager.LoadScene(3);
                break;
            case 17:
                PlayerPrefs.SetInt("Now", left ? 18 : 19);
                SceneManager.LoadScene(2);
                break;
            case 18:
                PlayerPrefs.SetInt("Now", left ? 15 : 16);
                SceneManager.LoadScene(2);
                break;
            case 19:
                PlayerPrefs.SetInt("Now", 20);
                SceneManager.LoadScene(2);
                break;
            case 20:
                PlayerPrefs.SetInt("Now", left ? 21 : 16);
                SceneManager.LoadScene(2);
                break;
            case 21:
                PlayerPrefs.SetInt("Now", 15);
                SceneManager.LoadScene(2);
                break;
            case 22:
                PlayerPrefs.SetInt("Now", 23);
                SceneManager.LoadScene(2);
                break;
            case 23:
                PlayerPrefs.SetInt("Now", left ? 24 : 14);
                SceneManager.LoadScene(2);
                break;
            case 24:
                PlayerPrefs.SetInt("Now", left ? 29 : 31);
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + (left ? 1050 : 1020));
                SceneManager.LoadScene(3);
                break;
            case 25:
                PlayerPrefs.SetInt("Now", left ? 26 : 16);
                SceneManager.LoadScene(2);
                break;
            case 26:
                PlayerPrefs.SetInt("Now", 24);
                SceneManager.LoadScene(2);
                break;
            case 27:
                PlayerPrefs.SetInt("Now", left ? 32 : 36);
                SceneManager.LoadScene(3);
                break;
            case 28:
                PlayerPrefs.SetInt("Now", left ? 35 : 33);
                SceneManager.LoadScene(3);
                break;
            case 29:
                PlayerPrefs.SetInt("Now", left ? 32 : 34);
                SceneManager.LoadScene(3);
                break;
            case 30:
                PlayerPrefs.SetInt("Now", left ? 37 : 38);
                SceneManager.LoadScene(3);
                break;
            case 31:
                Debug.Log("31Stageprev : " + PlayerPrefs.GetInt("Stage"));
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 100);
                Debug.Log("31Stageend : " + PlayerPrefs.GetInt("Stage"));
                SceneManager.LoadScene(4);
                break;
            case 32:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 200);
                SceneManager.LoadScene(4);
                break;
            case 33:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 300);
                SceneManager.LoadScene(4);
                break;
            case 34:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 200);
                SceneManager.LoadScene(4);
                break;
            case 35:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 400);
                SceneManager.LoadScene(4);
                break;
            case 36:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 500);
                SceneManager.LoadScene(4);
                break;
            case 37:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 600);
                SceneManager.LoadScene(4);
                break;
            case 38:
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 100);
                SceneManager.LoadScene(4);
                break;
        }
    }
}
