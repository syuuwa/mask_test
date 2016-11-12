using UnityEngine;
using System.Collections;

public class teki_moved : MonoBehaviour {

	public float moveAreaRight = 5;
	public float moveAreaLeft = 0;
	public float moveSpeed = 0.1f;
	private bool switchMoveAim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(transform.position.x >= moveAreaRight){
			switchMoveAim = true;
		}else if(transform.position.x <= moveAreaLeft){
			switchMoveAim = false;
		}

		MoveEnemy(switchMoveAim);
	}

	void MoveEnemy(bool SwitchMoveAim){
		if (switchMoveAim)
		{
			transform.position += new Vector3(-1 * moveSpeed, 0, 0);
		}
		else
		{
			transform.position += new Vector3(moveSpeed, 0, 0);
		}
	}
}
