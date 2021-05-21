//------------------------------------------------------------------------------
//
// File Name:	SpawnObjectsWhenDestroyed.cs
// Author(s):	Jeremy Kings (j.kings)
//              Gavin Cooper (gavin.cooper)
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
    [Tooltip("Minimum number of sharks to spawn when destroyed")]
    public int MinObjectsToSpawn = 2;
    [Tooltip("Maximum number of sharks to spawn when destroyed")]
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

    // Sometimes summon more sharks when destoryed
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check that the ObjectSpawnManager exists
        if (mTransform == null)
        {
            return;
        }

        // Check if it at the smallest size and doesnt need to spawn more
        if (Size == ObjectSpawnManager.SizeCategory.Small)
        {
            return;
        }

        // Check if it dirrectly collided with the player
        if (collision.gameObject.tag == "Player")
        {
            return;
        }

        // Get a random number of how many sharks should be spawned in
        var numToSpawn = UnityEngine.Random.Range(MinObjectsToSpawn, MaxObjectsToSpawn);

        // Spawn in sharks
        for (var i = 0; i < numToSpawn; ++i)
        {
            spawnManager.SpawnSharkAtSetPosition(transform.position, Size + 1);
        }
    }
}
