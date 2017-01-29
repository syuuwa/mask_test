using UnityEngine;
using System.Collections;

public class player_follow : MonoBehaviour
{
	public Transform player;
	public float posX;
	public float posZ;
	private float smoothing = 0.8f;
	Vector3 offset;
	Vector3 newPosition;

	// Use this for initialization
	void Start()
	{
		offset = transform.position + player.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		newPosition = player.transform.position - offset;

		newPosition.z = posZ;
		newPosition.x = posX;

		if (newPosition.y > transform.position.y)
		{
			transform.position = Vector3.Lerp(transform.position, newPosition, smoothing * Time.deltaTime);
		}
	}
}
