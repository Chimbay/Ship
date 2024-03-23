using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Storing the component of rigidBody2D
    private Rigidbody2D rb2d;
    // Direction of thrust
    Vector2 thrustDirection;
    // Setting thrust force
    const float thrustForce = 300;
    // Step 4 - Storing ship collider
    private CircleCollider2D cc2d;

    // Step 5 - Initialize ship rotation
    const float rotateDegreesPerSecond = 80;

    // Step 6
    // Save axis input
    float rotationInput;
    // Save ship's rotation around the Z-axis
    float shipRotationZ;
    // Save angle
    float shipRotationRadians;
    // Bool to check if spacebar was pressed or not
    bool pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initializing the component to rb2d
        rb2d = GetComponent<Rigidbody2D>();

        // Updating it with new direction for Step 6
        //// Initializing direction of thrust
        //thrustDirction = new Vector2(1, 0);

        // Initializing ship collider
        cc2d = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Save axis input
        rotationInput = Input.GetAxis("Rotate");
        // Extract ship's rotation around the Z-axis
        shipRotationZ = transform.eulerAngles.z;
        // Convert angle from degrees to radians
        shipRotationRadians = shipRotationZ * Mathf.Deg2Rad;
        // Determine X and Y components of the thrust direction
        thrustDirection.x = Mathf.Cos(shipRotationRadians);
        thrustDirection.y = Mathf.Sin(shipRotationRadians);

        // Check if there's any input
        if (rotationInput != 0)
        {
            // Calculate rotation amount based on input and time
            float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;
            // Reverse rotation amount if input is negative
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }

            // Apply rotation
            transform.Rotate(Vector3.forward, rotationAmount);
        }
    }

    // Unlike update, FixedUpdate() updates physics in a consistent manner (like Time.
    void FixedUpdate()
    {
        // Input check for spacebar
        if (Input.GetKeyDown("space") || pressed)
        {
            rb2d.AddForce(thrustDirection * thrustForce, ForceMode2D.Force);
        }
    }

    // OnBecameInvisible is called when the renderer is no longer visible by any camera.
    void OnBecameInvisible()
    {
        Vector3 position = transform.position;
        if (position.x - cc2d.radius < ScreenUtils.ScreenLeft)
        {
            // Screen wrapping to the left
            position.x = ScreenUtils.ScreenRight + cc2d.radius;
            transform.position = position;
        }

        if (position.y + cc2d.radius > ScreenUtils.ScreenTop)
        {
            // Screen wrapping from the top
            position.y = ScreenUtils.ScreenBottom - cc2d.radius;
            transform.position = position;
        }

        if (position.x + cc2d.radius > ScreenUtils.ScreenRight)
        {
            // Screen wrapping to the right;
            position.x = ScreenUtils.ScreenLeft - cc2d.radius;
            transform.position = position;
        }

        if (position.y - cc2d.radius < ScreenUtils.ScreenBottom)
        {
            // Screen wrapping from the bottom
            position.y = ScreenUtils.ScreenTop + cc2d.radius;
            transform.position = position;
        }
    }
}