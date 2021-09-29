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
        //� ��ü�� �ϴ� �浹�ϸ� ���� �� ���ΰ� ��ȭ�ϴ� ������ ����.
        //��: �������� ������ �ٽ� ������ ������.
        //TODO:
        //���� �� ���� �и��� Layer�� ���� �����Ͽ�, ���� ����� ����.
        //���� �� ���θ� ��Ÿ���� ������ ��ȭ��ų��,
        jumping = false;
    }
}
