using UnityEngine;
using System.Collections;

public class player_moved : MonoBehaviour {

	public float speed;
	public Rigidbody rb;
	private Vector3 clickPosition;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			clickPosition = Input.mousePosition;
			MovePlayer(clickPosition,rb);
		}
	}

	//プレイヤーをタップ位置によって左右上に動かす
	void MovePlayer(Vector3 ClickPosition,Rigidbody Rb){

		if (ClickPosition.x >= 80 && ClickPosition.x <= 170)
		{
			//Debug.Log(ClickPosition.x);
			Rb.AddForce(0, speed, 0, ForceMode.Impulse);
		}
		else if (ClickPosition.x > 170)
		{
			Rb.AddForce(speed, 0.5f * speed, 0, ForceMode.Impulse);
		}
		else if (ClickPosition.x < 80)
		{
			Rb.AddForce(-1 * speed, 0.5f * speed, 0, ForceMode.Impulse);
		}
	}
}
