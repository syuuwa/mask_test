﻿using UnityEngine;
using System.Collections;

public class game_stop : MonoBehaviour {

	private GameObject pauseCanvas;

	// Use this for initialization
	void Start () {
		pauseCanvas = GameObject.Find("PauseCanvas");
		pauseCanvas.GetComponent<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameStop(){

		Time.timeScale = 0;
		pauseCanvas.GetComponent<Canvas>().enabled = true;
	}
}
