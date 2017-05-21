using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
	
	public float speed = 5;
	public float timeleft = 1f;

	private Rigidbody2D rb;
	private bool stopped = false;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		if (stopped) {
			return;
		}

		if (timeleft > 0) {
			timeleft -= Time.deltaTime;
			return;
		}

		rb.velocity = new Vector2 (speed, rb.velocity.y);
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "GohstWall")
			stopped = true;
	}
}
