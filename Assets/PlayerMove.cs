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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Issue:
        //어떤 물체건 일단 충돌하면 점프 중 여부가 변화하는 문제점 존재.
        //예: 독수리와 닿으면 다시 점프가 가능함.
        //TODO:
        //밟을 땅 등을 분리할 Layer를 새로 생성하여, 땅을 밟았을 떄만.
        //점프 중 여부를 나타내는 변수를 변화시킬것,
        jumping = false;
    }
}
