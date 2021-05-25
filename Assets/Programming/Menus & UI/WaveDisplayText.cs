//------------------------------------------------------------------------------
//
// File Name:	WaveDisplayText.cs
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
using UnityEngine.UI;
using TMPro;

public class WaveDisplayText : MonoBehaviour
{
    [Tooltip("The ObjectSpawnManager for the game")]
    public ObjectSpawnManager ObjectSpawner;

    private TextMeshProUGUI WaveText;

    // Start is called before the first frame update
    void Start()
    {
        // Get the text component
        WaveText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Change the text
        WaveText.text = "Wave: " + ObjectSpawner.CurrentWave.ToString("N0");
    }
}
