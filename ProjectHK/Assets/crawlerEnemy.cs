using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TO USE CRAWLER ENEMY
// 1. MAKE CRAWLERS HITBOX TRIGGER
// 2. SET GROUND TAG ON THE FLOOR

public class crawlerEnemy : enemyParent
{
    Rigidbody2D rigidbody2;
    BoxCollider2D boxCollider2;
    
    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        boxCollider2 = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (facingRight() )
        {
            rigidbody2.velocity = new Vector2(speed,0);
        }
        else
        {
            rigidbody2.velocity = new Vector2(-speed, 0);
        }
    }

    private bool facingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "ground")
            transform.localScale = new Vector2(-(Mathf.Sign(rigidbody2.velocity.x)), transform.localScale.y);
    }
}
