using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	private float timeSec = 60;
	private int gameTimerSec = 60;

	public int GetTime(){
		return ((int)timeSec);
	}

	// Update is called once per frame
	void Update () {

		timeSec -= Time.deltaTime;

		if(gameTimerSec  > ((int)timeSec)){

			//Debug.Log(gameTimerSec);

			gameTimerSec = ((int)timeSec);
		}


	}
}
