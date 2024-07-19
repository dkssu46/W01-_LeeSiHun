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
    GameObject clockUI;

    public float jumpPower = 5.0f;
    public float moveSpeed = 5.0f;

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
        if (Input.GetKey(KeyCode.RightArrow) && !isStop)
        {
            if(isSit) transform.Translate(Vector3.right * Time.deltaTime * moveSpeed/2);
            else transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            pa.Walk(true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !isStop)
        {
            if (isSit) transform.Translate(Vector3.left * Time.deltaTime * moveSpeed / 2);
            else transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            pa.Walk(true);
        }
        else
        {
            pa.Walk(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && pf.isGround && !isSit && !isStop)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            pf.isGround = false;
        }

        
        if (Input.GetKey(KeyCode.DownArrow)) {
            isSit = true;
        }
        else
        {
            isSit = false;
        }
        if (!isStop) pa.Sit(isSit);

        if (Input.GetKeyDown(KeyCode.S))
        {
            if(isStop)
            {
                isStop = false;
                clockUI.SetActive(false);
                rb.gravityScale = 1;
                rb.velocity = postForce;
            }
            else
            {
                isStop=true;
                clockUI.SetActive(true);
                postForce = rb.velocity;
                rb.velocity = Vector2.zero;
                rb.totalForce = Vector2.zero;
                rb.gravityScale = 0;
            }
        }

    }
}
