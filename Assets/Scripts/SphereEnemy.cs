using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnemy : Enemy
{
    [SerializeField]
    private float forceStrength = 1f;
    [SerializeField]
    private float forceFrequency = 0.3f;

    private float forceTimerMax = 1.3f;
    private float forceTimer = 0f;

    private Vector3 dir1,dir2;

    private void Start()
    {
        GenerateRandomMoveDirections();
    }

    protected override void Move()
    {
        // generate a new direction for the sinusoidal motion
        if (forceTimer > 0f)
        {
            forceTimer -= Time.deltaTime;
        } else {
            GenerateRandomMoveDirections();
            forceTimer = forceTimerMax; 
            rb.AddForce(dir1 * forceStrength, ForceMode.Impulse);
        }

        rb.AddForce(dir2 * forceStrength * Mathf.Sin(Time.time * forceFrequency), ForceMode.Force);
    }

    private void GenerateRandomMoveDirections()
    {
        dir1 = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f))).normalized;
        dir2 = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f))).normalized;
        dir2 = dir2 - Vector3.Dot(dir1, dir2) * dir1; // orthogonalize dir2 wrt dir1
    }
}
