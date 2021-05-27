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
    private PlayerLives PlayerLives;

    private void Start()
    {
        // Get player animator
        PlayerAnim = GetComponent<Animator>();
        PlayerLives = GetComponent<PlayerLives>();

        // Make sure goldfish isnt dead at the start
        PlayerAnim.SetBool("GoldfishDead", false);
        PlayerAnim.SetBool("GoldfishHurt", false);
    }

    // Hurt goldfish
    public void ChangeGoldfishHurt()
    {
        PlayerAnim.SetBool("GoldfishHurt", true);
        Invoke("UnHurtGoldfish", PlayerLives.ImmuneTime);
    }

    // Unhurt goldfish
    public void UnHurtGoldfish()
    {
        PlayerAnim.SetBool("GoldfishHurt", false);
    }

    // Function to set if goldfish is dead or not
    public void ChangeGoldfishDeath(bool Dead)
    {
        PlayerAnim.SetBool("GoldfishDead", Dead);
    }
}
