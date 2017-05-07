using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

	public Transform mainCamera;
	private Vector2 followPos;
	private Vector2 offsetPos;

	private float interval = 38.4f;

	// Use this for initialization
	void Start () {

		offsetPos = transform.position + mainCamera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		followPos.y = (mainCamera.transform.position.y + offsetPos.y) *0.8f;
		followPos.x = transform.position.x;

		//transform.position = new Vector2(0, followPos.y); 

		transform.position = Vector2.Lerp(transform.position, followPos, 24f * Time.deltaTime);

		if (_isRendered)
		{
			DestroyGimmick();
		}
	}

	private bool _isRendered = false;

	void OnWillRenderObject()
	{

		_isRendered = true;
	}

	void DestroyGimmick()
	{

		if (!GetComponent<Renderer>().isVisible)
		{
			transform.position = new Vector2(0,transform.position.y + 96);
			offsetPos.y = offsetPos.y + 96;
			_isRendered = false;
		}
	}
}
