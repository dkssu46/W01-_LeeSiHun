using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI content;

    private void Start()
    {
        switch(PlayerPrefs.GetInt("Now"))
        {
            case 31:
                content.text = "당신은 꼬리에 맞아 사망한 이름없는 모험가 1이 되었습니다...";
                break;
            case 32:
                content.text = "당신은 화난 용에게 사망한 이름없는 모험가 1이 되었습니다...";
                break;
            case 33:
                content.text = "당신의 동료는 영웅이 되었고, 당신은 들러리가 되었습니다...";
                break;
            case 34:
                content.text = "당신은 화난 용에게 사망한 이름없는 모험가 1이 되었습니다...";
                break;
            case 35:
                content.text = "당신은 영웅이 되었습니다! 사람들이 막타충이라 불러도 괜찮죠! 당신은 영웅이니까!";
                break;
            case 36:
                content.text = "당신은 드래곤이 잠든 사이에 처치한 <가장 빠른 용사>로 불리게 되었습니다.";
                break;
            case 37:
                content.text = "당신은 용과 함께 쓰러졌습니다. 사람들은 당신을 전설로 기억할 것입니다...";
                break;
            case 38:
                content.text = "당신은 꼬리에 맞아 사망한 이름없는 모험가 1이 되었습니다...";
                break;
        }
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
