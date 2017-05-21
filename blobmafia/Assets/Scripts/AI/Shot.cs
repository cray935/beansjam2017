using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

	private bool isPlayerShot;

	void Start ()
	{
		isPlayerShot = gameObject.tag == "PlayerShot";
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (isPlayerShot) {
			doPlayerShot (coll);
		} else {
			doEnemyShot (coll);
		}
	}

	private void doPlayerShot (Collision2D coll)
	{
		bool hit = coll.collider.tag == "Enemy";

		if (hit || coll.collider.tag == "Wall") {
			Destroy (gameObject);
		}

		if (hit) {
			Destroy (coll.gameObject);
		}
	}

	private void doEnemyShot (Collision2D coll)
	{
		bool hit = coll.collider.tag == "Player";

		if (hit || coll.collider.tag == "Wall") {
			Destroy (gameObject);
		}

		if (hit) {
			// TODO Spieler muss Leben verlieren oder sterben
		}
	}
}
