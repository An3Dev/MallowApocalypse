using UnityEngine;

public class BulletDamage : MonoBehaviour {

    EnemyHealth enemyStuff;

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
            enemyStuff = collision.collider.GetComponent<EnemyHealth>();
            enemyStuff.TakeDamage(Variables.chocolateBulletDamage);
        }
    }
}
