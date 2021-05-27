//------------------------------------------------------------------------------
//
// File Name:	LifeDisplay.cs
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

public class LifeDisplay : MonoBehaviour
{
    public GameObject[] LivesObjects;
    public GameObject EffectPrefab;

    private int NumOfLives;

    // Start is called before the first frame update
    void Start()
    {
        NumOfLives = LivesObjects.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to be called to remove a life
    public void RemoveLife()
    {
        NumOfLives--;

        for (int i = LivesObjects.Length - 1; i > NumOfLives - 1; i--)
        {
            // Effect
            if (LivesObjects[i].activeSelf == true)
            {
                Instantiate(EffectPrefab, LivesObjects[i].transform.position, Quaternion.identity);
            }

            // Turn off object
            LivesObjects[i].SetActive(false);
        }
    }

    // Function to be called to add a life
    public void AddLife()
    {
        NumOfLives++;

        for (int i = 0; i < NumOfLives; i++)
        {
            // Turn on object
            LivesObjects[i].SetActive(true);
        }
    }
}
