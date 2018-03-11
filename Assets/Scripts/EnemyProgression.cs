using UnityEngine;
using UnityEngine.AI;

public class EnemyProgression : MonoBehaviour {

    public static int waveNum = 1;
    public static int dayNum = 1;

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent> ();

        agent.speed = agent.speed * (Mathf.Pow(Variables.speedIncreasePerWave, waveNum - 1));
        agent.speed = agent.speed * (Mathf.Pow(Variables.speedIncreasePerDay, dayNum - 1));
        agent.acceleration = agent.acceleration * (Mathf.Pow(Variables.accelerationIncreasePerWave, waveNum - 1));
        agent.acceleration = agent.acceleration * (Mathf.Pow(Variables.accelerationIncreasePerDay, dayNum - 1));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
