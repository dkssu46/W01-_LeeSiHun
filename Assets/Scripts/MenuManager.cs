using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject titleCanvas;
    [SerializeField]
    GameObject pressKeyUI;
    [SerializeField]
    Button[] StageButton;

    [SerializeField]
    GameObject[] stageCanvas;

    int nowStage = 1;
    int[] endingNumber = new int[3];

    void Start()
    {
        LoadData();
        for (int i = 0; i < StageButton.Length; i++)
        {
            StageButton[i].onClick.AddListener(() => OnButtonClick(i));
            if(nowStage > i) StageButton[i].interactable = true;
        }
        Invoke("StartTogglePressKeyUI", 1.0f);
        
    }
    private void Update()
    {
        if (Input.anyKeyDown && titleCanvas.activeInHierarchy)
        {
            StopToggling();
            titleCanvas.SetActive(false);
            stageCanvas[nowStage-1].SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && stageCanvas[nowStage] != null)
        {
            ChangeChapter(nowStage, nowStage + 1);
            nowStage++;
        }
        if( Input.GetKeyDown(KeyCode.LeftArrow) && stageCanvas[nowStage - 2] != null)
        {
            ChangeChapter(nowStage,nowStage - 1);
            nowStage--;
        }
    }

    // make PressKeyUI Toggling
    void StartTogglePressKeyUI()
    {
        StartCoroutine(TogglePressKeyUI());
    }
    IEnumerator TogglePressKeyUI()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            pressKeyUI.SetActive(!pressKeyUI.activeInHierarchy);
        }
    }
    void StopToggling()
    {
        StopCoroutine(TogglePressKeyUI());
        CancelInvoke("StartTogglePressKeyUI");
    }
    // End

    //Slide to Change Chapter
    void ChangeChapter(int post, int next)
    {
        if(post < next)
        {
            stageCanvas[next - 1].GetComponent<RectTransform>().localPosition = new Vector3(1280, 0, 0);
            stageCanvas[next - 1].SetActive(true);
            StartCoroutine(SlideChapter(false, stageCanvas[post - 1], stageCanvas[next - 1]));
        }
        else
        {
            stageCanvas[next - 1].GetComponent<RectTransform>().localPosition = new Vector3(-1280, 0, 0);
            stageCanvas[next - 1].SetActive(true);
            StartCoroutine(SlideChapter(true, stageCanvas[post - 1], stageCanvas[next - 1]));
        }
        
        
    }
    IEnumerator SlideChapter(bool isRight, GameObject post, GameObject next)
    {
        float startTime = Time.time;
        float duration = 1.0f;
        Vector3 left = new Vector3(-1280, 0, 0);
        Vector3 right = new Vector3(1280, 0, 0);        

        while(Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            if (isRight)
            {
                post.GetComponent<RectTransform>().localPosition = Vector3.Lerp(Vector3.zero,right,t);
                next.GetComponent<RectTransform>().localPosition = Vector3.Lerp(left, Vector3.zero, t);
            }
            else
            {
                post.GetComponent<RectTransform>().localPosition = Vector3.Lerp(Vector3.zero, left, t);
                next.GetComponent<RectTransform>().localPosition = Vector3.Lerp(right, Vector3.zero, t);
            }
            yield return null;
        }
        if (isRight)
        {
            post.GetComponent<RectTransform>().localPosition = right;
            next.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
        else
        {
            post.GetComponent<RectTransform>().localPosition = left;
            next.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
        post.SetActive(false);
    }
    //end

    //Stage Save
    public void LoadData()
    {
        nowStage = PlayerPrefs.GetInt("Stage", 1000) / 1000;
        endingNumber[0] = (PlayerPrefs.GetInt("Stage") % 1000) / 100;
        endingNumber[1] = (PlayerPrefs.GetInt("Stage") % 100) / 10;
        endingNumber[2] = PlayerPrefs.GetInt("Stage") % 10;
    }

    public void SaveData()
    {
        int code = 0;
        if (PlayerPrefs.GetInt("Stage") % 10 != 0) code = 3000;
        else if (PlayerPrefs.GetInt("Stage") % 100 != 0) code = 2000;
        else code = 1000;

        code += endingNumber[2];
        code += endingNumber[1] * 10;
        code += endingNumber[0] * 100;

        PlayerPrefs.SetInt("Stage", code);
    }
    //end

    //Button Click
    public void OnButtonClick(int code)
    {
        SceneManager.LoadScene(code + 1);
    }
}
