using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject titleCanvas;
    [SerializeField]
    GameObject pressKeyUI;

    [SerializeField]
    GameObject[] stageCanvas;

    void Start()
    {
        Invoke("StartTogglePressKeyUI", 1.4f);
    }
    private void Update()
    {
        if (Input.anyKeyDown || titleCanvas.activeInHierarchy)
        {
            StopToggling();
            titleCanvas.SetActive(false);
            stageCanvas[0].SetActive(true);
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
            yield return new WaitForSeconds(0.7f);
            pressKeyUI.SetActive(!pressKeyUI.activeInHierarchy);
        }
    }
    void StopToggling()
    {
        StopCoroutine(TogglePressKeyUI());
        CancelInvoke("StartTogglePressKeyUI");
    }
    // End

    
}
