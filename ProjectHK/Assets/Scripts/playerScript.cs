using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float jumpForce = 1;

    private Vector2 amountToMove;

    private Rigidbody2D rb;

    public float m_thrust = 1f;

    //Methods
    public void Move(Vector2 moveAmount)
    {

    }




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //horizontal move
        Console.WriteLine(Input.GetAxis("Horizontal"));
        rb.velocity = new Vector2(speed*Input.GetAxis("Horizontal"),rb.velocity.y);
        if (Input.GetAxis("Jump") > 0)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);




    }
}
