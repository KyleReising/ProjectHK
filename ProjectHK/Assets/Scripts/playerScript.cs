using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    //health
    [SerializeField] private float speed = 1;
    [SerializeField] private float jumpForce = 1;

    //jumping
    [SerializeField] private Transform groundTransform;
    [SerializeField] float groundCheckY = 0.2f;         //How far on the Y axis the groundcheck Raycast goes.
    [SerializeField] float groundCheckX = 1;            //Same as above but for X.
    [SerializeField] LayerMask groundLayer;

    //unity stuff
    public static playerScript instance;
    private Rigidbody2D rb;

    //gameplay values
    [SerializeField] private float health = 100;



    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    //Methods
    public bool Grounded()
    {
        //this does three small raycasts at the specified positions to see if the player is grounded.
        if (Physics2D.Raycast(groundTransform.position, Vector2.down, groundCheckY, groundLayer) || Physics2D.Raycast(groundTransform.position + new Vector3(-groundCheckX, 0), Vector2.down, groundCheckY, groundLayer) || Physics2D.Raycast(groundTransform.position + new Vector3(groundCheckX, 0), Vector2.down, groundCheckY, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Move()
    {
        rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
    }
    public void Jump()
    {
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (Input.GetAxis("Jump") > 0 && Grounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
            
    }

    public void takeDamage(float dmg)
    {
        health -= dmg;
    }




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
 
    }
}
