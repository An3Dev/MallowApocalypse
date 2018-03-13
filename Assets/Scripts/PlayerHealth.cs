using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public static bool isPlayerDead;

    [SerializeField]
    Animator playerAnimator;

    [SerializeField]
    Slider healthBar;

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
	}

    public void TakeDamage(float damage)
    {
        if (!isPlayerDead)
        {
            health -= damage;
            // Convert to percentage
            healthBar.value = health / (Variables.playerHealth / 100);
            UIAnimator.SetTrigger("Damaged");
        }
    }
}
