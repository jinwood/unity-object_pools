using UnityEngine;
using System.Collections;

public class NucleonSpawner : MonoBehaviour {
	public float timeBetweenSpawns;
	public float spawnDistance;
	public Nucleon[] nucleonPrefabs;
	float timeSinceLastSpawn;

	void FixedUpdate () {
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= timeBetweenSpawns) {
			timeSinceLastSpawn -= timeBetweenSpawns;
			SpawnNucleon();
		}
	}

	void SpawnNucleon(){
		var prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
		var spawn = Instantiate<Nucleon>(prefab);
		spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
	}

	
}
