﻿/******************/
///Name: Zach Scott
///Date: 5/20/21
///Desc: Add this to an object to give it a limited amount of times it can get hit
/******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLives : MonoBehaviour
{
    [Tooltip("The amount of hits the player can take before they die")]
    public int Lives = 3;
    [Tooltip("A list of functions to run when dead (Lives == 0)")]
    public UnityEvent OnDeath = new UnityEvent();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Lives > 0)
        {
            if (collision.gameObject.CompareTag("Shark"))
            {
                Lives--;
            }
            //if at zero, execute functions
            if (Lives == 0)
            {
                GetComponent<RestartOnCollision>().Disabled();
            }

        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
