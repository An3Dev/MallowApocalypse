using UnityEngine;

public class BulletDamage : MonoBehaviour {

    EnemyHealth enemyHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Enemy")

        {
            // Assigns script
            enemyHealth = collision.collider.GetComponent<EnemyHealth>();

            // If there is an enemy health script(It's removed when mallow's health is 0)
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(Variables.chocolateBulletDamage);
            }
        }
    }
}
