using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerAnimation pm;
    Rigidbody2D rb;
    [SerializeField]
    PlayerFeet pf;

    public float jumpPower = 5.0f;
    public float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerAnimation>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            pm.Walk();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            pm.Walk();
        }
        if (Input.GetKeyDown(KeyCode.Space) && pf.isGround)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); //위쪽으로 힘을 준다.
            pf.isGround = false;
        }
    }
}
