using UnityEngine;
using System.Collections;

public class camera_moved : MonoBehaviour {
	public Transform player;
	public float smoothing = 0.5f;
	public int posX;
	public int posY;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position + player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 newPosition = player.transform.position - offset;
		newPosition.z = posY;
		newPosition.x = posX;

		transform.position = Vector3.Lerp(transform.position, newPosition, smoothing * Time.deltaTime);
	}
}
