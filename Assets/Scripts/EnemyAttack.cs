using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {   
        // If near player
        if(other.tag == "Player")
        {

        }
    }
}
