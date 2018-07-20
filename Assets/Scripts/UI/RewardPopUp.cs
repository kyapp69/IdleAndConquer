﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPopUp : MonoBehaviour {
    public Text PlayerCommunication;
    public Text PlayerRewards;
    private MissionDetails missionDetails;
    private MoneyManagement moneyManager;
    private RenownManagement renownManager;
    private VirtualCurrencyManagement virtualCurrencyManager;
    private MissionQueue missionQueue;
    private List<Unit> unitsSent;

    public void GiveRewards() {
        var achievedRating = this.missionDetails.CalculateBattle(unitsSent);
        if (achievedRating == MissionDetails.Ratings.NOT_COMPLETED || Enum.IsDefined(typeof(MissionDetails.Ratings), achievedRating)) {
            UnityEngine.Object.Destroy(this.gameObject);
            return;
        }

        this.moneyManager.AddMoney(this.missionDetails.MissionMoneyReward);
        this.renownManager.AddRenown(this.missionDetails.MissionRenownReward);

        switch (achievedRating) {
            case MissionDetails.Ratings.ONE_STAR:
                this.virtualCurrencyManager.AddVirtualCurrency(10);
                this.missionQueue.OpenLootboxPopUp(MissionQueue.LootboxType.LEATHER);
                break;
            case MissionDetails.Ratings.TWO_STAR:
                this.virtualCurrencyManager.AddVirtualCurrency(15);
                this.missionQueue.OpenLootboxPopUp(MissionQueue.LootboxType.LEATHER);
                break;
            case MissionDetails.Ratings.THREE_STAR:
                this.virtualCurrencyManager.AddVirtualCurrency(25);
                this.missionQueue.OpenLootboxPopUp(MissionQueue.LootboxType.LEATHER);
                break;
        }

        UnityEngine.Object.Destroy(this.gameObject);
    }

    public void Initialize(MoneyManagement moneyManager, RenownManagement renownManager, VirtualCurrencyManagement virtualCurrencyManager, MissionQueue missionQueue, List<Unit> unitsSent) {
        this.moneyManager = moneyManager;
        this.renownManager = renownManager;
        this.virtualCurrencyManager = virtualCurrencyManager;
        this.missionQueue = missionQueue;
        this.unitsSent = unitsSent;
    }

    public void ShowRewards(MissionDetails missionDetails) {
        this.missionDetails = missionDetails;
        this.PlayerCommunication.text = "Congratulations on beating the mission!" + System.Environment.NewLine + System.Environment.NewLine + "You get:";
        // this.PlayerRewards.text = this.missionDetails.MissionMoneyReward + " Dollar" + System.Environment.NewLine +
        //                     this.missionDetails.MissionRenownReward + " Renown" + System.Environment.NewLine +
        //                     this.missionDetails.MissionVirtualReward + " Virtual" + System.Environment.NewLine +
        //                     this.missionDetails.MissionBlueprintReward + " Blueprint";
        
        // GameObject go = Instantiate(RewardPrefab, transform);
        // go.GetComponent<MissionReward>();
    }
}
