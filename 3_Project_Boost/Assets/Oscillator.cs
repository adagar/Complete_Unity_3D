﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Can't apply multiple instances of this to a component
[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;
    [Range(0,1)][SerializeField] float movementFactor; // 0 for not moved, 1 for fullly moved
    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
