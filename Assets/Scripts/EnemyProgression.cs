using UnityEngine;
using UnityEngine.AI;

public class EnemyProgression : MonoBehaviour {


    public int waveNum;

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        waveNum = Variables.waveNum;

        agent = GetComponent<NavMeshAgent> ();

        
        
    }
	
	// Update is called once per frame
	void Update () {
        agent.speed = Variables.mallowBeginningSpeed * (Mathf.Pow(Variables.speedIncreasePerWave, waveNum - 1));
        agent.acceleration = Variables.mallowBeginningAcceleration * (Mathf.Pow(Variables.accelerationIncreasePerWave, waveNum - 1));
    }
}
