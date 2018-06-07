﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to handle the routine of the player coming back and leaving to the game
/// </summary>
public class AppPauseHandler : MonoBehaviour {
    /// <summary>List of all harvesters</summary>
    public static List<Harvester> Harvesters = new List<Harvester>();

    /// <summary>Reference to the FloatUpSpawner</summary>
    public FloatUpSpawner FloatUpSpawn;

    /// <summary>Reference to the TestText (debug text)</summary>
    public Text TestText;

    /// <summary>The prefab of a PlayerBackNotification</summary>
    public GameObject PlayerBackNotification;

    /// <summary>The transform to attach a new instance of a PlayerBackNotification to</summary>
    public Transform ParentPlayerBackNotification;

    /// <summary>Time since login</summary>
    private float loginTimer = 0f;

    /// <summary>The date and time the user paused the app</summary>
    private DateTime exitTime;

    /// <summary>
    /// Triggers one time on application pause or unpause
    /// </summary>
    /// <param name="pauseStatus">True if game is paused</param>
    void OnApplicationPause(bool pauseStatus) {
        if (!pauseStatus) {
            this.loginTimer = 0f;
            if (this.exitTime.CompareTo(DateTime.MinValue) == 0) {
                // First start/New start
                this.TestText.text = "Willkommen";
            } else {
                // Player back from pause
                this.TestText.text = "Willkommen" + Environment.NewLine + Math.Round((DateTime.Now - this.exitTime).TotalSeconds) + " Sek. Abwesenheit";
                long secondsSincePause = (long)Math.Round((DateTime.Now - this.exitTime).TotalSeconds);
                long additionalMoney = 0;
                foreach (Harvester h in Harvesters) {
                    additionalMoney += h.AddAppPauseProgressTime(secondsSincePause % (long)h.MiningSpeed);
                }

                if (secondsSincePause - (secondsSincePause % (long)Harvesters[0].MiningSpeed) > 0 || additionalMoney > 0) {
                    GameObject go = Instantiate(this.PlayerBackNotification, this.ParentPlayerBackNotification);
                    PlayerBackNotification pbn = go.GetComponent<PlayerBackNotification>();
                    pbn.Initialize("You earned money while you were gone", this.FloatUpSpawn, FloatUp.ResourceType.DOLLAR, secondsSincePause, additionalMoney, ref Harvesters);
                }
            }
        } else {
            this.exitTime = System.DateTime.Now;
        }
    }

    /// <summary>Use this for initialization</summary>
    private void Start() {
        // Set exitTime to PlayerPref Application Quit?
    }

    /// <summary>Update is called once per frame</summary>
    private void Update() {
        if (this.loginTimer > 5f) {
            this.TestText.text = string.Empty;
        } else {
            this.loginTimer += Time.deltaTime;
        }
    }
}