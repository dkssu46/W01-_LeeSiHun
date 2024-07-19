using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public float rotationDuration = 1f; // 회전에 걸리는 시간 (초)
    public float rotationAngle = 90f;
    private bool isRotating = false;

    private TileLoader tl;

    void Start()
    {
        tl = GetComponent<TileLoader>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            StartCoroutine(RotateOverTime(rotationAngle, rotationDuration));
        }
        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            StartCoroutine(RotateOverTime(-rotationAngle, rotationDuration));
        }
    }
    private IEnumerator RotateOverTime(float angle, float duration)
    {
        isRotating = true;
        float startRotation = transform.eulerAngles.z; // 현재 회전 각도
        float endRotation = startRotation + angle;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration);
            transform.rotation = Quaternion.Euler(0, 0, zRotation);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, 0, endRotation);
        isRotating = false;
    }

    //Map Tile Clear
    public void ClearTile()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    //end
}
