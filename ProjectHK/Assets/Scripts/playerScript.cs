using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float speed = 0;

    private Vector2 amountToMove;

    public Rigidbody2D rb;

    public float m_thrust = 1f;

    //Methods
    public void Move(Vector2 moveAmount)
    {

        float deltaY = moveAmount.y;

        transform.Translate(moveAmount);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = 0;
        if (Input.GetKey(KeyCode.A))
        {
            speed = -5;
            rb.AddForce((transform.right * speed) * -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            speed = 5;
            rb.AddForce(transform.right * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(transform.up * m_thrust);

        amountToMove = new Vector2(speed, 0);
        Move(amountToMove * Time.deltaTime);


    }
}
