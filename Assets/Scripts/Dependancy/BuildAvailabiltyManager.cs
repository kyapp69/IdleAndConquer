﻿using UnityEngine;

public class BuildAvailabiltyManager : MonoBehaviour {
    [SerializeField] private BuildButtonManager[] buildButtonManagers;
    [SerializeField] private BaseSwitcher baseSwitcher;

    private void Start() {
        Refresh();
    }

    public void Refresh() {
        /*
         * 0 1 HQ
         * 1 3 Refinery
         * 2 6 PowerPlant
         * 4 5 Barracks
         * 5 7 TankFactory
         * 6 0 Airfield
         * 7 4 Research Lab
         * --------------
         * 8 Superweapon
         * 9 Centralbank
         */

        var buildBuilding = baseSwitcher.GetBuilder();

        foreach (var buildButtonManager in buildButtonManagers) {
            if (buildButtonManager == null) {
                continue;
            }
            buildButtonManager.SetAvailability(false);
        }

        buildButtonManagers[1].SetAvailability(true); // HQ always available
        if (buildBuilding.BuiltBuildings[1] != null) {//HQ built
            // Enable Refinery + PowerPlant
            buildButtonManagers[3].SetAvailability(true);
            buildButtonManagers[6].SetAvailability(true);
            if (buildBuilding.BuiltBuildings[3] != null && buildBuilding.BuiltBuildings[6] != null) { //Refinery + PowerPlant built
                // Enable Barracks + TankFactory + Airfield
                buildButtonManagers[5].SetAvailability(true);
                buildButtonManagers[7].SetAvailability(true);
                buildButtonManagers[0].SetAvailability(true);
                if (buildBuilding.BuiltBuildings[5] != null && buildBuilding.BuiltBuildings[7] != null && buildBuilding.BuiltBuildings[0] != null) {
                    // Enable Research Lab
                    buildButtonManagers[4].SetAvailability(true);
                }
            }
        }
    }
}