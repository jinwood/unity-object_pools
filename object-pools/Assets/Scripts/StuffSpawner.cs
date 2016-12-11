using UnityEngine;
using System.Collections;

public class StuffSpawner : MonoBehaviour
{

	public FloatRange timeBetweenSpawns, scale, randomVelocity, angularVelocity;
	public Stuff[] stuffPrefabs;
	public float velocity;
	public Material stuffMaterial;

	float currentSpawnDelay;
	float timeSinceLastSpawn;

	void FixedUpdate ()
	{
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= currentSpawnDelay) {
			timeSinceLastSpawn -= currentSpawnDelay;
			currentSpawnDelay = timeBetweenSpawns.RandomInRange;
			SpawnStuff ();
		}
	}

	void SpawnStuff ()
	{
		var prefab = stuffPrefabs [Random.Range (0, stuffPrefabs.Length)];
		var spawn = Instantiate<Stuff> (prefab);


		spawn.transform.localPosition = transform.position;
		spawn.transform.localScale = Vector3.one * scale.RandomInRange;
		spawn.transform.localRotation = Random.rotation;
		spawn.Body.angularVelocity =
			Random.onUnitSphere * angularVelocity.RandomInRange;

		spawn.GetComponent<MeshRenderer> ().material = stuffMaterial;

		spawn.Body.velocity = transform.up * velocity +
		Random.onUnitSphere * randomVelocity.RandomInRange;
	}
}
