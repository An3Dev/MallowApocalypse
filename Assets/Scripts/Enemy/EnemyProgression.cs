using UnityEngine;
using UnityEngine.AI;

public class EnemyProgression : MonoBehaviour {

    
   

    NavMeshAgent agent;

    bool reachedTopSpeed = false, reachedTopAcceleration = false, reachedMinSpawnInterval = false, reachedMaxDamage = false, reachedMaxHealth = false;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent> ();
    }
	
	// Update is called once per frame
	void Update () {

        
        // Mallow speed increase
        if (agent.speed < Variables.mallowTopSpeed)
        {
            agent.speed = Variables.speedIncreasePerWave * (GameController.waveNum - 1) + Variables.mallowBeginningSpeed;
           
        }
        if (agent.speed >= Variables.mallowTopSpeed)
        {
            reachedTopSpeed = true;
        }
        if (reachedTopSpeed)
        {
            agent.speed = Variables.mallowTopSpeed;
        }

        // Mallow acceleration increase
        if (agent.acceleration < Variables.mallowTopAcceleration)
        {
            agent.acceleration = Variables.accelerationIncreasePerWave * (GameController.waveNum - 1) + Variables.mallowBeginningAcceleration;
        }
        if (agent.acceleration == Variables.mallowTopAcceleration)
        {
            reachedTopAcceleration = true;
        }
        if (reachedTopAcceleration)
        {
            agent.acceleration = Variables.mallowBeginningAcceleration;
        }

        // Mallow spawn rate increase

        // if minimun spawn interval hasn't been reached
        if (Variables.spawnInterval > Variables.minSpawnInterval)
        {
            Variables.spawnInterval = Variables.spawnIntervalDecrease * (GameController.waveNum - 1) + Variables.beginningSpawnInterval;
        }

        if (Variables.spawnInterval <= Variables.minSpawnInterval)
        {
            reachedMinSpawnInterval = true;
        }
        if (reachedMinSpawnInterval)
        {
            Variables.spawnInterval = Variables.minSpawnInterval;
        }

        // Mallow damage increase

        // if mallow damage is not at it's max
        if (Variables.mallowDamage < Variables.mallowMaxDamage)
        {
            Variables.mallowDamage = Variables.mallowDamageIncrease * (GameController.waveNum - 1) + Variables.mallowBeginningDamage;
        }

        if (Variables.mallowDamage >= Variables.mallowMaxDamage)
        {
            reachedMaxDamage = true;
        }
        if (reachedMaxDamage)
        {
            Variables.mallowDamage = Variables.mallowMaxDamage;
        }

        // Mallow health increase

        // if mallow health is not at it's max
        if (Variables.mallowHealth < Variables.mallowMaxHealth)
        {
            Variables.mallowHealth = Variables.mallowHealthIncrease * (GameController.waveNum - 1) + Variables.mallowBeginningHealth;
        }

        if (Variables.mallowHealth >= Variables.mallowMaxHealth)
        {
            reachedMaxHealth = true;
        }
        if (reachedMaxHealth)
        {
            Variables.mallowHealth = Variables.mallowMaxHealth;
        }
    }
}
