using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed;
    public int nextMove;

    Rigidbody2D _rigidbody;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        NextAction();

        Invoke("NextAction", 2);
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(nextMove, 0, 0) * Time.fixedDeltaTime;
        //���� �˻�
        Debug.DrawRay(transform.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.down, 1, LayerMask.GetMask("Floor"));
        if (rayHit.collider == null)
        {
            OutCheck();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //�ڽ��� �ε�ġ�� ������ȯ
        if (collision.gameObject.CompareTag("Box"))
        {
            OutCheck();
        }
    }

    void OutCheck()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
        
        CancelInvoke();
        Invoke("NextAction", 2);
    }

    void NextAction()
    {
        nextMove = Random.Range(-1, 2);
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;
        Invoke("NextAction", Random.Range(2f, 5f));
    }
}
