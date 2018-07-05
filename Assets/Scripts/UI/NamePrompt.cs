﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamePrompt : MonoBehaviour {
    public GameObject InputNamePrompt;
    public GameObject ChooseFraction;
    public GameObject OKButton;
    public GameObject Name;

    public void OnOKClick() {
        Name.SetActive(false);
        ChooseFraction.SetActive(true);
    }

    public void OnFactionChoose() {
        OKButton.SetActive(true);
    }

    public void OnFactionChooseOK() {
        Destroy(InputNamePrompt);
    }
}