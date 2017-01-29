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
	private Renderer rend;
	private string msg = "test";
	public float speed;
	public float intervalTime;
	public Material normalPlayer;
	public Material sidePlayer;

	public lifeController lifeController;
	public int oneLife = 156;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		ps = GetComponent<ParticleSystem>();
		rend = GetComponent<Renderer>();
		rend.material = normalPlayer;
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

			if (IsFlick())
			{
				//Debug.Log("Flick");
				float directionX = touchEndPos.x - touchStartPos.x;
				float directionY = touchEndPos.y - touchStartPos.y;

				if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
				{
					if (5 < directionX)
					{
						Debug.Log("Flick : Right");
						msg = "Flick : Right";
						rb.AddForce(speed, 0.5f * speed, 0, ForceMode.Impulse);
						rend.material = sidePlayer;
						rend.material.mainTextureScale = new Vector2(1, -1);
						rend.material.mainTextureOffset = new Vector2(0, 1);
						ps.Play();
					}
					else
					{
						Debug.Log("Flick : Left");
						msg = "Flick : Left";
						rb.AddForce(-1 * speed, 0.5f * speed, 0, ForceMode.Impulse);
						rend.material = sidePlayer;
						rend.material.mainTextureScale = new Vector2(-1, -1);
						rend.material.mainTextureOffset = new Vector2(1, 1);
						ps.Play();
					}
				}
				else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
				{
					if (5 < directionY)
					{
						Debug.Log("Flick : Up");
						msg = "Flick : Up";
						rb.AddForce(0, speed, 0, ForceMode.Impulse);
						rend.material = normalPlayer;
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
					msg = "Flick : Not, It's Tap";
					FlickOff();
				}
			}
			else
			{
				Debug.Log("Long Touch");
				msg = "Long Touch";
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

	public void OnGUI(){
		Rect rect = new Rect(10,10,100,30);
		GUIStyle stayle = new GUIStyle();
		stayle.normal.textColor = Color.black;
		GUI.Label(rect,msg,stayle);
	}


	void OnCollisionEnter(Collision col)
	{
		//enemyに当たったらLifeDownを実行
		if (col.gameObject.tag == "enemy")
		{
			lifeController.LifeDown(oneLife);
		}
	}
}