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

    // Use this for initialization
    void Start () {
        fireRateCurrentCost = Variables.fireRateBeginningCost;
        healthUpgradeCurrentCost = Variables.playerHealthBeginningCost;
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
        if (Variables.money < healthUpgradeCurrentCost || Variables.playerHealth >= Variables.maxPlayerHealth)
        {
            healthUpgradeCostButton.interactable = false;
        }
        else
        {
            healthUpgradeCostButton.interactable = true;
        }

        if (Variables.playerHealth >= Variables.maxPlayerHealth)
        {
            Variables.playerHealth = Variables.maxPlayerHealth;
            healthIncreasePreview.text = "MAX";
            healthUpgradeCostText.text = "$Gazillion";
        }
        else if (Variables.playerHealth < Variables.maxPlayerHealth)
        {
            healthIncreasePreview.text = Variables.playerHealth + " + " + Variables.playerHealthIncreaseAmount;
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
        Variables.playerHealth += Variables.playerHealthIncreaseAmount;
        Variables.money -= healthUpgradeCurrentCost;
        healthUpgradeCurrentCost += Variables.playerHealthCostIncreaseAmount;
    }
}
