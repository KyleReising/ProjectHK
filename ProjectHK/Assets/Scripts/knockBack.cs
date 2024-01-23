using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockBack : MonoBehaviour
{
    public float knockbackTime = 0.2f;
    public float hitDirectionForce = 10f;
    public float constForce = 3f;
    public float inputForce = 4f;

    private Rigidbody2D rb;
    private Coroutine kbCoroutine;
    public bool IsBeingKnockedBack {  get; private set; }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void CallKnockback(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        kbCoroutine = StartCoroutine(KnockbackAction(hitDirection, constantForceDirection, inputDirection));
    }

    public IEnumerator KnockbackAction(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        IsBeingKnockedBack = true;
        Vector2  hitForce;
        Vector2  constantForce;
        Vector2  knockbackForce;
        Vector2  combinedForce;

         hitForce = hitDirectionForce * hitDirection;
         constantForce = constForce * constantForceDirection;

        float  elapsedTime = 0f;
        while( elapsedTime < knockbackTime)
        { 
             elapsedTime += Time.fixedDeltaTime;

             knockbackForce = hitForce + constantForce;

            if (inputDirection != 0)
                combinedForce = knockbackForce + new Vector2(inputDirection, 0f);
            else
                combinedForce = knockbackForce;

            rb.velocity = combinedForce;

            yield return new WaitForFixedUpdate();
        }

        IsBeingKnockedBack = false; 
    }
}
