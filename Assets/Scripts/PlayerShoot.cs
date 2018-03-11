using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform bulletSpawn;

    [SerializeField]
    float fireRate = 200; // Shots per Minute

    float timeSinceLastFire = 0;

    [SerializeField]
    float bulletForce = 1000f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton("Fire1"))
        {
            // If fire rate time passed
            // Shoots 1 shot per second
            if (Time.timeSinceLevelLoad - timeSinceLastFire > fireRate / 60)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation * Quaternion.Euler(new Vector3(90, 0, 0)));
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddRelativeForce(transform.up * bulletForce * Time.deltaTime);
                timeSinceLastFire = Time.timeSinceLevelLoad;
                Destroy(bullet, 5f);
            }
        }
	}
}
