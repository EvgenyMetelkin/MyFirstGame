using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float horizontalSpeed;
    public float jumpHeight;
    Animator animator;
    Transform cameraTransform;
    public int magicCameraHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cameraTransform = GameObject.Find("Camera").GetComponent<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        CheckDead();
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
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontalSpeed = Input.acceleration.x;
        } 
        else
        {
            horizontalSpeed = Input.GetAxis("Horizontal");
        }
        rb.velocity = new UnityEngine.Vector2(horizontalSpeed * speed, rb.velocity.y);
    }

    void Flip()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.acceleration.x > 0)
                transform.localRotation = UnityEngine.Quaternion.Euler(0, 0, 0);
            else if (Input.acceleration.x < 0)
                transform.localRotation = UnityEngine.Quaternion.Euler(0, 180, 0);
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0)
                transform.localRotation = UnityEngine.Quaternion.Euler(0, 0, 0);
            else if (Input.GetAxis("Horizontal") < 0)
                transform.localRotation = UnityEngine.Quaternion.Euler(0, 180, 0);
        }
    }
     
    void Jump()
    { 
        rb.velocity = UnityEngine.Vector2.zero;
        rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        // без этого смотриться лучше animator.SetInteger("State", 1);
    }

    void CheckDead()
    {
        if (cameraTransform.position.y - transform.position.y > magicCameraHeight)
        {
            RestartGame();
        }
    }
    void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
