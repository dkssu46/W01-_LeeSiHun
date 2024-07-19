using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerAnimation pa;
    Rigidbody2D rb;
    [SerializeField]
    PlayerFeet pf;
    [SerializeField]
    PlayerCollider[] pc;
    [SerializeField]
    GameManager gm;
    [SerializeField]
    GameObject map;
    [SerializeField]
    GameObject clockUI;

    public float jumpPower = 5.0f;
    public float moveSpeed = 5.0f;
    public float rotationDuration = 1f; // 회전에 걸리는 시간 (초)
    public float rotationAngle = 90f;

    private bool isRotating = false;
    private bool isSit = false;
    private bool isStop = false;
    private Vector3 postForce = Vector3.zero;

    void Start()
    {
        pa = GetComponent<PlayerAnimation>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (pf.isGround && rb.velocity != Vector2.zero)
        {
            pa.Walk(true);
        }
        else
        {
            pa.Walk(false);
        }
        Jump();
        MapRotate();
        TimeStop();
        Crawl();
        
    }


    // Update Function
    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveX * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pf.isGround && !isSit && !isStop)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            pf.isGround = false;
        }
    }
    private void MapRotate()
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
        float startRotation = map.transform.eulerAngles.z; // 현재 회전 각도
        float endRotation = startRotation + angle;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration);
            map.transform.rotation = Quaternion.Euler(0, 0, zRotation);
            yield return null;
        }
        map.transform.rotation = Quaternion.Euler(0, 0, endRotation);
        isRotating = false;
    }
    private void TimeStop()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isStop)
            {
                isStop = false;
                clockUI.SetActive(false);
                rb.gravityScale = 1;
                rb.velocity = postForce;
            }
            else
            {
                isStop = true;
                clockUI.SetActive(true);
                postForce = rb.velocity;
                rb.velocity = Vector2.zero;
                rb.totalForce = Vector2.zero;
                rb.gravityScale = 0;
            }
        }
    }
    private void Crawl()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isSit = true;
        }
        else
        {
            isSit = false;
        }
        if (!isStop) pa.Sit(isSit);
    }
    //end
}