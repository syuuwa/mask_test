using UnityEngine;
using System.Collections;

public class player_flick_moved : MonoBehaviour
{

	private bool isFlick;
	private bool isClick;
	private Vector3 touchStartPos;
	private Vector3 touchEndPos;
	private ParticleSystem ps;
	private Rigidbody rb;
	public float speed;
	public float intervalTime;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		ps = GetComponent<ParticleSystem>();
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			isFlick = true;
			touchStartPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
			Invoke("FlickOff", intervalTime);
		}
		if (Input.GetKey(KeyCode.Mouse0))
		{
			touchEndPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);

			if (touchStartPos != touchEndPos)
			{
				ClickOff();
			}
		}
		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			touchEndPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
			//Debug.Log(touchEndPos);

			if (IsFlick())
			{
				//Debug.Log("Flick");
				float directionX = touchEndPos.x - touchStartPos.x;
				float directionY = touchEndPos.y - touchStartPos.y;
				//Debug.Log("DirectionX : " + directionX);
				//Debug.Log("DirectionY : " + directionY);
				if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
				{
					if (5 < directionX)
					{
						Debug.Log("Flick : Right");
						rb.AddForce(speed, 0.5f * speed, 0, ForceMode.Impulse);
						ps.Play();
					}
					else
					{
						Debug.Log("Flick : Left");
						rb.AddForce(-1 * speed, 0.5f * speed, 0, ForceMode.Impulse);
						ps.Play();
					}
				}
				else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
				{
					if (5 < directionY)
					{
						Debug.Log("Flick : Up");
						rb.AddForce(0, speed, 0, ForceMode.Impulse);
						ps.Play();
					}
					else
					{
						Debug.Log("Flick : Down");
					}
				}
				else
				{
					Debug.Log("Flick : Not, It's Tap");
					FlickOff();
				}
			}
			else
			{
				Debug.Log("Long Touch");
			}
		}
	}

	public void FlickOff()
	{
		isFlick = false;
		//Debug.Log("iyan");
	}

	public bool IsFlick()
	{
		return isFlick;
	}


	public void ClickOn()
	{
		isClick = true;
		Invoke("ClickOff", intervalTime);
	}

	public bool IsClick()
	{
		return isClick;
	}

	public void ClickOff()
	{
		isClick = false;
	}
}