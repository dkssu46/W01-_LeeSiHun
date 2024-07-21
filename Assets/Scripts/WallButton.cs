using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    GameObject[] onOffWall;
    private bool canTrigger = true;

    public static GameObject[] FindObjectsWithTag(string tag)
    {
        List<GameObject> objectsWithTag = new List<GameObject>();
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag(tag))
            {
                objectsWithTag.Add(obj);
            }
        }

        return objectsWithTag.ToArray();
    }

    void Start()
    {
        onOffWall = FindObjectsWithTag("OnOffWall");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTrigger && (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Dust")))
        {
            foreach (GameObject obj in onOffWall)
            {
                obj.SetActive(!obj.activeInHierarchy);
            }
            StartCoroutine(TriggerCooldown());  // 트리거 비활성화 코루틴 시작
        }
    }

    private IEnumerator TriggerCooldown()
    {
        canTrigger = false;  // 트리거 비활성화
        yield return new WaitForSeconds(1.0f);  // 지정된 시간 동안 대기
        canTrigger = true;  // 트리거 재활성화
    }
}
