using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisibility : MonoBehaviour {

    [SerializeField]
    ParticleSystem effect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == GameObject.Find("ChocolateBullet 1(Clone)"))
        {
            effect.transform.position = collision.contacts[0].point;
            effect.Play();
        }
    }
}
