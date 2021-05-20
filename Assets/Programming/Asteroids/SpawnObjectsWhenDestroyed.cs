//------------------------------------------------------------------------------
//
// File Name:	SpawnObjectsWhenDestroyed.cs
// Author(s):	Jeremy Kings (j.kings)
// Project:		Asteroids
// Course:		WANIC VGP
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsWhenDestroyed : MonoBehaviour
{
    // Public properties
    public int MinObjectsToSpawn = 2;
    public int MaxObjectsToSpawn = 3;

    //Size
    public ObjectSpawnManager.SizeCategory Size;

    // Components
    private Transform mTransform = null;

    // Other objects
    private ObjectSpawnManager spawnManager = null;

    // Start is called before the first frame update
    void Start()
    {
        mTransform = GetComponent<Transform>();
        spawnManager = FindObjectOfType<ObjectSpawnManager>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (mTransform == null)
            return;

        // Too small
        if (Size == ObjectSpawnManager.SizeCategory.Small)
            return;

        var numToSpawn = UnityEngine.Random.Range(MinObjectsToSpawn, MaxObjectsToSpawn);

        for (var i = 0; i < numToSpawn; ++i)
        {
            spawnManager.SpawnAtSetPosition(transform.position, Size + 1);
        }
    }
}
