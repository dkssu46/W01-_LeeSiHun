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
                content.text = "����� ������ �¾� ����� �̸����� ���谡 1�� �Ǿ����ϴ�...";
                break;
            case 32:
                content.text = "����� ȭ�� �뿡�� ����� �̸����� ���谡 1�� �Ǿ����ϴ�...";
                break;
            case 33:
                content.text = "����� ����� ������ �Ǿ���, ����� �鷯���� �Ǿ����ϴ�...";
                break;
            case 34:
                content.text = "����� ȭ�� �뿡�� ����� �̸����� ���谡 1�� �Ǿ����ϴ�...";
                break;
            case 35:
                content.text = "����� ������ �Ǿ����ϴ�! ������� ��Ÿ���̶� �ҷ��� ������! ����� �����̴ϱ�!";
                break;
            case 36:
                content.text = "����� �巡���� ��� ���̿� óġ�� <���� ���� ���>�� �Ҹ��� �Ǿ����ϴ�.";
                break;
            case 37:
                content.text = "����� ��� �Բ� ���������ϴ�. ������� ����� ������ ����� ���Դϴ�...";
                break;
            case 38:
                content.text = "����� ������ �¾� ����� �̸����� ���谡 1�� �Ǿ����ϴ�...";
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
