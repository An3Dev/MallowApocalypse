using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private float health;

    bool isDead;

    EnemyMovement movement;

	// Use this for initialization
	void Start () {
        health = Variables.mallowHealth;
        movement = GetComponent<EnemyMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        // if still alive
		if (health < 1 && !isDead && !PlayerHealth.isPlayerDead)
        {
            isDead = true;
        }

        if (isDead)
        {
            Die();
            // Destroys this script instance from the game object
            Destroy(this);
        }
	}

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void Die()
    {
        movement.Die();
    }
}
