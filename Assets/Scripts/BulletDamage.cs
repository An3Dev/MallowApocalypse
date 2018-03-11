using UnityEngine;

public class BulletDamage : MonoBehaviour {

    EnemyStuff enemyStuff;

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
            enemyStuff = collision.collider.GetComponent<EnemyStuff>();
            enemyStuff.TakeDamage(Variables.chocolateBulletDamage);
        }
    }
}
