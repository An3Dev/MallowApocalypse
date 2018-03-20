﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour {

    
    float spawnsThisWave;

    [SerializeField]
    GameObject mallowPrefab;

    [SerializeField]
    GameObject[] spawnPoints;

    [SerializeField]
    EnemyProgression enemyProgression;

    [SerializeField]
    UIManager managerOfUI;

    PlayerHealth playerHealth;

    // How many we have spawned so far
    [SerializeField]
    float numOfTotalSpawned = 0;

    private float timeOfLastSpawn = 0;

    int waveNum = 1;

	// Use this for initialization
	void Start () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        
        
	}
	
	// Update is called once per frame
	void Update () {

        waveNum = enemyProgression.waveNum;

        // This is an exponential increase
        spawnsThisWave = Variables.firstWaveMallowSpawns * Mathf.Pow(Variables.mallowSpawnIncreasePerWave, waveNum); 

		if(Time.timeSinceLevelLoad - timeOfLastSpawn >= Variables.spawnInterval && numOfTotalSpawned < spawnsThisWave)
        {
            // If player isnt dead
            if (!PlayerHealth.isPlayerDead)
            {
            int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            // Spawn mallow
            GameObject mallow = Instantiate(mallowPrefab, spawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
            // Increases count of spawns
            numOfTotalSpawned++;
            timeOfLastSpawn = Time.timeSinceLevelLoad;
            }
        }

       
        // Spawn target was reached
        if (numOfTotalSpawned == spawnsThisWave)
        {
           
            // If there aren't any more marshmallows alive
            if (GameObject.Find("Mallow(Clone)") == null)
            {


                // Progress to next wave
                enemyProgression.waveNum += 1;
                waveNum = enemyProgression.waveNum;
                managerOfUI.NewWave((float)waveNum);
                Debug.Log(waveNum);
                // Reset number of spawned because its not needed anymore for wave 1.
                numOfTotalSpawned = 0;
            }
        }
	}
}
