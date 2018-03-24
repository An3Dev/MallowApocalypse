using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    PlayerHealth playerHealth;
    EnemyMovement enemyMovement;

	// Use this for initialization
	void Start () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        enemyMovement = GetComponent<EnemyMovement>();
	}
    private void OnCollisionEnter(Collision collision)
    {   
        // If near player
        if(collision.collider.tag == "Player")
        {
            enemyMovement.DieAttacking();
            playerHealth.TakeDamage(Variables.mallowDamage);
        }
    }
}
