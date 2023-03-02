using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    public float jumpforce;
    private bool isJumping;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;

    public float checkradius;
    private bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        //finds RigidBody
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        processinputs();

        animate();

    }
    //Update is called multiple times per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkradius, groundObjects);
        move();
        
    }
    
    //Finds Input
    private void processinputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    private void animate()
        {
            if (moveDirection > 0 && !facingRight)
            {
                //turn
            FlipCharacter();
            }
                else if (moveDirection < 0 && facingRight)
            {
                FlipCharacter();
            }
            
        }
        //movement
            private void move()
            {
                rb.velocity = new Vector2(moveDirection * movespeed, rb.velocity.y);
                if (isJumping)
                {
                    rb.AddForce(new Vector2(0f,jumpforce));
                }
                isJumping = false;
            }
            

    //turn
    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }

}
