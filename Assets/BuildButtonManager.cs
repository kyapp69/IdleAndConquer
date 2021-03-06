﻿using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for handling button inputs for creation of buildings.
/// </summary>
public class BuildButtonManager : MonoBehaviour {
    /// <summary>UI text element to display the cost of a building</summary>
    public Text Cost;

    /// <summary>Attached building prefab</summary>
    public GameObject AttachedBuilding;

    /// <summary>Reference to BaseSwitcher to get the correct BuildBuilding object</summary>
    public BaseSwitcher BaseSwitch;

    public SoundController SoundControll;

    private bool available;

    /// <summary>Variable to store the cost of the attached building after the Start method</summary>
    private long costBuilding;

    /// <summary>Variable to store the energy cost of the attached building after the Start method</summary>
    private int costEnergy;


    /// <summary>
    /// Triggered by a button click. Builds the wanted building if the money in the attached MoneyManager is enough to cover the costs.
    /// </summary>
    /// <param name="i">The index of the building that should be built (Indexes defined in BuildBuilding class)</param>
    public void ClickBuildBuilding(int i) {
        if (!available) {
            return;
        }

        if (MoneyManagement.HasMoney(this.costBuilding)) {
            this.BaseSwitch.GetBuilder().BuildABuilding(i, this.costBuilding, this.costEnergy);
        }
        else {
            SoundControll.StartSound(SoundController.Sounds.FUNDS_REQUIRED);
        }
    }

    public void SetAvailability(bool available) {
        this.available = available;
        GetComponent<Button>().image.color = available ? Color.white : Color.grey;
    }

    /// <summary>Use this for initialization</summary>
    private void Start() {
        var buildingManager = this.AttachedBuilding.GetComponentInChildren<BuildingManager>();
        this.costBuilding = buildingManager.BuildCost;
        this.costEnergy = buildingManager.CostEnergy;
        this.Cost.text = MoneyManagement.FormatMoney(this.costBuilding);
        //SetAvailability(false);
    }
}
