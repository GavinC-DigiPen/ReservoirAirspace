//------------------------------------------------------------------------------
//
// File Name:	Parralax.cs
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

public class Parralax : MonoBehaviour
{
    [Tooltip("What the parralax is tracking")]
    public GameObject Target;
    [Tooltip("How far target has to move to move object 1 unit")]
    public float Scale;

    private float LerpSpeed = 0.025f;

    // Update is called once per frame
    void FixedUpdate()
    {
        var NewPosition = new Vector2(-Target.transform.position.x / Scale, -Target.transform.position.x / Scale);
        transform.position = Vector2.Lerp(transform.position, NewPosition, LerpSpeed);
    }
}
