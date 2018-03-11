using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    float spawnsPerMin = 50;

    [SerializeField]
    GameObject mallowPrefab;

    [SerializeField]
    GameObject spawnPoint;

    private float timeOfLastSpawn = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad - timeOfLastSpawn >= 60 / spawnsPerMin)
        {
            // Spawn mallow
            GameObject mallow = Instantiate(mallowPrefab, spawnPoint.transform.position, Quaternion.identity);
            timeOfLastSpawn = Time.timeSinceLevelLoad;
        }
	}
}
