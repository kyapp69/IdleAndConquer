﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionQueue : MonoBehaviour {
    public GameObject MissionBar;
    public MoneyManagement MoneyManager;
    public RenownManagement RenownManager;
    public VirtualCurrencyManagement VirtualCurrencyManager;
    public FloatUpSpawner FloatUpSpawner;
    public GameObject RewardPopUpPrefab;
    public Transform TransformCanvas;
    public GameObject LootboxPopUpPrefab;
    private List<MissionUI> missionUIs = new List<MissionUI>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Add(Mission mission) {
        MissionUI missionUI = Instantiate(MissionBar, transform).GetComponentInChildren<MissionUI>();
        missionUI.Initialize(mission);
        missionUIs.Add(missionUI);
        missionUI.MissionQueue = this;
        //missionUI.moneyManagement = this.MoneyManagement;
        //missionUI.floatUpSpawner = this.FloatUpSpawner;
    }

    public void DestroyMissionBar(MissionUI missionUI) {
        Destroy(missionUI.transform.parent.gameObject);
    }

    public void FinshedMission(Mission attachedMission) {
        attachedMission.MissionGeneral.IsSentToMission = false;
        // Instantiate RewardPopUp
        GameObject go = Instantiate(RewardPopUpPrefab, TransformCanvas);
        // Initialize RewardPopUp
        go.GetComponent<RewardPopUp>().Initialize(MoneyManager, RenownManager, VirtualCurrencyManager, this);
        go.GetComponent<RewardPopUp>().ShowRewards(attachedMission.MissionDetails);
    }

    public void OpenLootboxPopUp() {
        Instantiate(LootboxPopUpPrefab, TransformCanvas);
    }
}
