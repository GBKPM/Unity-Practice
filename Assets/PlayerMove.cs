using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool jumping = false;

    Rigidbody2D _rigidbody;
    SpriteRenderer spriteRenderer;


    private void Awake()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        float moveDis = moveSpeed * Time.deltaTime;
        Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (Input.GetKey(KeyCode.W))
        {
            if (!jumping)
            {
                jumping = true;

                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce);
            }
        }
        transform.position += inputDir * moveDis;
        spriteRenderer.flipX = inputDir.y == 1;
    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.down, 1, LayerMask.GetMask("Floor"));
        if (rayHit.collider != null)
        {
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(this.gameObject);
        }
    }
}
