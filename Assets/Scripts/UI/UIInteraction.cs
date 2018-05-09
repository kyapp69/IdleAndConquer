﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIInteraction : MonoBehaviour {

    //private MenueController menueController;

    public MainMenueController mainMenueController;

    // Use this for initialization
    void Start () {

        //menueController = GameObject.Find("BackgroundBuyMenue").GetComponent<MenueController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenButton1() {
        SceneManager.LoadScene("MissionMap", LoadSceneMode.Single);
        //The SceneManager loads your new Scene as a single Scene (not overlapping). This is Single mode.
    }

    public void OpenButton2() {
        mainMenueController.ToggleMenue(MainMenueController.MenueCategory.MENUE_TWO);
    }

    public void OpenButton3() {
        mainMenueController.ToggleMenue(MainMenueController.MenueCategory.MENUE_THREE);
    }

    public void OpenButton4() {
        mainMenueController.ToggleMenue(MainMenueController.MenueCategory.MENUE_FOUR);
    }

    public void OpenButton5() {
        mainMenueController.ToggleMenue(MainMenueController.MenueCategory.MENUE_FIVE);
    }


}
