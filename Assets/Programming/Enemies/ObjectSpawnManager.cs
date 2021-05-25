//------------------------------------------------------------------------------
//
// File Name:	ObjectSpawnManager.cs
// Author(s):	Jeremy Kings (j.kings)
//              Gavin Cooper (gavin.cooper)
// Project:		Asteroids
// Course:		WANIC VGP
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnManager : MonoBehaviour
{
    // Prefabs
    [Tooltip("The 3 prefabs of diffrent sizes, the first one is Large, last one is Small")]
    public GameObject[] SpawnedObjectPrefabs = null;
    [Tooltip("Largest wave size")]
    public int MaxWaveSize = 20;
    [Tooltip("Starting wave size")]
    public int StartingWaveSize = 8;

    [Tooltip("The pufferfish prefab.")]
    public GameObject PufferfishPrefab = null;
    [Tooltip("How many pufferfish are their to start")]
    public int NumOfPufferfish = 1;
    [Tooltip("How often does the number of pufferfish increase.")]
    public int FrequencyOfPufferfish = 2;

    //[Tooltip("What wave it is currently")]
    int CurrentWave = 0;

    // Other objects
    private Camera mCamera;

    // Misc
    private int currentWaveSize = 0;

    // Screen Bounds
    private float cameraMinX;
    private float cameraMaxX;
    private float cameraMinY;
    private float cameraMaxY;

    private enum SpawnCorner
    {
        UpperLeft,
        UpperRight,
        LowerLeft,
        LowerRight,
    }
    private enum SpawnSide
    {
        Up,
        Right,
        Down,
        Left,
    }


    public enum SizeCategory
    {
        Large,
        Medium,
        Small
    }


    // Start is called before the first frame update
    void Start()
    {
        currentWaveSize = StartingWaveSize;

        mCamera = Camera.main;
        float vertExtent = mCamera.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculate bounds
        cameraMinX = -horzExtent;
        cameraMaxX = horzExtent;
        cameraMinY = -vertExtent;
        cameraMaxY = vertExtent;
    }


    // Update is called once per frame
    void Update()
    {
        // Check that all the prefabs are present
        if (SpawnedObjectPrefabs.Length != 3)
        {
            Debug.LogError("Incorrect length of SpawnedObjectPrefabs");
            return;
        }
        else if (SpawnedObjectPrefabs[0] == null || SpawnedObjectPrefabs[1] == null || SpawnedObjectPrefabs[2] == null)
        {
            Debug.LogError("One of SpawnedObjectPrefabs is null");
            return;
        }

        // Check current number of enemies, see if more need to be spawned
        int numShark = GameObject.FindGameObjectsWithTag("Shark").Length;

        if(numShark == 0)
        {
            SpawnNextWave();
        }
    }


    // Creates all the objects for the wave
    void SpawnNextWave()
    {
        // Spawn in sharks
        for (var i = 0; i < currentWaveSize; ++i)
        {
            SpawnRandomShark();
        }

        // Check if pufferfish spawn amount need to increase
        if (CurrentWave % FrequencyOfPufferfish == 0 && CurrentWave != 0)
        {
            NumOfPufferfish++;
        }

        // Spawn in pufferfish
        for (var i = 0; i < NumOfPufferfish; i++)
        {
            SpawnRandomPufferfish();
        }

        // Increase wave size if below max
        currentWaveSize = currentWaveSize < MaxWaveSize ? currentWaveSize + 1 : currentWaveSize;

        // Increase what wave you are on
        CurrentWave++;
    }





    // Spawns in a shark of a random size and at a random position
    void SpawnRandomShark()
    {
        // Calculate random asteroid size
        var sizeCategory = (SizeCategory)Random.Range((int)SizeCategory.Large, (int)SizeCategory.Small);

        // Find corner outside bounds
        var spawnPosition = CalculateRandomSharkSpawnPosition(sizeCategory);

        // Spawn at position with base scale
        SpawnSharkAtSetPosition(spawnPosition, sizeCategory);
    }


    // Calculate the spawn position that is off screen (Shark)
    private Vector3 CalculateRandomSharkSpawnPosition(SizeCategory sizeCategory)
    {
        var spawnExtents =  new Vector2((int)sizeCategory * 0.5f, (int)sizeCategory * 0.5f);

        // Find corner outside bounds
        var spawnPosition = new Vector3();
        var corner = (SpawnCorner)Random.Range((int)SpawnCorner.LowerLeft, (int)SpawnCorner.UpperRight);
        switch (corner)
        {
            case SpawnCorner.LowerLeft:
                spawnPosition.x = cameraMinX - spawnExtents.x;
                spawnPosition.y = cameraMinY - spawnExtents.y;
                break;
            case SpawnCorner.LowerRight:
                spawnPosition.x = cameraMaxX + spawnExtents.x;
                spawnPosition.y = cameraMinY - spawnExtents.y;
                break;
            case SpawnCorner.UpperLeft:
                spawnPosition.x = cameraMinX - spawnExtents.x;
                spawnPosition.y = cameraMaxY + spawnExtents.y;
                break;
            case SpawnCorner.UpperRight:
                spawnPosition.x = cameraMaxX + spawnExtents.x;
                spawnPosition.y = cameraMaxY + spawnExtents.y;
                break;
        }

        return spawnPosition;
    }

    // Create a shark and set up it's rotation (speed is controlled on the prefab)
    public void SpawnSharkAtSetPosition(Vector3 position, SizeCategory sizeCategory)
    {
        // Create object
        var spawnedObject = Instantiate(SpawnedObjectPrefabs[(int)sizeCategory], position, Quaternion.identity);

        // Random rotation
        var rotation = Random.Range(0.0f, 360.0f);
        spawnedObject.transform.eulerAngles = new Vector3(0, 0, rotation);
    }




    // Spawns in a pufferfish at a random location
    void SpawnRandomPufferfish()
    {
        // Find side outside bounds
        var spawnPosition = CalculateRandomPufferfishSpawnPosition();

        // Spawn at position with base scale
        SpawnPufferfishAtSetPosition(spawnPosition);
    }

    // Calculate the spawn position that is off screen (Pufferfish)
    private Vector3 CalculateRandomPufferfishSpawnPosition()
    {
        var spawnExtents = new Vector2(1, 1);

        // Find corner outside bounds
        var spawnPosition = new Vector3();
        var side = (SpawnSide)Random.Range((int)SpawnSide.Up, (int)SpawnSide.Left);
        switch (side)
        {
            case SpawnSide.Up:
                spawnPosition.x = 0;
                spawnPosition.y = cameraMaxY + spawnExtents.y;
                break;
            case SpawnSide.Right:
                spawnPosition.x = cameraMaxX + spawnExtents.x;
                spawnPosition.y = 0;
                break;
            case SpawnSide.Down:
                spawnPosition.x = 0;
                spawnPosition.y = cameraMinY - spawnExtents.y;
                break;
            case SpawnSide.Left:
                spawnPosition.x = cameraMinX - spawnExtents.x;
                spawnPosition.y = 0;
                break;
        }

        return spawnPosition;
    }

    // Create pufferfish and set up it's rotation (movement is controlled on the prefab)
    public void SpawnPufferfishAtSetPosition(Vector3 position)
    {
        // Create object
        var spawnedObject = Instantiate(PufferfishPrefab, position, Quaternion.identity);

        // Random rotation
        var rotation = Random.Range(0.0f, 360.0f);
        spawnedObject.transform.eulerAngles = new Vector3(0, 0, rotation);
    }
}
