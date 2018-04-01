using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {


    // Fire rate
    [SerializeField]
    Text fireRateCostText;

    [SerializeField]
    Button fireRateCostButton;

    [SerializeField]
    Text fireRateIncreasePreview;

    int fireRateCurrentCost;

    // Player health
    [SerializeField]
    Text healthUpgradeCostText;

    [SerializeField]
    Button healthUpgradeCostButton;

    [SerializeField]
    Text healthIncreasePreview;

    int healthUpgradeCurrentCost;

    // Ammo Magazine capacity
    [SerializeField]
    Text magazineUpgradeCostText;

    [SerializeField]
    Button magazineUpgradeCostButton;

    [SerializeField]
    Text magazineIncreasePreview;

    int magazineUpgradeCurrentCost;


    [SerializeField]
    UIManager managerOfUI;

    

    // Use this for initialization
    void Start () {
        fireRateCurrentCost = Variables.fireRateBeginningCost;
        healthUpgradeCurrentCost = Variables.playerHealthBeginningCost;
        magazineUpgradeCurrentCost = Variables.magazineCapacityBeginningCost;
	}
	
	// Update is called once per frame
	void Update () {
        // Fire rate
        // Change button text to current cost of fireRate
        fireRateCostText.text = "$" + fireRateCurrentCost;

        if (Variables.money < fireRateCurrentCost || Variables.chocolateGunFireRate >= Variables.maxFireRate)
        {
            fireRateCostButton.interactable = false;
        } else
        {
            fireRateCostButton.interactable = true;
        }

        // Item is maxed out
        if (Variables.chocolateGunFireRate >= Variables.maxFireRate)
        {
            Variables.chocolateGunFireRate = Variables.maxFireRate;
            fireRateIncreasePreview.text = "MAX";
            fireRateCostText.text = "$Gazillion";
        }
        else if(Variables.chocolateGunFireRate < Variables.maxFireRate)
        {
            fireRateIncreasePreview.text = Variables.chocolateGunFireRate + " + " + Variables.fireRateIncreaseAmount + " / minute";
        }

        // Health
        healthUpgradeCostText.text = "$" + healthUpgradeCurrentCost;

        // Disable button if player doesn't have enough money or item is maxed out
        if (Variables.money < healthUpgradeCurrentCost || PlayerHealth.health >= Variables.maxPlayerHealth)
        {
            healthUpgradeCostButton.interactable = false;
        }
        else
        {
            healthUpgradeCostButton.interactable = true;
        }

        if (PlayerHealth.health >= Variables.maxPlayerHealth)
        {
            PlayerHealth.health = Variables.maxPlayerHealth;
            healthIncreasePreview.text = "MAX";
            healthUpgradeCostText.text = "$Gazillion";
        }
        else if (PlayerHealth.health < Variables.beginningPlayerHealth)
        {
            healthIncreasePreview.text = PlayerHealth.health + " + " + Variables.playerHealthIncreaseAmount;
        }

        // Magazine capacity
        magazineUpgradeCostText.text = "$" + magazineUpgradeCurrentCost;

        // Disable button if player doesn't have enough money or item is maxed out
        if (Variables.money < magazineUpgradeCurrentCost || Variables.magazineCapacity >= Variables.maxMagazineCapacity)
        {
            magazineUpgradeCostButton.interactable = false;
        }
        else
        {
            magazineUpgradeCostButton.interactable = true;
        }

        if (Variables.magazineCapacity >= Variables.maxMagazineCapacity)
        {
            Variables.magazineCapacity = Variables.maxMagazineCapacity;
            healthIncreasePreview.text = "MAX";
            healthUpgradeCostText.text = "$Gazillion";
        }
        else if (Variables.magazineCapacity < Variables.maxMagazineCapacity)
        {
            magazineIncreasePreview.text = Variables.magazineCapacity + " + " + Variables.magazineCapacityIncreaseAmount;
        }
    }

    void UpgradeFireRate()
    {
        Variables.chocolateGunFireRate += Variables.fireRateIncreaseAmount;
        Variables.money -= fireRateCurrentCost;
        fireRateCurrentCost += Variables.fireRateCostIncreaseAmount;
    }

    void UpgradePlayerHealth()
    {
        PlayerHealth.health += Variables.playerHealthIncreaseAmount;
        Variables.money -= healthUpgradeCurrentCost;
        healthUpgradeCurrentCost += Variables.playerHealthCostIncreaseAmount;
        managerOfUI.ChangeHealthBar(PlayerHealth.health);
        //managerOfUI.Healed();

    }

    void UpgradeMagazineCapacity()
    {
        Variables.magazineCapacity += Variables.magazineCapacityIncreaseAmount;
        Variables.money -= magazineUpgradeCurrentCost;
        magazineUpgradeCurrentCost += Variables.magazineCapacityCostIncreaseAmount;
        managerOfUI.ChangeAmmoBar(PlayerShoot.bulletsLeftInMagazine);
    }
}
