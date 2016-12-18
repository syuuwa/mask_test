using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class game_stop : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameStop(){

		Time.timeScale = 0;
		SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
	}
}
