using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 5.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()  // Use FixedUpdate for physics
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Forward/Backward Movement
        var movement = -transform.forward * (moveVertical * speed);

        // Steering
        float turnAngle = moveHorizontal * turnSpeed;
        Quaternion turn = Quaternion.Euler(0f, turnAngle, 0f);

        // Apply movement and rotation
        rb.MovePosition(rb.position + movement * Time.deltaTime);
        
        rb.MoveRotation(rb.rotation * turn);
    }
}



