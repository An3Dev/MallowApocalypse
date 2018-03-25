using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    NavMeshAgent agent;

    Animator animator;

    bool startedAttacking = false;

	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();
        // Makes Mallows move toward player
        agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;

        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerHealth.isPlayerDead)
        {
            agent.enabled = false;
            animator.SetTrigger("Celebrate");
        }
	}

    public void Die()
    {
        animator.SetTrigger("Died");
        agent.enabled = false;
        // Destroys itself
        Destroy(transform.gameObject, 1);
        IncreaseMoney(Variables.mallowKillRewardValue);
    }


    public void DieAttacking()
    {
        animator.SetTrigger("DieAttacking");
        agent.enabled = false;
        // Destroys itself
        Destroy(transform.gameObject, 0.35f);
        IncreaseMoney(Variables.mallowKillRewardValue);

    }

    // Increases the money the player has
    void IncreaseMoney(float moneyIncrease)
    {
        Variables.money += moneyIncrease;
    }
}
