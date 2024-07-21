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
            StartCoroutine(TriggerCooldown());  // Ʈ���� ��Ȱ��ȭ �ڷ�ƾ ����
        }
    }

    private IEnumerator TriggerCooldown()
    {
        canTrigger = false;  // Ʈ���� ��Ȱ��ȭ
        yield return new WaitForSeconds(1.0f);  // ������ �ð� ���� ���
        canTrigger = true;  // Ʈ���� ��Ȱ��ȭ
    }
}
