using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject playerStand;
    [SerializeField]
    GameObject playerSit;
    [SerializeField]
    GameObject eyeRight;
    [SerializeField]
    GameObject eyeLeft;

    private Coroutine walkCoroutine;

    private void Start()
    {
        Invoke("Wink", 1);
    }

    private void Clear()
    {
        eyeRight.SetActive(true);
        
    }

    public void Wink()
    {
        eyeRight.SetActive(false);
        Invoke("Clear", 0.3f);
        
    }

    public void Walk(bool isWalk)
    {
        if (isWalk)
        {
            if (walkCoroutine == null)
            {
                walkCoroutine = StartCoroutine(WalkCo());
            }
        }
        else
        {
            if (walkCoroutine != null)
            {
                StopCoroutine(walkCoroutine);
                playerStand.transform.localPosition = Vector3.zero;
                walkCoroutine = null;
            }
        }
    }

    IEnumerator WalkCo()
    {
        while (true)
        {
            playerStand.transform.localPosition = Vector3.up / 4;
            yield return new WaitForSeconds(0.1f);
            playerStand.transform.localPosition = Vector3.zero;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Sit(bool isSit)
    {
        playerStand.SetActive(!isSit);
        playerSit.SetActive(isSit);
    }
}
