using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public Rigidbody2D shotPrefab;
	public Transform shootPos;

	public float shootingRate = 1f;
	public float viewDistance = 10f;
	public float shootSpeed = 0.5f;
	public float moveSpeed = 5f;

	private Rigidbody2D body;
	private float shootCooldown = 0f;
	// Kann man ja später mal richtig implementieren..
	private bool looksLeft = true;
	private bool attackMode = false;

	void Start ()
	{
		body = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}

		Vector2 castStart = GetStartVector ();
		Vector2 castEnd = GetTargetVector ();

		RaycastHit2D hitinfo = Physics2D.Linecast (castStart, castEnd);

		attackMode = hitinfo.collider != null && hitinfo.collider.tag == "Player";

		if (attackMode) {
			Attack ();
		} else {
			Move ();
		}
	}

	public void Attack ()
	{
		if (CanAttack) {

			shootCooldown = shootingRate;

			if (looksLeft) {
				Rigidbody2D clone = (Instantiate (shotPrefab, shootPos.position, shotPrefab.transform.rotation) as Rigidbody2D);
				clone.AddForce (new Vector2 (-shootSpeed, 0), ForceMode2D.Force);
			} else {
				Rigidbody2D clone = (Instantiate (shotPrefab, transform.position + 1.0f * transform.forward, transform.rotation) as Rigidbody2D);
				clone.AddRelativeForce (new Vector2 (shootSpeed, 0), ForceMode2D.Force);
			}

		}
	}

	public void Move ()
	{
		// Gegner gucken nach links und laufen nach links!
		body.velocity = new Vector2 (-1 * moveSpeed, body.velocity.y);
	}

	public bool CanAttack {
		get {
			return shootCooldown <= 0f;
		}
	}

	private Vector2 GetStartVector ()
	{
		if (looksLeft) {
			return new Vector2 (shootPos.position.x, shootPos.position.y);
		} else {
			return new Vector2 (shootPos.position.x, shootPos.position.y);
		}
	}

	private Vector2 GetTargetVector ()
	{
		if (looksLeft) {
			return new Vector2 (transform.position.x - viewDistance, transform.position.y);
		} else {
			return new Vector2 (transform.position.x + viewDistance, transform.position.y);
		}
	}
}