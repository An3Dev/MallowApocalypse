using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public static bool isPlayerDead;

    [SerializeField]
    Animator playerAnimator;

    [SerializeField]
    UIManager managerOfUI;

    [SerializeField]
    GameObject gun;

    [SerializeField]
    Animator UIAnimator;

    [SerializeField]
    GameController gameController;

    [SerializeField]
    SphereCollider playerCollider;

    public static float health = Variables.beginningPlayerHealth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            isPlayerDead = true;
        }

        if (isPlayerDead)
        {
            
            playerAnimator.SetTrigger("Died");
            // Makes gun independent. No longer part of player
            gun.transform.parent = null;

            // Adds rigidbody with gravity to gun so it falls
            if (gun.GetComponent<Rigidbody>() == null)
            {
                gun.AddComponent<Rigidbody>();
            }
            playerCollider.enabled = false;
            

            UIAnimator.SetTrigger("GameOver");

            //// Change value of health bar if damage clip finished
            //if (UIAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            //{
            //    Debug.Log("Hello");
            //    managerOfUI.ChangeHealthBar(health);
            //}
        }

        if (isPlayerDead && Input.GetMouseButtonDown(0))
        {
            gameController.Restart();
        }
	}

    public void TakeDamage(float damage)
    {
        if (!isPlayerDead)
        {
            health -= damage;
            UIAnimator.SetTrigger("Damaged");
            // Change value of health bar
            managerOfUI.ChangeHealthBar(health);

        }
    }
        
}
