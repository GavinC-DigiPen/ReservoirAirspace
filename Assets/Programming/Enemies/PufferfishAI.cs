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
}
