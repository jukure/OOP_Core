using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // Base class for enemies
//    protected int hitPoints;
    protected Rigidbody rb;

    [SerializeField]
    protected float m_forceStrength = 1f;
    public float forceStrength { // ENCAPSULATION
        get
        {
            return m_forceStrength;
        }
        set 
        {
            forceStrength = value;
        }
    }

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
