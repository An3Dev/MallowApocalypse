using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVisibility : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject == GameObject.Find("Mallow(Clone)"))
        {
            Destroy(transform.gameObject, 0.01f);
        }

        if (collision.collider.gameObject == GameObject.Find("Ground"))
        {
            Destroy(transform.gameObject, 0.0f);
        }

    }
}
