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

    //attacking
    //yAxis = Input.GetAxisRaw("Vertical")
    float attack = 0f;
    float timeBetweenAttack, timeSinceAttack;
    [SerializeField] Transform SideAttackTransform, UpAttackTransform, DownAttackTransform;
    [SerializeField] Vector2 SideAttackArea, UpAttackArea, DownAttackArea;
    [SerializeField] LayerMask attackableLayer;

    //unity stuff
    public static playerScript instance;
    private Rigidbody2D rb;
    private knockBack knockback;

    //gameplay values
    [SerializeField] private float health = 100;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        knockback = GetComponent<knockBack>();
    }

    void Update()
    {

        if (!knockback.IsBeingKnockedBack)
        {
            Move();
            Jump();
        }
        Attack();
    }

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

    public void takeDamage(float dmg, Vector2 direction)
    {
        health -= dmg;
        knockback.CallKnockback(direction, Vector2.one, Input.GetAxisRaw("Horizontal"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(SideAttackTransform.position, SideAttackArea);
        Gizmos.DrawWireCube(UpAttackTransform.position, UpAttackArea);
        Gizmos.DrawWireCube(DownAttackTransform.position, DownAttackArea);
    }

    void Attack()
    {
        timeSinceAttack += Time.deltaTime;
        attack = Input.GetAxis("Fire1");
        if (attack != 0 && timeSinceAttack >= timeBetweenAttack)
        {
            timeSinceAttack = 0;
            
            if (Input.GetAxisRaw("Vertical") == 0 || Input.GetAxisRaw("Vertical") < 0 && Grounded())
            {
                Hit(SideAttackTransform, SideAttackArea);
            }
            else if(Input.GetAxisRaw("Vertical") > 0)
            {
                Hit(UpAttackTransform, UpAttackArea);
            }
            else if (Input.GetAxisRaw("Vertical") < 0 && !Grounded())
            {
                Hit(DownAttackTransform, DownAttackArea);
            }
        }
    }

    private void Hit(Transform _attackTransform, Vector2 _attackArea)
    {
        Collider2D[] objectsToHit = Physics2D.OverlapBoxAll(_attackTransform.position, _attackArea, 0, attackableLayer);
        Debug.Log("ObjectShit");

        if (objectsToHit.Length > 0)
        {
            Debug.Log("Hit");
        }
    }




}
