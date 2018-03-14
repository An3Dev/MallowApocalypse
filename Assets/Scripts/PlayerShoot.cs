using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform bulletSpawn;

    [SerializeField]
    ParticleSystem gunSmoke;

    [SerializeField]
    bool gunSmokeEnabled;

    [SerializeField]
    float fireRate; // Shots per Minute

    [SerializeField]
    float bulletForce;

    float timeSinceLastFire = 0;

    [SerializeField]
    int bulletsLeftInMagazine;

    [SerializeField]
    Animator playerAnimator;

    [SerializeField]
    AudioSource playerAudio;

    [SerializeField]
    AudioClip gunShotsClip;

    [SerializeField]
    AudioClip gunReloadClip;

    bool isReloading;
    float reloadStartTime;
    float reloadTime;


	// Use this for initialization
	void Start () {
        bulletsLeftInMagazine = Variables.chocolateGunBulletsPerReload;
        reloadTime = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton("Fire1"))
        {
            // if needs to reload
            if (bulletsLeftInMagazine < 1 )
            {
                Reload();
                
            }

            // If fire rate time passed
            // Shoots 1 shot per second
            if (Time.timeSinceLevelLoad - timeSinceLastFire > 60 / fireRate && !isReloading && !PlayerHealth.isPlayerDead)
            {
                
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation * Quaternion.Euler(90, 0, 0));
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                // Apply force
                rb.AddForce(Camera.main.transform.forward * bulletForce * Time.fixedDeltaTime);
                if (gunSmokeEnabled)
                    gunSmoke.Play();
                playerAudio.clip = gunShotsClip;
                playerAudio.Play();
                timeSinceLastFire = Time.timeSinceLevelLoad;
                bulletsLeftInMagazine -= 1;
                Destroy(bullet, 5f);
            }
        }

        if (Input.GetButton("Jump"))
        {
            Reload();
        }

        if (isReloading)
        {
            Reload();
        }
    }

    void Reload()
    {
        if (!isReloading)
        {
            isReloading = true;
            reloadStartTime = Time.timeSinceLevelLoad;
            reloadTime = Variables.chocolateGunReloadTime;
            playerAnimator.SetTrigger("Reload");
            playerAudio.clip = gunReloadClip;
            playerAudio.Play();
        }

        // Finished reloading
        if (Time.timeSinceLevelLoad - reloadStartTime >= reloadTime)
        {
            // Replenish bullets
            bulletsLeftInMagazine = Variables.chocolateBulletDamage;
            isReloading = false;
        }
    }
}
