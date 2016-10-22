using UnityEngine;
using System.Collections;

public class camera_moved : MonoBehaviour {
	public Transform moveCam;
	public float smoothing = 0.5f;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = moveCam.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible(){
		Debug.Log(offset.z);
		Vector3 newPosition = moveCam.transform.position;
		newPosition.x = transform.position.x + offset.x;
		newPosition.y = transform.position.y + offset.y;
		newPosition.z = transform.position.z + offset.z;
		moveCam.transform.position = Vector3.Lerp(newPosition,transform.position, smoothing * Time.deltaTime);
	}
}
