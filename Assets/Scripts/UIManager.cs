using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    Text moneyText;

    [SerializeField]
    Slider healthBar;

    [SerializeField]
    Slider ammoBar;

    [SerializeField]
    float healthBarTransitionSmoothness;

    [SerializeField]
    float ammoBarTransitionSmoothness;

    [SerializeField]
    Text waveText;

    [SerializeField]
    Animator UIAnimator;


    float targetHealth = 100;

    float targetAmmo = 100;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        // Sets money text
        moneyText.text = "$" + Variables.money;

        // change health bar smoothly
        if (healthBar.value != targetHealth)
        {
            healthBar.value = Mathf.Lerp(healthBar.value, targetHealth, healthBarTransitionSmoothness * Time.deltaTime);
        }

        // No smooth change
        if (ammoBar.value != targetAmmo)
        {
            ammoBar.value = targetAmmo;
        }

        
    }

    public void ChangeHealthBar(float newValue)
    {
        // Converts to percentage and temporarily saves for smooth transition
        targetHealth = newValue / (Variables.playerHealth / 100);
    }

    public void ChangeAmmoBar(float newValue)
    {
        targetAmmo = newValue / ((float) Variables.chocolateGunBulletsPerReload / 100);
        
    }

    public void NewWave(float waveNum) 
    {
        waveText.text = "Wave " + (int) waveNum;

        Debug.LogError(waveText.text);
        
        UIAnimator.SetTrigger("NewWave");
    }
}
