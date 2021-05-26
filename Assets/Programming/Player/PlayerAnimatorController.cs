//------------------------------------------------------------------------------
//
// File Name:	PlayerAnimatorController.cs
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
using UnityEngine.Animations;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator PlayerAnim;

    private void Start()
    {
        // Get player animator
        PlayerAnim = GetComponent<Animator>();

        // Make sure goldfish isnt dead at the start
        PlayerAnim.SetBool("GoldfishDead", false);
    }

    // Function to set if goldfish is dead or not
    public void ChangeGoldfishDeathAnimatorVariable(bool Dead)
    {
        PlayerAnim.SetBool("GoldfishDead", Dead);
    }
}
