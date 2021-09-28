using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public int nextMove;
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
        _rigidbody.velocity = new Vector3(nextMove, _rigidbody.velocity.y);
    }

    void NextAction()
    {
        nextMove = Random.Range(-1, 2);
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;

        float nextMoveTime = Random.Range(2f, 5f);
        Invoke("NextAction", nextMoveTime);

    }
}
