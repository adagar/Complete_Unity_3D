using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    const int THRUST_FORCE = 2;
    Rigidbody rigidBody; 
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * THRUST_FORCE);
        }

        if (Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.forward);
        } else if (Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.back);
        }
    }
}
