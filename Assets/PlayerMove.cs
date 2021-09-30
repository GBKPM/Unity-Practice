using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Adjustments")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;

    [Header("Debug")]
    [SerializeField]
    private bool jumping = false;



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
        
        Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (Input.GetAxisRaw("Jump") == 1)
        {
            if (!jumping)
            {
                jumping = true;

                _rigidbody.AddForce(Vector3.up * jumpForce);
            }
        }

        float moveDis = moveSpeed * Time.deltaTime;
        transform.position += inputDir * moveDis;
        spriteRenderer.flipX = inputDir.y == 1;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //바닥에 닿을때만 점프가 가능하도록
        if(collision.gameObject.CompareTag("Floor"))
        {
            jumping = false;
        }
    }
}
