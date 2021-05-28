//------------------------------------------------------------------------------
//
// File Name:	PlaySound.cs
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

public class PlaySound : MonoBehaviour
{
    [Tooltip("The sound that will be played")]
    public AudioClip Sound;

    private AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Play a sound
    public void PlayTheSound()
    {
        myAudio.clip = Sound;
        myAudio.Play();
    }
}
