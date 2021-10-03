using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed;

    //�ǹ̸� �ľ��ϱ� ���� ������. ���� �ٶ�.
    public int nextMove;

    Rigidbody2D _rigidbody;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Awake���� �ش� �׼��� �����ϴ°� �ٶ������� ����. ���� �ٶ�.
        NextAction();

        Invoke("NextAction", 2);
        //---------------------------------------------
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(nextMove, 0, 0) * Time.fixedDeltaTime;
        //���� �˻�
        Debug.DrawRay(transform.position, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.down, 1, LayerMask.GetMask("Floor"));

        //ray.Hit.collider�� null�� ��찡 ������ �ǹ��ϴ��� �ּ� ������ ������ �ʿ� ����.
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


    //�����ϴ� ������ �ǹ̸� �ľ��ϱ� ���� �Լ���. ���� �ٶ�.
    void OutCheck()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
        
        
        CancelInvoke();
        //�ΰ��� ��Ÿ�� �� Invoke�� ����ϴ°� ���� ����. ���� �ٶ�.
        //�����ѹ� ����. ���� ������ ��ü�ϴ°� ������.
        Invoke("NextAction", 2);
    }

    void NextAction()
    {
        nextMove = Random.Range(-1, 2);
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;

        //�ΰ��� ��Ÿ�� �� Invoke�� ����ϴ°� ���� ����. ���� �ٶ�.
        //�����ѹ� ����. ���� ������ ��ü�ϴ°� ������.
        Invoke("NextAction", Random.Range(2f, 5f));
    }
}
