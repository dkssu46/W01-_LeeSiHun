using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject playerModel;
    [SerializeField]
    GameObject eyeRight;
    [SerializeField]
    GameObject eyeLeft;

    private void Start()
    {
        Invoke("Wink", 1);
        Walk();
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

    public void Walk()
    {
        StartCoroutine(WalkCo());
    }

    IEnumerator WalkCo()
    {
            playerModel.transform.localPosition = Vector3.up / 2;
            yield return new WaitForSeconds(0.05f);
            playerModel.transform.localPosition = Vector3.zero;
            yield return new WaitForSeconds(0.05f);
    }
}
