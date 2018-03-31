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
    public static int bulletsLeftInMagazine;

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
        bulletsLeftInMagazine = Variables.magazineCapacity;
        fireRate = Variables.chocolateGunFireRate;
        reloadTime = 0;
        bulletForce = Variables.bulletForce;
	}

    // Update is called once per frame
    void FixedUpdate() {
        fireRate = Variables.chocolateGunFireRate;
        //if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        //{
        //    if (Input.GetButton("Fire1"))
        //    {
        //        // If mouse isn't over ui then shoot 
        //        if (!EventSystem.current.IsPointerOverGameObject())
        //        {
        //            // if needs to reload
        //            if (bulletsLeftInMagazine < 1)
        //            {
        //                Reload();

        //            }

        //            // If fire rate time passed
        //            // Shoots 1 shot per second
        //            if (Time.timeSinceLevelLoad - timeSinceLastFire > 60 / fireRate && !isReloading && !PlayerHealth.isPlayerDead)
        //            {

                        
        //                int x = Screen.width / 2;
        //                int y = Screen.height / 2;

        //                Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
        //                RaycastHit hit;

        //                if (Physics.Raycast(ray, out hit))
        //                {
        //                    GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(Vector3.zero));
        //                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
        //                    // Apply force
        //                    bullet.transform.LookAt(hit.point);
        //                    rb.AddRelativeForce(Camera.main.transform.forward * bulletForce * Time.fixedDeltaTime);
                            
                            

        //                    if (gunSmokeEnabled)
        //                    {
        //                        gunSmoke.Play();
        //                    }


        //                    if (audioEnabled)
        //                    {
        //                        playerAudio.clip = gunShotsClip;
        //                        playerAudio.volume = 0.4f;
        //                        playerAudio.Play();
        //                    }
        //                    timeSinceLastFire = Time.timeSinceLevelLoad;
        //                    // Subtracts bullets from magazine
        //                    bulletsLeftInMagazine -= 1;
        //                    managerOfUI.ChangeAmmoBar(Mathf.Round(bulletsLeftInMagazine));

        //                    // Destroys bullet after 5 seconds
        //                    Destroy(bullet, 5f);
        //                }

                        
        //            }
        //        }

        //    }


        //    if (Input.GetButton("Reload"))
        //    {
        //        Reload();
        //    }
        //}

        
    }

    void Shoot()
    {
        //if (Application.platform == RuntimePlatform.Android)
        //{
        // if needs to reload
        if (bulletsLeftInMagazine < 1)
        {
            Reload();

        }

        // If fire rate time passed
        // Shoots 1 shot per second
        if (Time.timeSinceLevelLoad - timeSinceLastFire > 60 / fireRate && !isReloading && !PlayerHealth.isPlayerDead)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(Vector3.zero));
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                // Apply force
                bullet.transform.LookAt(hit.point);
                rb.AddRelativeForce(Camera.main.transform.forward * bulletForce * Time.fixedDeltaTime);



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
            //}
          
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
            bulletsLeftInMagazine = Variables.magazineCapacity;
            isReloading = false;
            managerOfUI.ChangeAmmoBar(Mathf.Round(bulletsLeftInMagazine));
        }
    }
}
