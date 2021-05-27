//------------------------------------------------------------------------------
//
// File Name:	DestroyOnCollision.cs
// Author(s):	Jeremy Kings (j.kings)
// Project:		Asteroids
// Course:		WANIC VGP
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public float Delay = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Renderer = GetComponent<SpriteRenderer>();
        if (Renderer != null)
        {
            Renderer.enabled = false;
        }

        var Collider = GetComponent<CircleCollider2D>();
        if (Collider != null)
        {
            Collider.enabled = false;
        }

        Destroy(gameObject, Delay);
    }
}
