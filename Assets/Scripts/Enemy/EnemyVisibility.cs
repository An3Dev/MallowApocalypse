
using UnityEngine;

public class EnemyVisibility : MonoBehaviour {

    [SerializeField]
    ParticleSystem effect;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        effect.transform.rotation = Quaternion.Euler(Vector3.zero);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == GameObject.Find("ChocolateBullet 1(Clone)"))
        {
            effect.transform.position = collision.contacts[0].point;
            Time.timeScale = 0;
            // In the future make there be less blood the lower the bullet hits the enemy.
            //effect.emission.rateOverTime = 5000f;
            effect.Play();
            Destroy(effect, 3);
            
        }
    }

    private void LateUpdate()
    {
        effect.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        
    }
}
