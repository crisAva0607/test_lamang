using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeepneyControl : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    isGrounded = true;
    }


    void Update()
    {
    float horizontalInput = Input.GetAxis("Horizontal");
    rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        rb.velocity = Vector2.up * jumpForce;
        isGrounded = false;
    }
    }

    void Flip()
    {
    transform.Rotate(0f, 180f, 0f);
    }

    void FixedUpdate()
    {
    float horizontalVelocity = rb.velocity.x;
    horizontalVelocity *= 0.75f;
    rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);

    if (horizontalVelocity > 0.1f)
    {
        transform.localScale = new Vector3(0.1583532f, 0.1583532f);
    }
    else if (horizontalVelocity < -0.1f)
    {
        transform.localScale = new Vector3(-0.1583532f, 0.1583532f);
    }
    }


}
