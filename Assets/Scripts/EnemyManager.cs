using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    float spawnsPerMin = 50;

    [SerializeField]
    GameObject mallowPrefab;

    [SerializeField]
    GameObject[] spawnPoints;

    private float timeOfLastSpawn = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad - timeOfLastSpawn >= 60 / spawnsPerMin)
        {
            int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            // Spawn mallow
            GameObject mallow = Instantiate(mallowPrefab, spawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
            timeOfLastSpawn = Time.timeSinceLevelLoad;
        }
	}
}
