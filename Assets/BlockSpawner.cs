using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	public Transform[] spawnPoints;

	public GameObject blockPrefab;

	public float timeBetweenWaves = 1f;

	private float timeToSpawn = 0f; // start right away the first time.

	void Update () {

		if (Time.time >= timeToSpawn)
		{
			SpawnBlocks();
			timeToSpawn = Time.time + timeBetweenWaves;
		}

	}

	void SpawnBlocks ()
	{
		int randomIndex = Random.Range(0, spawnPoints.Length);

		for (int i = 0; i < spawnPoints.Length; i++)
		{
			if (randomIndex != i)
			{
				Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
			}
		}
	}
	
}
