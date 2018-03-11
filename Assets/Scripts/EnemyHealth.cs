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
		if (health < 1 && !isDead)
        {
            isDead = true;
        }

        if (isDead)
        {
            movement.Die();
        }
	}

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
