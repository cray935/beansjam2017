using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.collider.tag == "Player" || coll.collider.tag == "Wall") {
			Destroy (gameObject);
		}
	}
}
