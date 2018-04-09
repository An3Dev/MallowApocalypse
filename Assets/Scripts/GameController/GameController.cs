using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static int waveNum = 1;
    bool allowRestart = false;

    public float timeScale = 1;

    // Use this for initialization
    void Start () {
        waveNum = Variables.waveNum;
    }
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = timeScale;

        // if user taps after he dies
		if (allowRestart && Input.GetMouseButtonDown(0))
        {
            Restart();
        }


	}

    public void Restart()
    {

        if (allowRestart)
        {
            PlayerHealth.isPlayerDead = false;
            ResetStaticVariables();
            SceneManager.LoadScene("Main");
        }
    }

    public void AllowRestart()
    {

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
        Variables.chocolateBulletDamage = 50;
        Variables.chocolateGunFireRate = 60;
        Variables. chocolateGunReloadTime = 1;
        Variables.magazineCapacity = 5;
        Variables.maxMagazineCapacity = 100;
        Variables. bulletForce = 10000;
        PlayerShoot.bulletsLeftInMagazine = Variables.magazineCapacity;

        // Player info
        Variables.beginningPlayerHealth = 300;

        // Mallow info
        Variables.mallowHealth = 100;
        Variables.mallowBeginningHealth = 100;
        Variables.mallowHealthIncrease = 25;
        Variables.mallowMaxHealth = 300;
        Variables.mallowDamage = 50;
        Variables.mallowBeginningDamage = 50;
        Variables.mallowDamageIncrease = 10;
        Variables.mallowMaxDamage = 200;
        Variables. mallowBeginningSpeed = 3f;
        Variables. mallowBeginningAcceleration = 6;
        Variables. mallowTopSpeed = 7;
        Variables. mallowTopAcceleration = 15;
        Variables. speedIncreasePerWave = .5f;
        Variables. accelerationIncreasePerWave = .5f;
        Variables. spawnInterval = 5f; // Spawns per second
        Variables. spawnIntervalDecrease = .25f; // Spawn decrease every wave
        Variables. minSpawnInterval = 1f;
        Variables. beginningSpawnInterval = 5;
        Variables. mallowKillRewardValue = 1; // In dollars

        //Wall info
        //Variables. wallMovementPerWave = 10f;

        //Wave info
        Variables.firstWaveMallowSpawns = 10;
        Variables. mallowSpawnIncreasePerWave = 5;
        Variables.waveNum = 1;

        // Money
        Variables. money = 0;

        // Upgrade info
        Variables.fireRateBeginningCost = 10;
        Variables.fireRateIncreaseAmount = 10;
        Variables.fireRateCostIncreaseAmount = 10;
        Variables.maxFireRate = 500;
        Variables.playerHealthBeginningCost = 20;
        Variables.playerHealthIncreaseAmount = 20;
        Variables.playerHealthCostIncreaseAmount = 20;
        Variables.maxPlayerHealth = 300;
        Variables.bulletsPerReloadBeginningCost = 10;
        Variables.bulletsPerReloadIncreaseAmount = 5;
        Variables.bulletsPerReloadCostIncreaseAmount = 10;
        PlayerHealth.health = Variables.beginningPlayerHealth;
        Variables.magazineCapacityBeginningCost = 20;
        Variables.magazineCapacityIncreaseAmount = 5;
        Variables.magazineCapacityCostIncreaseAmount = 10;
}
}
