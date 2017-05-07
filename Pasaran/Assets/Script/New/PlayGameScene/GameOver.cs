using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject player;
	public GameObject time;

	private Life life;
	private Timer timer;

	private int remainingLife;
	private int remainingTime;

	void Awake(){
		life  = player.GetComponent<Life>();
		timer = time.GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {

		remainingLife = life.GetLife();
		remainingTime = timer.GetTime();

		if(remainingLife == 0){
			Debug.Log("Game Over");
		}

		if(remainingTime == 0){
				Debug.Log("Game Over");
		}
	}
}
