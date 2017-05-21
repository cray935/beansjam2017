using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
	public float maxSpeed = 10f;

	private Rigidbody2D body;

	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate ()
	{
		float move = Input.GetAxis ("Horizontal");

		body.velocity = new Vector2 (move * maxSpeed, body.velocity.y);
	}
}
