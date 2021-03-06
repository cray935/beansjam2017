﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
	public float maxSpeed = 10f;
	public float maxJump = 1f;

	private Rigidbody2D body;
	private bool playerIsGrounded = false;

	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate ()
	{
		float move = Input.GetAxis ("Horizontal");
		float jump = Input.GetAxis ("Jump");

		if (Input.GetKeyDown (KeyCode.Space) && playerIsGrounded) {
			body.velocity = new Vector2 (move * maxSpeed, jump * maxJump);
		} else {
			// Links und Rechts
			body.velocity = new Vector2 (move * maxSpeed, body.velocity.y);
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.collider.tag == "Ground")
			playerIsGrounded = true;
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.collider.tag == "Ground")
			playerIsGrounded = false;
	}

}
