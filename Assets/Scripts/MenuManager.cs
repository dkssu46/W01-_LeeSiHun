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

    int nowStage = 1;
    public int[] endingNumber = new int[3];

    private bool canSpace = true;

    void Start()
    {
        //PlayerPrefs.SetInt("Stage", 1000);
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
        if (Input.anyKeyDown && titleCanvas.activeInHierarchy)
        {
            canSpace = false;
            StartCoroutine(SpaceTerm());
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
        if(Input.GetKeyDown(KeyCode.Space) && StageButton[nowStage-1].interactable && canSpace)
        {
            OnButtonClick(nowStage-1);
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
                switch (PlayerPrefs.GetInt("Stage") % 10)
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
                switch (PlayerPrefs.GetInt("Stage") / 10)
                {
                    case 301:
                        PlayerPrefs.SetInt("Now", 27);
                        break;
                    case 302:
                        PlayerPrefs.SetInt("Now", 31);
                        break;

                    case 303:
                        PlayerPrefs.SetInt("Now", 28);
                        break;
                    case 304:
                        PlayerPrefs.SetInt("Now", 30);
                        break;
                    case 305:
                        PlayerPrefs.SetInt("Now", 29);
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
                    discribe[1].text = "홀로 용 꼬리에 서다.";
                    break;
                case 3:
                    discribe[1].text = "동료와 용 앞에 서다.";
                    break;
                case 4:
                    discribe[1].text = "동료와 용 꼬리에 서다.";
                    break;
                case 5:
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
