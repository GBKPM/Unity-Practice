using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float fspeed;
    public float fJumpForce;
    public bool bJump = false;
    void Start()
    {
        
    }

    void Update()
    {
        float fMoveDist = fspeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            if (!bJump)
            {
                bJump = true;
                Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
                rigidbody2D.AddForce(Vector3.up * fJumpForce);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * fMoveDist;
            Debug.Log("Dynamic.GetKey(RightArrow)");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.position += Vector3.left * fMoveDist;
            Debug.Log("Dynamic.GetKey(RightArrow)");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position += Vector3.right * fMoveDist;
            Debug.Log("Dynamic.GetKey(RightArrow)");
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bJump = false;
    }
}
