using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance = null;
    [SerializeField]
    AudioClip[] musicClip;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ������Ʈ�� �� ��ȯ �ÿ��� �ı����� �ʵ��� ����
            audioSource = GetComponent<AudioSource>();
        }
        else if (instance != this)
        {
            Destroy(gameObject);  // �ߺ��� ������Ʈ�� �ı�
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name.Equals("1_GameStage"))
        {
            switch (PlayerPrefs.GetInt("Now"))
            {
                case 11:
                case 15:
                case 16:
                case 24:
                case 27:
                case 28:
                case 29:
                case 30:
                    ChangeBGM(1);
                    break;
                default:
                    ChangeBGM(0);
                    break;
            }
        }
        else
        {
            ChangeBGM(0);
        }
    }

    void ChangeBGM(int bg)
    {
        if(audioSource.clip != musicClip[bg])
        {
            audioSource.clip = musicClip[bg];
            audioSource.Play();
        }
    }
}