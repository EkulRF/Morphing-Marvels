using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float acceleration = 2f;
    public float deceleration = 3f;
    public float rotationSpeed = 200f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input values
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Rotation"); // You need to set up a separate input axis for rotation

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Move the player
        MovePlayer(movement);

        // Rotate the player
        RotatePlayer(rotationInput);
    }

    void MovePlayer(Vector2 movement)
    {
        // Calculate target velocity
        Vector2 targetVelocity = new Vector2(movement.x * maxSpeed, movement.y * maxSpeed);

        // Apply acceleration
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, acceleration * Time.deltaTime);

        // Apply deceleration if there is no input
        if (movement == Vector2.zero)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, deceleration * Time.deltaTime);
        }
    }

    void RotatePlayer(float rotationInput)
    {
        // Rotate the player based on rotation input
        transform.Rotate(Vector3.forward * rotationInput * rotationSpeed * Time.deltaTime);
    }
}