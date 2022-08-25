using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : Enemy
{
    [SerializeField]
    private float forceStrength = 1f;

    private float forceTimerMax = 1f;
    private float forceTimer = 0f;

    protected override void Move()
    {
        // move in the 
        if (forceTimer > 0f)
        {
            forceTimer -= Time.deltaTime;
        } else {
            Vector3 dir = (Random.Range(0f, 1f) < 0.5f) ? transform.right : transform.forward;
            if (Random.Range(0f, 1f) < 0.5f) { dir = -dir; }
            rb.AddForce(dir * forceStrength, ForceMode.Impulse);
            forceTimer = forceTimerMax; 
        }
    }
}
