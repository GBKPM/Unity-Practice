using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed;

    //의미를 파악하기 힘든 변수명. 수정 바람.
    public int nextMove;

    Rigidbody2D _rigidbody;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Awake에서 해당 액션을 실행하는건 바람직하지 않음. 수정 바람.
        NextAction();

        Invoke("NextAction", 2);
        //---------------------------------------------
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(nextMove, 0, 0) * Time.fixedDeltaTime;
        //낙하 검사
        Debug.DrawRay(transform.position, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.down, 1, LayerMask.GetMask("Floor"));

        //ray.Hit.collider가 null인 경우가 무엇을 의미하는지 주석 등으로 설명할 필요 있음.
        if (rayHit.collider == null)
        {
            OutCheck();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //박스에 부딪치면 방향전환
        if (collision.gameObject.CompareTag("Box"))
        {
            OutCheck();
        }
    }


    //실행하는 동작의 의미를 파악하기 힘든 함수명. 수정 바람.
    void OutCheck()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
        
        
        CancelInvoke();
        //인게임 런타임 중 Invoke를 사용하는건 좋지 않음. 수정 바람.
        //매직넘버 사용됨. 변수 등으로 교체하는걸 권장함.
        Invoke("NextAction", 2);
    }

    void NextAction()
    {
        nextMove = Random.Range(-1, 2);
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;

        //인게임 런타임 중 Invoke를 사용하는건 좋지 않음. 수정 바람.
        //매직넘버 사용됨. 변수 등으로 교체하는걸 권장함.
        Invoke("NextAction", Random.Range(2f, 5f));
    }
}
