﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {

    public int score;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + score);
    }
}
