using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRectangle : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float maxBounceAngle = 75f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        // Check if the collion Object has the code "Ball" attached
        if (ball != null)
        {
            // Getting the position of the paddle and where the ball collided
            Vector2 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            // Get the distance between the paddle and the ball of the X axis
            float offset = paddlePosition.x - contactPoint.x;

            // Get the maxOffSet of the paddle bassed of the size of him
            float maxOffset = collision.otherCollider.bounds.size.x / 2;

            // Gets the current angle the ball is moving
            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rb.velocity);

            // Gets the new angle based of the offset and where the ball landed
            float bounceAngle = (offset / maxOffset) * maxBounceAngle;

            // Based on the offset and the ball current angle returns a new angle to rotate the ball, the Clamp don't allow the value to be greater then a certain number so the ball doens't goes 90 degrees
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            // With the "newAngle" generate a rotation thats gonna be applied and the ball
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);

            // Appling the rotation on the ball
            ball.rb.velocity = rotation * Vector2.up * ball.rb.velocity.magnitude;
        }
    }
}
