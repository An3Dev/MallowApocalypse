﻿using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    NavMeshAgent agent;

    Animator animator;

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
        agent.enabled = false;
        animator.SetTrigger("Died");
        // Destroys itself
        Destroy(transform.gameObject, 1);
    }


    public void DieAttacking()
    {
        animator.SetTrigger("DieAttacking");
        agent.enabled = false;
        // Destroys itself
        Destroy(transform.gameObject, 1.5f);
    }
}
