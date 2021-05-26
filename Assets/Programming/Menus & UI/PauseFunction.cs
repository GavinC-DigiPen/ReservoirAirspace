//------------------------------------------------------------------------------
//
// File Name:	PauseFunction.cs
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


public class PauseFunction : MonoBehaviour
{
    [Tooltip("The state of pause.")]
    public static bool IsPaused = false;
    [Tooltip("The parent object of the pause menu (not the object this script is on).")]
    public GameObject[] PauseMenu;
    [Tooltip("The pause sound")]
    public AudioClip PauseSound;
    [Tooltip("The unpause sound")]
    public AudioClip UnPauseSound;

    private AudioSource myAudio;


    //make sure pause is off
    void Start()
    {
        Time.timeScale = 1;
        IsPaused = false;

        myAudio = GetComponent<AudioSource>();
    }


    // Update to check if pause button is pushed
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if(IsPaused)
            {
                Resume();
            }

            else if (!IsPaused)
            {
                Pause();
            }
        }
    }


    //Function to pause game
    public void Pause()
    {
        Time.timeScale = 0;
        IsPaused = true;
        for (int i = 0; i < PauseMenu.Length; i++)
        {
            PauseMenu[i].SetActive(true);
        }

        //Audio
        if (PauseSound != null)
        {
            myAudio.clip = PauseSound;
            myAudio.Play();
        }
    }


    //Fuction to resume game
    public void Resume()
    {
        Time.timeScale = 1;
        IsPaused = false;
        for (int i = 0; i < PauseMenu.Length; i++)
        {
            PauseMenu[i].SetActive(false);
        }

        //Audio
        if (UnPauseSound != null)
        {
            myAudio.clip = UnPauseSound;
            myAudio.Play();
        }
    }
}
