using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class game_back : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameBack()
	{
		Time.timeScale = 1;
		SceneManager.UnloadScene("Pause");
	}
}
