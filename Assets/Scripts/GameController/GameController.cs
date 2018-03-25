﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static int waveNum = 1;

    // Use this for initialization
    void Start () {
        waveNum = Variables.waveNum;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Restart()
    {
        PlayerHealth.isPlayerDead = false;
        ResetStaticVariables();
        SceneManager.LoadScene("Main");
    }

    void SlowDownTime()
    {
        Time.timeScale = 0;
    }
    void SetNormalTime()
    {
        Time.timeScale = 1;
    }

    void ResetStaticVariables()
    {
         // Chocolate gun info
        Variables. chocolateGunName = "Chocolate Blaster";
        Variables. chocolateBulletDamage = 50;
        Variables. chocolateGunFireRate = 60;
        Variables. chocolateGunReloadTime = 1;
        Variables. chocolateGunBulletsPerReload = 5;
        Variables.bulletForce = 10000;

        // Player info
        Variables. playerHealth = 300;

        // Mallow info
        Variables. mallowHealth = 100;
        Variables.mallowBeginningHealth = 100;
        Variables.mallowHealthIncrease = 25;
        Variables.mallowMaxHealth = 300;
        Variables. mallowDamage = 50;
        Variables.mallowBeginningDamage = 50;
        Variables.mallowDamageIncrease = 10;
        Variables.mallowMaxDamage = 200;
        Variables. mallowBeginningSpeed = 3f;
        Variables. mallowBeginningAcceleration = 6;
        Variables. mallowTopSpeed = 7;
        Variables. mallowTopAcceleration = 15;
        Variables. speedIncreasePerWave = .5f;
        Variables. accelerationIncreasePerWave = .5f;
        Variables. spawnInterval = 3f; // Spawns per second
        Variables.spawnIntervalDecrease = .25f; // Spawn decrease every wave
        Variables. minSpawnInterval = 1f;
        Variables.beginningSpawnInterval = 5;
        Variables. mallowKillRewardValue = 1; // In dollars

        ////Wall info
        //Variables. wallMovementPerWave = 10f;

        //Wave info
        Variables. firstWaveMallowSpawns = 10;
        Variables. mallowSpawnIncreasePerWave = 5f;
        Variables. waveNum = 1;

        // Money
        Variables. money = 0;

        // Upgrade info
        Variables. fireRateBeginningCost = 10;
        Variables. fireRateIncreaseAmount = 10;
    }
}
