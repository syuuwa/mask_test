using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class game_retry : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameRetry()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Stage");
		SceneManager.LoadScene("UI", LoadSceneMode.Additive);
	}
}
