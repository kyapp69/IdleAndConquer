﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPopUp : MonoBehaviour {
    public Text PlayerCommunication;
    public Text PlayerRewards;
    // public Transform RewardsParent;
    // public GameObject RewardPrefab;
    private MissionDetails missionDetails;
    private MoneyManagement MoneyManager;
    private RenownManagement RenownManager;
    private VirtualCurrencyManagement VirtualCurrencyManager;
    private MissionQueue missionQueue;

    public void GiveRewards() {
        this.MoneyManager.AddMoney(this.missionDetails.MissionMoneyReward);
        this.RenownManager.AddRenown(this.missionDetails.MissionRenownReward);
        this.VirtualCurrencyManager.AddVirtualCurrency(this.missionDetails.MissionVirtualReward);
        // TODO Blueprint
        this.missionQueue.OpenLootboxPopUp();
        UnityEngine.Object.Destroy(this.gameObject);
    }

    public void Initialize(MoneyManagement moneyManager, RenownManagement renownManager, VirtualCurrencyManagement virtualCurrencyManager, MissionQueue missionQueue) {
        this.MoneyManager = moneyManager;
        this.RenownManager = renownManager;
        this.VirtualCurrencyManager = virtualCurrencyManager;
        this.missionQueue = missionQueue;
    }

    public void ShowRewards(MissionDetails missionDetails) {
        this.missionDetails = missionDetails;
        PlayerCommunication.text = "Congratulations on beating " + missionDetails.EnemyGeneral + "!" + System.Environment.NewLine + System.Environment.NewLine + "You get:";
        PlayerRewards.text = missionDetails.MissionMoneyReward.ToString() + " Dollar" + System.Environment.NewLine +
                             missionDetails.MissionRenownReward.ToString() + " Renown" + System.Environment.NewLine +
                             missionDetails.MissionVirtualReward.ToString() + " Virtual" + System.Environment.NewLine +
                             missionDetails.MissionBlueprintReward.ToString() + " Blueprint";
        
        // GameObject go = Instantiate(RewardPrefab, transform);
        // go.GetComponent<MissionReward>();
    }
}
