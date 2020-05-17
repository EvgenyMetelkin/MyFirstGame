using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpHeight;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip(); 
    }

    void FixedUpdate()
    {
        Move();
    }

    /////////////////////////////////////// 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Jump();
        }
    }
    void Move()
    {
        rb.velocity = new UnityEngine.Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = UnityEngine.Quaternion.Euler(0, 0, 0);
        else if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = UnityEngine.Quaternion.Euler(0, 180, 0);
    }
     
    void Jump()
    {
        rb.velocity = UnityEngine.Vector2.zero;
        rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        // без этого смотриться лучше animator.SetInteger("State", 1);
    }
}
