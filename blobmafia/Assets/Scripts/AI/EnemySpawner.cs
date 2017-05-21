using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;

	public int maxEnemies = 5;
	public float spawnRate = 0.5f;

	private List<GameObject> spawnedEnemies = new List<GameObject> ();
	private int enemies = 0;
	private float spawnCooldown = 0f;

	void Update ()
	{
		if (enemies >= maxEnemies) {
			return;
		}

		if (spawnCooldown > 0f) {
			spawnCooldown -= Time.deltaTime;
		}

		if (spawnCooldown <= 0f) {

			spawnCooldown = spawnRate;

			spawn ();
		}
	}

	private void updateSpawnList ()
	{

		foreach (GameObject enemy in spawnedEnemies) {
			
		}
	}

	private void spawn ()
	{
		Instantiate (enemy, transform.position, transform.rotation);
		enemies++;
	}
}
