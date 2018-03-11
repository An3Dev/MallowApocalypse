using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {   
        // If near player
        if(other.tag == "Player")
        {
            Debug.Log("Damage");
            playerHealth.TakeDamage(Variables.mallowDamage);
        }
    }
}
