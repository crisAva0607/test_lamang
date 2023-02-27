using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animate;

    //playerControsl
    public float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    //Win Condition
    public TMP_Text WINTEXT;
    
    //Powerups
    private float boostTimer;
    private bool boosting;
    
    //Jeepney Checker and Controls
    public Rigidbody2D vehicleRigidbody;
    private bool isRiding = false;
    public Transform exitPoint;
  

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animate = gameObject.GetComponent<Animator>();

        moveSpeed = 1.5f;
        jumpForce = 15f;
        isJumping = false;

        boostTimer = 0;
        boosting = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        animate.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        
        if (isRiding)
        {
            // Handle player input to control the vehicle
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Apply forces to the vehicle's Rigidbody2D component to move it
            Vector2 movement = new Vector2(horizontalInput, 0);
            vehicleRigidbody.AddForce(movement * 10f);
            
            // Check if the player presses a button to exit the vehicle
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Disable the vehicle's Rigidbody2D component and enable the player's Rigidbody2D component
                rb2D.simulated = true;
                vehicleRigidbody.simulated = false;

                // Set the player's position to the exit point of the vehicle
                transform.position = exitPoint.position;

                // Remove the player as a child of the vehicle
                transform.SetParent(null);

                isRiding = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
        else if (moveHorizontal < -0f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            transform.localScale = new Vector2(-0.5f, 0.5f);
        }

        if (!isJumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }

        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 2)
            {
                moveSpeed = 1.5f;
                boostTimer = 0;
                boosting = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            isJumping = false;
        }

        if (other.gameObject.tag == "Win")
        {
            WINTEXT.gameObject.SetActive(true);
            Time.timeScale = 0; //Para magpause lahat sa game
        }

        if (other.gameObject.tag == "coffee")
        {
            //Debug.Log("working");
            boosting = true;
            moveSpeed = 5f;
            Destroy(other.gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Jeep")
        {
            // Disable the player's Rigidbody2D component and enable the vehicle's Rigidbody2D component
            rb2D.simulated = false;
            vehicleRigidbody.simulated = true;

            // Set the player as a child of the vehicle to move with it
            transform.SetParent(vehicleRigidbody.transform);
            isRiding = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }

 

    }

}
