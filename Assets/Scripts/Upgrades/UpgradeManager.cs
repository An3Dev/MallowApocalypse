using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {


    // Fire rate
    [SerializeField]
    Text increasePreviewFireRateText;

    [SerializeField]
    Text fireRateCostText;

    [SerializeField]
    Button fireRateCostButton;

    [SerializeField]
    Text fireRateIncreasePreview;

    int fireRateCurrentCost;

    // Player health

    //[SerializeField]


	// Use this for initialization
	void Start () {
        fireRateCurrentCost = Variables.fireRateBeginningCost;
	}
	
	// Update is called once per frame
	void Update () {
        // Change button text to current cost of fireRate
        fireRateCostText.text = "$" + fireRateCurrentCost;

        fireRateIncreasePreview.text = Variables.chocolateGunFireRate + " + " + Variables.fireRateIncreaseAmount + " / minute";

        if (Variables.money < fireRateCurrentCost)
        {
            fireRateCostButton.interactable = false;
        } else
        {
            fireRateCostButton.interactable = true;
        }
	}

    void UpgradeFireRate()
    {
        Variables.chocolateGunFireRate += Variables.fireRateIncreaseAmount;
        Variables.money -= fireRateCurrentCost;
        fireRateCurrentCost += Variables.fireRateCostIncreaseAmount;
    }
}
