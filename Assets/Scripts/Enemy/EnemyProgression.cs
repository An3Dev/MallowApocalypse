using UnityEngine;
using UnityEngine.AI;

public class EnemyProgression : MonoBehaviour {

    
   

    NavMeshAgent agent;

    bool reachedTopSpeed = false, reachedTopAcceleration = false;

	// Use this for initialization
	void Start () {
        

        agent = GetComponent<NavMeshAgent> ();

        
        
    }
	
	// Update is called once per frame
	void Update () {

        
        // Mallow speed increase
        if (agent.speed < Variables.mallowTopSpeed)
        {
            agent.speed = 0.25f * (GameController.waveNum - 1) + Variables.mallowBeginningSpeed;
           
        }
        if (agent.speed >= Variables.mallowTopSpeed)
        {
            reachedTopSpeed = true;
        }
        if (reachedTopSpeed)
        {
            agent.speed = Variables.mallowTopSpeed;
        }

        // Mallow acceleration increase
        if (agent.acceleration < Variables.mallowTopAcceleration)
        {
            agent.acceleration = 0.25f * (GameController.waveNum - 1) + Variables.mallowBeginningAcceleration;
        }
        if (agent.acceleration == Variables.mallowTopAcceleration)
        {
            reachedTopAcceleration = true;
        }
        if (reachedTopAcceleration)
        {
            agent.acceleration = Variables.mallowBeginningAcceleration;
        }

    }
}
