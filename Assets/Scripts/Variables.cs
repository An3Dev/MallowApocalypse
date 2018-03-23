﻿using UnityEngine;

public class Variables{

    // IMPORTANT!!!!
    // If you change a variable here you need to change it in game controller

    // Chocolate gun info
    public static string chocolateGunName = "Chocolate Blaster";
    public static int chocolateBulletDamage = 50;
    public static int chocolateGunFireRate = 500;
    public static float chocolateGunReloadTime = 1;
    public static int chocolateGunBulletsPerReload = 100;

    // Player info
    public static int playerHealth = 200;

    // Mallow info
    public static int mallowHealth = 100;
    public static int mallowDamage = 50;
    public static float mallowBeginningSpeed = 3.5f;
    public static float mallowBeginningAcceleration = 8;
    public static float mallowTopSpeed = 7;
    public static float mallowTopAcceleration = 15;
    public static float speedIncreasePerWave = 2f;
    public static float accelerationIncreasePerWave = 2f;
    public static float spawnInterval = 1f; // Spawns per second
    public static float mallowKillRewardValue = 1; // In dollars

    //Wall info
    public static float wallMovementPerWave = 10f;

    //Wave info
    public static int firstWaveMallowSpawns = 10;
    public static float mallowSpawnIncreasePerWave = 1.25f;
    public static int waveNum = 1;

    // Money
    public static float money = 0;


}
