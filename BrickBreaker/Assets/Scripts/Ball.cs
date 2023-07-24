using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] public Rigidbody2D rb;

    // Makes the ball start moving
    void Start()
    {        
        Vector2 force = Vector2.zero;
        force.y = 1;
        force.x = Random.Range(-0.5f, 0.5f);

        rb.AddForce(force.normalized * moveSpeed);
    }

    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * moveSpeed;
    }
}
