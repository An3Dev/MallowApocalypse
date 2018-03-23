using System.Collections;
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

    void ResetStaticVariables()
    {
        // Chocolate gun info
        Variables.chocolateGunName = "Chocolate Blaster";
        Variables.chocolateBulletDamage = 50;
        Variables.chocolateGunFireRate = 500;
        Variables.chocolateGunReloadTime = 1;
        Variables.chocolateGunBulletsPerReload = 100;

        // Player info
        Variables.playerHealth = 200;

        // Mallow info
        Variables.mallowHealth = 100;
        Variables.mallowDamage = 50;
        Variables.mallowBeginningSpeed = 3.5f;
        Variables.mallowBeginningAcceleration = 8;
        Variables.mallowTopSpeed = 7;
        Variables.mallowTopAcceleration = 15;
        Variables.speedIncreasePerWave = 2f;
        Variables.accelerationIncreasePerWave = 2f;
        Variables.spawnInterval = 1f; // Spawns per second
        Variables. mallowKillRewardValue = 1; // In dollars

        //Wall info
        Variables.wallMovementPerWave = 10f;

        //Wave info
        Variables.firstWaveMallowSpawns = 10;
        Variables.mallowSpawnIncreasePerWave = 1.25f;
        Variables.waveNum = 1;

        // Money
        Variables.money = 0;
    }
}
