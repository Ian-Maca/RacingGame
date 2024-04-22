using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float PB_TIMER_MAX = 99999999f;
    
    public float speed = 10.0f;
    public float turnSpeed = 5.0f;
    
    public Transform respawnPoint;
    private Rigidbody _rb;
    
    private bool _canMove = true;
    public float _current_time = 0f;
    public float _personal_best = 99999999f;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()  // Use FixedUpdate for physics
    {
        if (!_canMove)
        {
            return;
        }
        
        _current_time += Time.deltaTime;
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Forward/Backward Movement
        var movement = -transform.forward * (moveVertical * speed);

        // Steering
        float turnAngle = moveHorizontal * turnSpeed;
        Quaternion turn = Quaternion.Euler(0f, turnAngle, 0f);

        // Apply movement and rotation
        _rb.MovePosition(_rb.position + movement * Time.deltaTime);
        
        _rb.MoveRotation(_rb.rotation * turn);
    }
    
    void OnTriggerEnter(Collider other) 
    {
        // Access the object that was hit:
        GameObject objectWeHit = other.gameObject; 
        
        // Implement your collision reaction:2
        Debug.Log("Car is crashing into..." + objectWeHit.tag);

        if (objectWeHit.CompareTag("Finish"))
        {
            // FINISH LINE

            if (_current_time < _personal_best)
            {
                _personal_best = _current_time;
                Debug.Log("Finished! - New Personal Best: " + _personal_best);
            }
            else
            {
                Debug.Log("Finished! - Old Personal Best: " + _personal_best);
            }
        }
        
        // HIT A WALL
        StartCoroutine(Respawn());
        
    }

    IEnumerator Respawn()
    {
        _current_time = 0;
        
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
        _canMove = false;

        yield return new WaitForSeconds(1f);
        _canMove = true;
    }
    
}



