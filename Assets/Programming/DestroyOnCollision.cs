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
    public bool MakeInvisible = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (MakeInvisible)
        {
            var Renderer = GetComponent<SpriteRenderer>();
            if (Renderer != null)
            {
                Renderer.enabled = false;
            }
        }

        var CircleCollider = GetComponent<CircleCollider2D>();
        if (CircleCollider != null)
        {
            CircleCollider.enabled = false;
        }

        var BoxCollider = GetComponent<BoxCollider2D>();
        if (BoxCollider != null)
        {
            BoxCollider.enabled = false;
        }

        Destroy(gameObject, Delay);
    }
}
