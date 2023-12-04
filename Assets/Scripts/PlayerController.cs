using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Initialize shifting speed of moving object
    // Also a condition check bool to move 
    public float shiftSpeed = 5f;
    private bool moveRight = true;


    // Update is called once per frame
    void Update()
    {

        // Move the cube back and forth along the X-axis
        if (moveRight)
        {
            transform.Translate(Vector3.right * shiftSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * shiftSpeed * Time.deltaTime);
        }

        // Check if the cube has reached its limit and change direction
        if (transform.position.x >= 5f)
        {
            moveRight = false;
        }
        else if (transform.position.x <= -5f)
        {
            moveRight = true;
        }

    }



}
