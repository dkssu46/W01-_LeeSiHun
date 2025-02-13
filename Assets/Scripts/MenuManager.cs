using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    TextMeshProUGUI[] StageText;
    [SerializeField]
    TextMeshProUGUI[] discribe;

    [SerializeField]
    GameObject[] stageCanvas;
    [SerializeField]
    GameObject[] rlArrow;
    [SerializeField]
    GameObject[] endingText;

    int nowStage = 1;
    public int[] endingNumber = new int[3];

    private bool canSpace = true;

    void Start()
    {
        //PlayerPrefs.SetInt("Stage", 1000);
        Application.targetFrameRate = 60; // 60 FPS로 고정
        LoadData();
        SaveData();
        Discription();
        for (int i = 0; i < StageButton.Length; i++)
        {
            int index = i;
            StageButton[index].onClick.AddListener(() => OnButtonClick(index));
            if (nowStage > index)
            {
                StageButton[index].interactable = true;
                StageText[index].color = Color.white;
            }
        }
        Debug.Log(nowStage);
        Debug.Log(PlayerPrefs.GetInt("Stage"));
        Invoke("StartTogglePressKeyUI", 0.5f);
        
    }
    private void Update()
    {
        Debug.Log(nowStage);
        if (Input.anyKeyDown && titleCanvas.activeInHierarchy)
        {
            canSpace = false;
            StartCoroutine(SpaceTerm());
            StopToggling();
            titleCanvas.SetActive(false);
            stageCanvas[nowStage].SetActive(true);
            switch (nowStage)
            {
                case 0:
                    rlArrow[1].SetActive(true);
                    rlArrow[0].SetActive(false);
                    break;
                case 1:
                case 2:
                case 3:
                    rlArrow[0].SetActive(true);
                    rlArrow[1].SetActive(true);
                    break;
                case 4:
                    rlArrow[0].SetActive(true);
                    rlArrow[1].SetActive(false);
                    break;
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && stageCanvas[nowStage + 1] != null)
        {
            ChangeChapter(nowStage, nowStage + 1);
            nowStage++;
            switch (nowStage)
            {
                case 0:
                    rlArrow[1].SetActive(true);
                    rlArrow[0].SetActive(false);
                    break;
                case 1:
                case 2:
                case 3:
                    rlArrow[0].SetActive(true);
                    rlArrow[1].SetActive(true);
                    break;
                case 4:
                    rlArrow[0].SetActive(true);
                    rlArrow[1].SetActive(false);
                    break;
            }
        }
        if( Input.GetKeyDown(KeyCode.LeftArrow) && stageCanvas[nowStage - 1] != null)
        {
            ChangeChapter(nowStage,nowStage - 1);
            nowStage--;
            switch (nowStage)
            {
                case 0:
                    rlArrow[1].SetActive(true);
                    rlArrow[0].SetActive(false);
                    break;
                case 1:
                case 2:
                case 3:
                    rlArrow[0].SetActive(true);
                    rlArrow[1].SetActive(true);
                    break;
                case 4:
                    rlArrow[0].SetActive(true);
                    rlArrow[1].SetActive(false);
                    break;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && StageButton[nowStage-1].interactable && canSpace)
        {
            OnButtonClick(nowStage);
        }
        
    }

    IEnumerator SpaceTerm()
    {
        yield return new WaitForSeconds(1);
        canSpace = true;
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
            stageCanvas[next].GetComponent<RectTransform>().localPosition = new Vector3(1280, 0, 0);
            stageCanvas[next].SetActive(true);
            StartCoroutine(SlideChapter(false, stageCanvas[post], stageCanvas[next]));
        }
        else
        {
            stageCanvas[next].GetComponent<RectTransform>().localPosition = new Vector3(-1280, 0, 0);
            stageCanvas[next].SetActive(true);
            StartCoroutine(SlideChapter(true, stageCanvas[post], stageCanvas[next]));
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

        if (PlayerPrefs.GetInt("End1", 0) == 1) endingText[0].SetActive(true);
        if (PlayerPrefs.GetInt("End2", 0) == 1) endingText[1].SetActive(true);
        if (PlayerPrefs.GetInt("End3", 0) == 1) endingText[2].SetActive(true);
        if (PlayerPrefs.GetInt("End4", 0) == 1) endingText[3].SetActive(true);
        if (PlayerPrefs.GetInt("End5", 0) == 1) endingText[4].SetActive(true);
        if (PlayerPrefs.GetInt("End6", 0) == 1) endingText[5].SetActive(true);

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
        if (code + 1 != PlayerPrefs.GetInt("Stage") / 1000)
        {
            switch (code + 1)
            {
                case 1:
                    PlayerPrefs.SetInt("Stage", 1000);
                    break;
                case 2:
                    PlayerPrefs.SetInt("Stage", (2000 + endingNumber[2]));
                    break;
                case 3:
                    PlayerPrefs.SetInt("Stage", (3000 + endingNumber[1] * 10 + endingNumber[2]));
                    break;
            }
        }
        Debug.Log("PPs: " + PlayerPrefs.GetInt("Stage"));
        switch (PlayerPrefs.GetInt("Stage") / 1000)
        {
            case 1:
                PlayerPrefs.SetInt("Now", 0);
                break;
            case 2:
                switch (endingNumber[2])
                {
                    case 1:
                        PlayerPrefs.SetInt("Now", 10);
                        break;
                    case 2:
                        PlayerPrefs.SetInt("Now", 14);
                        break;
                    case 3:
                        PlayerPrefs.SetInt("Now", 17);
                        break;
                    case 4:
                        PlayerPrefs.SetInt("Now", 20);
                        break;
                    case 5:
                        PlayerPrefs.SetInt("Now", 22);
                        break;
                    case 6:
                        PlayerPrefs.SetInt("Now", 25);
                        break;
                }
                break;
            case 3:
                switch (endingNumber[1])
                {
                    case 1:
                        PlayerPrefs.SetInt("Now", 11);
                        break;
                    case 2:
                        PlayerPrefs.SetInt("Now", 11);
                        break;
                    case 3:
                        PlayerPrefs.SetInt("Now", 15);
                        break;
                    case 4:
                        PlayerPrefs.SetInt("Now", 15);
                        break;
                    case 5:
                        PlayerPrefs.SetInt("Now", 16);
                        break;
                    case 6:
                        PlayerPrefs.SetInt("Now", 16);
                        break;
                    case 7:
                        PlayerPrefs.SetInt("Now", 24);
                        break;
                    case 8:
                        PlayerPrefs.SetInt("Now", 24);
                        break;
                }
                break;
        }
        SceneManager.LoadScene(1);
    }

    void Discription()
    {
        if(PlayerPrefs.GetInt("Stage") / 1000 > 1)
        {
            switch(endingNumber[2])
            {
                case 1:
                    discribe[0].text = "홀로 용을 추격하다.";
                    break;
                case 2:
                    discribe[0].text = "용을 잡을 파티를 찾다.";
                    break;
                case 3:
                    discribe[0].text = "동료와 주변을 살피다.";
                    break;
                case 4:
                    discribe[0].text = "동료와 마을로 돌아가다.";
                    break;
                case 5:
                    discribe[0].text = "홀로 용을 추격하다.";
                    break;
                case 6:
                    discribe[0].text = "홀로 마을로 돌아가다.";
                    break;
            }
        }
        if(PlayerPrefs.GetInt("Stage") / 1000 == 3)
        {
            switch(endingNumber[1])
            {
                case 1:
                    discribe[1].text = "빠르게 용 앞에 서다.";
                    break;
                case 2:
                    discribe[1].text = "빠르게 용 앞에 서다.";
                    break;
                case 3:
                    discribe[1].text = "동료와 용 앞에 서다.";
                    break;
                case 4:
                    discribe[1].text = "동료와 용 앞에 서다.";
                    break;
                case 5:
                    discribe[1].text = "다같이 용 앞에 서다.";
                    break;
                case 6:
                    discribe[1].text = "다같이 용 앞에 서다.";
                    break;
                case 7:
                    discribe[1].text = "홀로 용 앞에 서다.";
                    break;
                case 8:
                    discribe[1].text = "홀로 용 앞에 서다.";
                    break;
            }

            switch(endingNumber[0])
            {
                case 1:
                    discribe[2].text = "꼬리에 맞아 사망하다.";
                    break;
                case 2:
                    discribe[2].text = "화난 용에게 사망하다.";
                    break;
                case 3:
                    discribe[2].text = "영웅의 들러리가 되다.";
                    break;
                case 4:
                    discribe[2].text = "막타충 영웅이 되다.";
                    break;
                case 5:
                    discribe[2].text = "가장 빠른 용사가 되다.";
                    break;
                case 6:
                    discribe[2].text = "무용담만이 전설로 남다.";
                    break;
            }
        }
    }
}
