using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public static bool isPlayerDead;

    [SerializeField]
    Animator playerAnimator;

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
        }
	}

    public void TakeDamage(float damage)
    {
        if (!isPlayerDead)
        {
            health -= damage;
        }
    }
}
