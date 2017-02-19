﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreGetter : MonoBehaviour {

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = "High Score\n" + PlayerPrefs.GetFloat("highScore") + " Seconds";
    }

}
