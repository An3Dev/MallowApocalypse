using UnityEngine;
using UnityEngine.EventSystems;

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
    bool audioEnabled;

    [SerializeField]
    float fireRate; // Shots per Minute

    float bulletForce;

    float timeSinceLastFire = 0;

    [SerializeField]
    public int bulletsLeftInMagazine;

    [SerializeField]
    Animator playerAnimator;

    [SerializeField]
    AudioSource playerAudio;

    [SerializeField]
    AudioClip gunShotsClip;

    [SerializeField]
    AudioClip gunReloadClip;

    [SerializeField]
    UIManager managerOfUI;

    bool isReloading;
    float reloadStartTime;
    float reloadTime;


	// Use this for initialization
	void Start () {
        bulletsLeftInMagazine = Variables.chocolateGunBulletsPerReload;
        fireRate = Variables.chocolateGunFireRate;
        reloadTime = 0;
        bulletForce = Variables.bulletForce;
	}

    // Update is called once per frame
    void FixedUpdate() {
        fireRate = Variables.chocolateGunFireRate;
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetButton("Fire1"))
            {
                // If mouse isn't over ui then shoot
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    // if needs to reload
                    if (bulletsLeftInMagazine < 1)
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
                        {
                            gunSmoke.Play();
                        }


                        if (audioEnabled)
                        {
                            playerAudio.clip = gunShotsClip;
                            playerAudio.volume = 0.4f;
                            playerAudio.Play();
                        }
                        timeSinceLastFire = Time.timeSinceLevelLoad;
                        // Subtracts bullets from magazine
                        bulletsLeftInMagazine -= 1;
                        managerOfUI.ChangeAmmoBar(Mathf.Round(bulletsLeftInMagazine));

                        // Destroys bullet after 5 seconds
                        Destroy(bullet, 5f);
                    }
                }

            }


            if (Input.GetButton("Reload"))
            {
                Reload();
            }
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0 && Input.GetTouch(1).position.x > Screen.width / 4 * 3 || Input.GetTouch(0).position.x > Screen.width / 4 * 3)
            {
                // If mouse isn't over ui then shoot
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    // if needs to reload
                    if (bulletsLeftInMagazine < 1)
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
                        {
                            gunSmoke.Play();
                        }


                        if (audioEnabled)
                        {
                            playerAudio.clip = gunShotsClip;
                            playerAudio.volume = 0.4f;
                            playerAudio.Play();
                        }
                        timeSinceLastFire = Time.timeSinceLevelLoad;
                        // Subtracts bullets from magazine
                        bulletsLeftInMagazine -= 1;
                        managerOfUI.ChangeAmmoBar(Mathf.Round(bulletsLeftInMagazine));

                        // Destroys bullet after 5 seconds
                        Destroy(bullet, 5f);
                    }
                }

            }



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
            if (audioEnabled)
            {
                playerAudio.volume = 1;
                playerAudio.clip = gunReloadClip;
                playerAudio.Play();
            }
        }

        // Finished reloading
        if (Time.timeSinceLevelLoad - reloadStartTime >= reloadTime)
        {
            // Replenish bullets
            bulletsLeftInMagazine = Variables.chocolateGunBulletsPerReload;
            isReloading = false;
            managerOfUI.ChangeAmmoBar(Mathf.Round(bulletsLeftInMagazine));
        }
    }
}
