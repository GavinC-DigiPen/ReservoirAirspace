//------------------------------------------------------------------------------
//
// File Name:	SharkAnimatorController.cs
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

public class SharkAnimationController : MonoBehaviour
{

    private Animator myAnimator;
    private Rigidbody2D myRidgidBody;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRidgidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Change animator variable on hit
    private void OnCollisionEnter2D()
    {
        // Set animator variable
        myAnimator.SetBool("Dead", true);

        // Remove movement
        myRidgidBody.velocity = new Vector2(0, 0);
        myRidgidBody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
