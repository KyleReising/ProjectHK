using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyParent : MonoBehaviour
{
    public int health = 1;
    public int damage = 1;
    public float speed = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerScript>().takeDamage(damage);
            Debug.Log("gamer");
        }
    }

    private void Update()
    {
        if (health <= 0) { Debug.Log("i dead");Destroy(this.gameObject); }
    }
}
