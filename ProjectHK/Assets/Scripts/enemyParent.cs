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
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerScript>().takeDamage(damage);
        }
    }




    private void Update()
    {
        if (health <= 0) { Debug.Log("i dead");Destroy(this.gameObject); }
    }
}
