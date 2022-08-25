using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // Base class for enemies
    protected int hitPoints;
    protected Rigidbody rb;


    void Awake()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
    }

    protected abstract void Move();

}
