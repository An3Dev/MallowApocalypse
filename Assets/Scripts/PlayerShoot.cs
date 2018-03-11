using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform bulletSpawn;

    [SerializeField]
    float fireRate; // Shots per Minute

    float timeSinceLastFire = 0;

    [SerializeField]
    float bulletForce;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton("Fire1"))
        {
            // If fire rate time passed
            // Shoots 1 shot per second
            if (Time.timeSinceLevelLoad - timeSinceLastFire > 60 / fireRate)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation * Quaternion.Euler(90, 0, 0));
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                // Apply force
                rb.AddForce(Camera.main.transform.forward * bulletForce * Time.fixedDeltaTime);
                timeSinceLastFire = Time.timeSinceLevelLoad;
                Destroy(bullet, 5f);
            }
        }
	}
}
