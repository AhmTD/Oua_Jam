using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public static bool isMove = true;
    Animator playerAnimator;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        isMove = true;
    }

    private void Update()
    {
        if (isMove == true)
        {
            Movement();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("halfFinish"))
        {
            isMove = false;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {

            isMove = false;
        }
    }
    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        playerAnimator.SetFloat("Speed",Mathf.Abs(horizontalInput));
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            playerAnimator.SetBool("Jump", true);
            isGrounded = false;
        }
        if(playerAnimator.GetBool("Jump")&&isGrounded)
        {
            playerAnimator.SetBool("Jump",false);
        }
    }
}
