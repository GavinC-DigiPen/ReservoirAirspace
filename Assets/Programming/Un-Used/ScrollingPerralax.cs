//------------------------------------------------------------------------------
//
// File Name:	ScrollingPerralax.cs
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

public class ScrollingPerralax : MonoBehaviour
{
    public float WarpPoint;
    public float Speed;

    private Vector2 StartingLocation;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartingLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Negative speed, right to left
        if (transform.position.x < WarpPoint && Speed < 0)
        {
            transform.position = StartingLocation;
        }
        // Negative speed, right to left
        else if (transform.position.x > WarpPoint && Speed > 0)
        {
            transform.position = StartingLocation;
        }

        // Move object
        transform.position = new Vector2(transform.position.x + (Speed * Time.deltaTime), transform.position.y);
    }
}
