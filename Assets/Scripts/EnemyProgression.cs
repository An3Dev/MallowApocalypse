using UnityEngine;
using UnityEngine.AI;

public class EnemyProgression : MonoBehaviour {

    public static int waveNum = 1;
    public static int dayNum = 1;

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent.speed = agent.speed * (Mathf.Pow(Variables.speedIncreasePerWave, waveNum));
        agent.speed = agent.speed * (Mathf.Pow(Variables.speedIncreasePerDay, dayNum));
        agent.acceleration = agent.acceleration * (Mathf.Pow(Variables.accelerationIncreasePerWave, waveNum));
        agent.acceleration = agent.acceleration * (Mathf.Pow(Variables.accelerationIncreasePerDay, dayNum));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
