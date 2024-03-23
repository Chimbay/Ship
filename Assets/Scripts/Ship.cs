using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Storing the component of rigidBody2D
    private Rigidbody2D rb2d;
    // Direction of thrust
    Vector2 thrustDirction;
    // Setting thrust force
    const float thrustForce = 300;
    // Step 4 - Storing ship collider
    private CircleCollider2D cc2d;

    // Start is called before the first frame update
    void Start()
    {
        // Initializing the component to rb2d
        rb2d = GetComponent<Rigidbody2D>();
        // Initializing direction of thrust
        thrustDirction = new Vector2(1, 0);
        // Initializing ship collider
        cc2d = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Unlike update, FixedUpdate() updates physics in a consistent manner (like Time.
    void FixedUpdate()
    {
        // Input check for spacebar
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            rb2d.AddForce(thrustDirction * thrustForce, ForceMode2D.Force);
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