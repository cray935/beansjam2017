using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
	public Rigidbody2D shotPrefab;
	public Transform shootPos;

	public float shootingRate = 1f;
	public float viewDistance = 10f;
	public float shootSpeed = 0.5f;

	private float shootCooldown = 0f;
	public bool looksLeft = false;

	void Update ()
	{
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}

		Vector2 castStart = GetStartVector ();
		Vector2 castEnd = GetTargetVector ();

		RaycastHit2D hitinfo = Physics2D.Linecast (castStart, castEnd);

		if (hitinfo.collider != null && hitinfo.collider.tag == "Player") {

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