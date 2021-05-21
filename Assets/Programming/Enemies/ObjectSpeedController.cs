//------------------------------------------------------------------------------
//
// File Name:	ObjectSpeedController.cs
// Author(s):	Gavin Cooper (gavin.cooper)
// Project:		Asteroids
// Course:		WANIC VGP
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpeedController : MonoBehaviour
{
    [Tooltip("Minimum speed of object")]
    public float MinObjectSpeed = 2;
    [Tooltip("Maximum speed of object")]
    public float MaxObjectSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Get Transform
        var mTransform = GetComponent<Transform>();
        var body = GetComponent<Rigidbody2D>();

        // Random speed
        var speed = Random.Range(MinObjectSpeed, MaxObjectSpeed);

        //get move dirrection
        Vector2 moveDirection = new Vector2(
            Mathf.Cos(mTransform.eulerAngles.z * Mathf.Deg2Rad),
            Mathf.Sin(mTransform.eulerAngles.z * Mathf.Deg2Rad));

        // Move object
        body.velocity = moveDirection * speed;
    }

}
