using UnityEngine;
using System.Collections;

public class game_back : MonoBehaviour {

	private GameObject pauseCanvas;

	// Use this for initialization
	void Start () {
		pauseCanvas = GameObject.Find("PauseCanvas");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameBack()
	{
		Time.timeScale = 1;
		pauseCanvas.GetComponent<Canvas>().enabled = false;
	}
}
