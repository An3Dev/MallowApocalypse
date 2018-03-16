using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public static bool isPlayerDead;

    [SerializeField]
    Animator playerAnimator;

    [SerializeField]
    UIManager managerOfUI;

    [SerializeField]
    GameObject gun;

    [SerializeField]
    Animator UIAnimator;

    float health = Variables.playerHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 1)
        {
            isPlayerDead = true;
        }

        if (isPlayerDead)
        {
            
            playerAnimator.SetTrigger("Died");
            // Makes gun independent. No longer part of player
            gun.transform.parent = null;
            // Adds gravity to gun so it falls
            gun.AddComponent<Rigidbody>();

            UIAnimator.SetTrigger("GameOver");

        }

        if (isPlayerDead && Input.GetMouseButtonDown(0))
        {
            RestartLevel();
        }
	}

    public void TakeDamage(float damage)
    {
        if (!isPlayerDead)
        {
            health -= damage;
            UIAnimator.SetTrigger("Damaged");
            // Change value of health bar
            managerOfUI.ChangeHealthBar(health);
            
        }
    }

    public void RestartLevel()
    {
        ResetStaticVars();
        SceneManager.LoadScene("Main");
    }

    void ResetStaticVars()
    {
        // Chocolate gun info
        Variables.chocolateGunName = "Chocolate Blaster";
        Variables.chocolateBulletDamage = 50;
        Variables.chocolateGunFireRate = 60;
        Variables.chocolateGunReloadTime = 1;
        Variables.chocolateGunBulletsPerReload = 5;

        // Player info
        Variables.playerHealth = 500;

        // Mallow info
        Variables.mallowHealth = 100;
        Variables.mallowDamage = 50;
        Variables.mallowBeginningSpeed = 3.5f;
        Variables.mallowBeginningAcceleration = 8;
        Variables.speedIncreasePerWave = 1.5f;
        Variables.accelerationIncreasePerWave = 1.5f;
        Variables.speedIncreasePerDay = 2;
        Variables.accelerationIncreasePerDay = 2;
        Variables.spawnInterval = 5; // Spawns per second
        Variables.mallowKillRewardValue = 1; // In dollars

        //Wall info
        Variables.wallMovementPerWave = 10f;

        //Wave info
        Variables.firstWaveMallowSpawns = 10;
        Variables.mallowSpawnIncreasePerWave = 1.2f;

        // Money
        Variables.money = 0;
    }
}
