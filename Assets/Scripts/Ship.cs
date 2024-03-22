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
    const float thrustForce = 20;

    // Start is called before the first frame update
    void Start()
    {
        // Initializing the component to rb2d
        rb2d = GetComponent<Rigidbody2D>();
        // Initializing direction of thrust
        thrustDirction = new Vector2(1, 0);
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
}