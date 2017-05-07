﻿using UnityEngine;
using System.Collections;

public class ModeSelector : MonoBehaviour {

	private bool _isRendered = true;
	SceneLoader sl;

	// Use this for initialization
	void Start () {
		sl = GetComponent<SceneLoader>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!_isRendered){
			
			StartCoroutine("LoadScene");

		}

	}

	void OnBecameInvisible()
	{
		_isRendered = false;
	}

	IEnumerator LoadScene()
	{
		yield return new WaitForSeconds(2.0f);
		sl.LoadScene();
	}
}