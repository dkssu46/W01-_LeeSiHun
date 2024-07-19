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
    GameObject playerWalk;
    [SerializeField]
    GameObject eyeRight;
    [SerializeField]
    GameObject eyeLeft;

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

    public void move(bool isWalk, bool isSit)
    {
        if (isSit && isWalk)
        {
            playerSit.SetActive(true);
            playerStand.SetActive(false);
            playerWalk.SetActive(false);
        }
        if(isSit && !isWalk)
        {
            playerSit.SetActive(true);
            playerStand.SetActive(false);
            playerWalk.SetActive(false);
        }
        if(!isSit && isWalk)
        {
            playerSit.SetActive(false);
            playerStand.SetActive(false);
            playerWalk.SetActive(true);
        }
        if (!isSit && !isWalk)
        {
            playerSit.SetActive(false);
            playerStand.SetActive(true);
            playerWalk.SetActive(false);
        }
   
    }
}
