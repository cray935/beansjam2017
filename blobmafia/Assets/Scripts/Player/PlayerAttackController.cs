using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
	public Rigidbody2D shotPrefab;

	public float shootingRate = 1f;
	public float shootSpeed = 0.5f;

	private Transform shootPos;
	private float shootCooldown = 0f;
	// Kann man ja später mal richtig implementieren..
	private bool looksLeft = false;

	void Start ()
	{
		shootPos = GetComponent<Transform> ();
	}

	void Update ()
	{
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Attack ();
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

	public bool CanAttack {
		get {
			return shootCooldown <= 0f;
		}
	}
}
