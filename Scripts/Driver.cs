using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Here we have a SerializeField(an attribute)
    [SerializeField] float mainSpeed = 1f;

    // main moving speed 
    [SerializeField] float movingSpeed = 20f;

    // fast speed for when user slip on ice
    [SerializeField] float fastSpeed = 30f;

    // slow speed for when user bump into an obstacle 
    [SerializeField] float slowSpeed = 12f;

    // Update is called once per frame
    void Update()
    {
        // class Input while using an Axis, here is for steering. We use deltaTime so movement is the same rate on slow or fast computers.
        float steering = Input.GetAxis("Horizontal") * mainSpeed * Time.deltaTime;
        // Here allows the player to move forward and backwards with the arrow key. We use deltaTime so movement is the same rate on slow or fast computers.
        float moving = Input.GetAxis("Vertical") * movingSpeed * Time.deltaTime;

        // here use the transform class with Rotate method
        transform.Rotate(0, 0, -steering);
        // here use the transform class with Translate method
        transform.Translate(0, moving, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // set movingSpeed to slowSpeed when the user bumps into somthing
        movingSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if tag is slipSpeed
        if(collision.tag == "slipSpeed")
        {
            Debug.Log("SLIPPERY ICE");
            // set movingSpeed to fastSpeed
            movingSpeed = fastSpeed;
        }
    }

}

