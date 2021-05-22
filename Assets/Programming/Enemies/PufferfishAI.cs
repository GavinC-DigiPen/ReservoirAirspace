//------------------------------------------------------------------------------
//
// File Name:	PufferfishAI.cs
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

public class PufferfishAI : MonoBehaviour
{
    [Tooltip("The object the pufferfish is targeting")]
    public GameObject Target;
    public float RotationSpeed = 0.5f;
    public float MoveSpeed = 0.5f;

    public GameObject Spine;
    public int NumberOfSpines = 8;
    public float SpineSpeed = 1;

    private Transform mTransform;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        // Get Transform
        mTransform = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //find vector pointing from object to target
        var direction = (Target.transform.position - transform.position).normalized;

        //convert vector to angle rotation
        var lookAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        //rotate
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(-lookAngle + 90, Vector3.forward), Time.deltaTime * RotationSpeed);

        //get move dirrection
        Vector2 moveDirection = new Vector2(
            Mathf.Cos(mTransform.eulerAngles.z * Mathf.Deg2Rad),
            Mathf.Sin(mTransform.eulerAngles.z * Mathf.Deg2Rad));

        // Move object
        body.velocity = moveDirection * MoveSpeed;
    }

    // pufferfish collide
    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if it dirrectly collided with the player
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            return;
        }

        Explode();
    }

    // When pufferfish in in range
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if player
        if (collision.gameObject.tag != "Player")
        {
            return;
        }

        Explode();
    }

    void Explode()
    {
        //turn off hit box
        GetComponent<PolygonCollider2D>().enabled = false;

        for (int i = 0; i < NumberOfSpines; i++)
        {
            // Spawn objet
            var spawnedObject = Instantiate(Spine, transform.position, Quaternion.identity);

            // Rotate object
            spawnedObject.transform.rotation = Quaternion.AngleAxis((float)360 / (float)NumberOfSpines * (float)i, Vector3.forward);

            // Get move dirrection
            Vector2 moveDirection = new Vector2(
                Mathf.Cos(spawnedObject.gameObject.GetComponent<Transform>().eulerAngles.z * Mathf.Deg2Rad),
                Mathf.Sin(spawnedObject.gameObject.GetComponent<Transform>().eulerAngles.z * Mathf.Deg2Rad));

            // Move object
            spawnedObject.gameObject.GetComponent<Rigidbody2D>().velocity = moveDirection * SpineSpeed;
        }

        Destroy(gameObject);
    }
}
