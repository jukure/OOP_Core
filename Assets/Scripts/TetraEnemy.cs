using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetraEnemy : Enemy// INHERITANCE
{
    protected override void Move() //POLYMORPHISM
    {
        Vector3 dir = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f))).normalized;
        rb.AddForce(dir * forceStrength, ForceMode.Impulse);
    }
}
