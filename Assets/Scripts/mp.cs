using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mp : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(RotateOverTime());
        }
    }

    private IEnumerator RotateOverTime()
    {
        float startRotation = transform.eulerAngles.z; // 현재 회전 각도
        float endRotation = startRotation + 90;
        float t = 0f;

        while (t < 0.5f)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation, t / 0.5f);
            transform.rotation = Quaternion.Euler(0, 0, zRotation);
            yield return null;
        }
        // 정확한 회전 각도 설정
        transform.rotation = Quaternion.Euler(0, 0, endRotation);
    }
}
