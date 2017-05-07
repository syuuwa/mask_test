using UnityEngine;
using System.Collections;

public class Flick: MonoBehaviour {

	private Vector2 touchStartPos;
	private Vector2 touchEndPos;

	private Vector2 right       = new Vector2(0.8f, 0.6f);
	private Vector2 upperRight  = new Vector2(0.6f, 1.0f);
	private Vector2 up          = new Vector2(0, 1.2f);
	private Vector2 upperLeft   = new Vector2(-0.6f, 1.0f);
	private Vector2 left        = new Vector2(-0.8f, 0.6f);
	private Vector2 bottomLeft  = new Vector2(-0.6f, -0.2f);
	private Vector2 bottom      = new Vector2(0, -0.3f);
	private Vector2 bottomRight = new Vector2(0.6f, -0.2f);

	private Rigidbody2D _rigidBody;

	void Awake(){
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			touchStartPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			StartCoroutine("ApplyFlickingPeriod");
		}

		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			touchEndPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			MoveObject(touchStartPos,touchEndPos);
		}
	}

	private bool isFlick;

	//フリック操作を有効にして、
	//一定時間以上タッチが続いた場合、フリック無効
	public IEnumerator ApplyFlickingPeriod()
	{
		isFlick = true;
		yield return new WaitForSeconds(0.5f);
		isFlick = false;
	}

	public void MoveObject(Vector2 TouchStartPos,Vector2 TouchEndPos)
	{
		float directionX = TouchEndPos.x - TouchStartPos.x;
		float directionY = TouchEndPos.y - TouchStartPos.y;

		if (!isFlick){
			Debug.Log("Long Tap!");
			return;	
		} 

		float radian = Mathf.Atan2(directionY, directionX) * Mathf.Rad2Deg;


		if (radian < 0) radian += 360;

		if (radian <= 22.5f || radian > 337.5f)
		{
			//Flick : Right
			_rigidBody.AddForce(right,ForceMode2D.Impulse);
		}
		else if(radian <= 67.5f && radian > 22.5f)
		{
			//Flick : Upper Right
			_rigidBody.AddForce(upperRight,ForceMode2D.Impulse);
		}
		else if (radian <= 112.5f && radian > 67.5f)
		{
			//Flick : Up
			_rigidBody.AddForce(up,ForceMode2D.Impulse);
		}
		else if (radian <= 157.5f && radian > 112.5f)
		{
			//Flick : Upper Left
			_rigidBody.AddForce(upperLeft,ForceMode2D.Impulse);
		}
		else if (radian <= 202.5f && radian > 157.5f)
		{
			//Flick : Left
			_rigidBody.AddForce(left,ForceMode2D.Impulse);
		}
		else if (radian <= 247.5f && radian > 202.5f)
		{
			//Flick : Bottom Left
			_rigidBody.AddForce(bottomLeft,ForceMode2D.Impulse);
		}
		else if (radian <= 292.5f && radian > 247.5f)
		{
			//Flick : Bottom
			_rigidBody.AddForce(bottom,ForceMode2D.Impulse);
		}
		else if (radian <= 337.5f && radian > 292.5f)
		{
			//Flick : Bottom Right
			_rigidBody.AddForce(bottomRight,ForceMode2D.Impulse);
		}
		return;
	}
}
