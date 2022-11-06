using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource rocketAudio;

    float thrustSpeed = 1000f;             // Rate of thrust
    float rotateRate = 100f;               // Rate of rotation


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rocketAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust()
    {
        // Press space bar to thrust.
        if (Input.GetKey(KeyCode.Space))
        {
            
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
            if (!rocketAudio.isPlaying)
            {
                rocketAudio.Play();
            }
        }
        else  
        {
            rocketAudio.Stop();
        }
    }

    void ProcessRotation()
    {
        // Press A to rotate left.
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateRate);
        }
        // Press D to rotate right.
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateRate);
        }
    }

     void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;    // Freezing rotation so we can manually rotate.
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
