using UnityEngine;

public class Variables{

    // Chocolate gun info
    public static string chocolateGunName = "Chocolate Blaster";
    public static int chocolateBulletDamage = 25;
    public static int chocolateGunFireRate = 300;
    public static float chocolateGunReloadTime = 1;
    public static int chocolateGunBulletsPerReload = 10;

    // Player info
    public static int playerHealth = 500;

    // Mallow info
    public static int mallowHealth = 100;
    public static int mallowDamage = 50;
    public static float speedIncreasePerWave = 1.5f;
    public static float accelerationIncreasePerWave = 1.5f;
    public static float speedIncreasePerDay =2;
    public static float accelerationIncreasePerDay = 2;
    public static float spawnInterval = 5; // Spawns per second

    //Wall info
    public static float wallMovementPerWave = 10f;

    //Wave info
    public static int firstWaveMallowSpawns = 10;
    public static float mallowSpawnIncreasePerWave = 1.2f;


}
