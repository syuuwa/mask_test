using UnityEngine;
using System.Collections;

public class player_moved : MonoBehaviour {

	public float speed;
	public Renderer rend;
	public Material player_side;
	public Material player_normal;
	public Rigidbody rb;
	private Vector3 clickPosition;
	private float windowWidth;
	private float leftArea;
	private float rightArea;

	// Use this for initialization
	void Start () {
		windowWidth = Screen.width;
		leftArea = windowWidth / 3;
		rightArea = leftArea * 2;
		rb = GetComponent<Rigidbody>();
		rend = GetComponent<Renderer>();
		rend.material = player_normal;
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

		if (ClickPosition.x >= leftArea && ClickPosition.x <= rightArea)
		{
			//Debug.Log(ClickPosition.x);
			Rb.AddForce(0, speed, 0, ForceMode.Impulse);
			rend.material = player_normal;
		}
		else if (ClickPosition.x > rightArea)
		{
			Rb.AddForce(speed, 0.5f * speed, 0, ForceMode.Impulse);
			rend.material = player_side;
			rend.material.mainTextureScale = new Vector2(1, -1);
			rend.material.mainTextureOffset = new Vector2(0, 1);
		}
		else if (ClickPosition.x < leftArea)
		{
			Rb.AddForce(-1 * speed, 0.5f * speed, 0, ForceMode.Impulse);
			rend.material = player_side;
			rend.material.mainTextureScale = new Vector2(-1, -1);
			rend.material.mainTextureOffset = new Vector2(1, 1);
		}
	}
}
